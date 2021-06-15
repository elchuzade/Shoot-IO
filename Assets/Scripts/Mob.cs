using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GlobalVariables;

public class Mob : MonoBehaviour
{
    Player player;
    ItemInstantiator itemInstantiator;
    PlayerCanvas playerCanvas;
    [SerializeField] MobMovementTypes movementType;
    // If start and end points are equal, repeat the path
    // If different, return the path from end to start
    [SerializeField] GameObject waypoints;
    [SerializeField] float observeTime;

    [SerializeField] Image hpLoader;
    float minHP = 0;
    float timerHP = 0;
    public float maxHP = 100;
    float currentHP;
    public float regenHP = 1;
    // This is to decide what color mob health will be for you from danger palette
    public PlayerRank mobRank;
    Color32 equalMob = new Color32(255, 255, 255, 255);
    Color32 danger1Mob = new Color32(251, 156, 156, 255);
    Color32 danger2Mob = new Color32(211, 93, 93, 255);
    Color32 danger3Mob = new Color32(177, 0, 0, 255);

    public float giveXP;

    // To tell the spawner that it is dead, so instantiate a new one
    public Spawner spawner;
    // For wander movements
    public Vector3 spawnerPosition;
    Vector3 nextWanderPoint;
    [SerializeField] float wanderRadius;

    int currentWaypointIndex = 0;
    [SerializeField] float speed = 50f;

    float time = 0;
    bool moving = false;
    bool looping = false;

    // First decide whether to instantiate an item or not
    // Then decide which category of item to instantiate if pass from first step
    // Then send that request to ItemInstantiator
    [Header("Out of 100")]
    public int itemDropChance;
    public int keyDropChance;
    public int coinDropChance;
    public int diamondDropChance;
    public int basicKeyDropChance;
    public int commonKeyDropChance;
    public int uncommonKeyDropChance;
    public int rareKeyDropChance;
    public int epicKeyDropChance;
    public int uniqueKeyDropChance;
    public int legendaryKeyDropChance;
    public int specialKeyDropChance;
    [Header("Can be any number. Draw-From-Pool logic will be implemented")]
    public int basicItemDropChance;
    public int commonItemDropChance;
    public int uncommonItemDropChance;
    public int rareItemDropChance;
    public int epicItemDropChance;
    public int uniqueItemDropChance;
    public int legendaryItemDropChance;
    public int specialItemDropChance;

    void Start()
    {
        playerCanvas = FindObjectOfType<PlayerCanvas>();
        player = FindObjectOfType<Player>();
        player.LoadPlayer();

        itemInstantiator = FindObjectOfType<ItemInstantiator>();

        currentHP = maxHP;
        currentHP -= 85;
        SetMobHP();

        SetMobHealthColor();

        if (movementType == MobMovementTypes.Patrol)
        {
            if (waypoints.transform.childCount > 0)
            {
                currentWaypointIndex = 0;
                // if your coordinates and last coordinates are the same, this mob is looping
                if (transform.position == waypoints.transform.GetChild(waypoints.transform.childCount - 1).position)
                {
                    looping = true;
                }
            }
        } else if (movementType == MobMovementTypes.Wander)
        {
            Vector2 pos = Random.insideUnitCircle;
            nextWanderPoint = new Vector3(pos.x, 0.75f, pos.y).normalized * wanderRadius + spawnerPosition;
        }
    }

    void Update()
    {
        if (moving)
        {
            if (movementType == MobMovementTypes.Patrol)
            {
                FollowPath();
            }
            else if (movementType == MobMovementTypes.Wander)
            {
                WalkRandomly();
            }
        }
        else
        {
            // observing
            if (time > observeTime)
            {
                // observing is over keep moving
                moving = true;
                time = 0;
            }
            else
            {
                time += Time.deltaTime;
            }
        }
        // HEALTH POINTS
        if (currentHP < maxHP)
        {
            // Health is not max, regen it per second
            if (timerHP > 1)
            {
                currentHP += regenHP;
                // This is to not allow hp more than max
                if (currentHP > maxHP)
                {
                    currentHP = maxHP;
                }
                SetMobHP();
                // Reset HP regen timer
                timerHP = 0;
            }
            else
            {
                timerHP += Time.deltaTime;
            }
        }
    }

    #region Public Methods
    public void DealDamage(float damage)
    {
        currentHP -= damage;
        SetMobHP();
        if (currentHP <= 0)
        {
            // Die
            playerCanvas.GiveXP(giveXP);
            // Some of the mobs will have spawners some will be static
            if (spawner != null)
            {
                // Tell spawner that you dies, so he can instantiate a new mob
                spawner.RemoveMobFromMobsList(transform.parent.gameObject);
            }
            TryInstantiateItems();
            Destroy(transform.parent.gameObject);
        }
    }
    #endregion

    #region Private Methods
    void TryInstantiateItems()
    {
        // Decide to instantiat an item or not
        int randomItemDecision = Random.Range(1, 101);
        if (randomItemDecision <= itemDropChance)
        {
            // Instantiate an item
            List<ItemTypes> allItemTypes = new List<ItemTypes>();

            for (int i = 0; i < basicItemDropChance; i++)
            {
                allItemTypes.Add(ItemTypes.BasicItems);
            }
            for (int i = 0; i < commonItemDropChance; i++)
            {
                allItemTypes.Add(ItemTypes.CommonItems);
            }
            for (int i = 0; i < uncommonItemDropChance; i++)
            {
                allItemTypes.Add(ItemTypes.UncommonItems);
            }
            for (int i = 0; i < rareItemDropChance; i++)
            {
                allItemTypes.Add(ItemTypes.RareItems);
            }
            for (int i = 0; i < epicItemDropChance; i++)
            {
                allItemTypes.Add(ItemTypes.EpicItems);
            }
            for (int i = 0; i < uniqueItemDropChance; i++)
            {
                allItemTypes.Add(ItemTypes.UniqueItems);
            }
            for (int i = 0; i < legendaryItemDropChance; i++)
            {
                allItemTypes.Add(ItemTypes.LegendaryItems);
            }
            for (int i = 0; i < specialItemDropChance; i++)
            {
                allItemTypes.Add(ItemTypes.SpecialItems);
            }

            ItemTypes randomItemType = allItemTypes[Random.Range(0, allItemTypes.Count)];
            itemInstantiator.DropRandomItem(randomItemType, transform.position);
        }
        // Decide to instantiate coin or not
        int randomCoinDecision = Random.Range(1, 101);
        if (randomCoinDecision <= coinDropChance)
        {
            itemInstantiator.DropCoin(transform.position);
        }
        // Decide to instantiate diamond or not
        int randomDiamondDecision = Random.Range(1, 101);
        if (randomDiamondDecision <= diamondDropChance)
        {
            itemInstantiator.DropDiamond(transform.position);
        }
        // Decide to instantiate key or not
        int randomKeyDecision = Random.Range(1, 101);
        if (randomKeyDecision <= keyDropChance)
        {
            // Instantiate an item
            List<KeyTypes> allKeyTypes = new List<KeyTypes>();

            for (int i = 0; i < basicKeyDropChance; i++)
            {
                allKeyTypes.Add(KeyTypes.BasicKey);
            }
            for (int i = 0; i < commonKeyDropChance; i++)
            {
                allKeyTypes.Add(KeyTypes.CommonKey);
            }
            for (int i = 0; i < uncommonKeyDropChance; i++)
            {
                allKeyTypes.Add(KeyTypes.UncommonKey);
            }
            for (int i = 0; i < rareKeyDropChance; i++)
            {
                allKeyTypes.Add(KeyTypes.RareKey);
            }
            for (int i = 0; i < epicKeyDropChance; i++)
            {
                allKeyTypes.Add(KeyTypes.EpicKey);
            }
            for (int i = 0; i < uniqueKeyDropChance; i++)
            {
                allKeyTypes.Add(KeyTypes.UniqueKey);
            }
            for (int i = 0; i < legendaryKeyDropChance; i++)
            {
                allKeyTypes.Add(KeyTypes.LegendaryKey);
            }
            for (int i = 0; i < specialKeyDropChance; i++)
            {
                allKeyTypes.Add(KeyTypes.SpecialKey);
            }

            KeyTypes randomKeyType = allKeyTypes[Random.Range(0, allKeyTypes.Count)];
            itemInstantiator.DropKey(randomKeyType, transform.position);
        }
    }

    void SetMobHP()
    {
        hpLoader.fillAmount = currentHP / (maxHP - minHP);
    }

    void SetMobHealthColor()
    {
        if (mobRank - player.rank <= 0)
        {
            // Player is stronger than mob make it white
            hpLoader.color = equalMob;
        } else if (mobRank - player.rank > 0 && mobRank - player.rank <= 2)
        {
            // 1, 2 rank difference between mob and player
            hpLoader.color = danger1Mob;
        } else if (mobRank - player.rank > 2 && mobRank - player.rank <= 4)
        {
            // 1, 2 rank difference between mob and player
            hpLoader.color = danger2Mob;
        } else if (mobRank - player.rank > 4)
        {
            // 1, 2 rank difference between mob and player
            hpLoader.color = danger3Mob;
        }
    }

    void FollowPath()
    {
        if (currentWaypointIndex < waypoints.transform.childCount)
        {
            if (transform.position != waypoints.transform.GetChild(currentWaypointIndex).position)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    waypoints.transform.GetChild(currentWaypointIndex).position,
                    speed * Time.deltaTime);
            }
            else
            {
                currentWaypointIndex++;
                // reached a waypoint, start observing
                moving = false;
            }
        }
        else
        {
            if (looping)
            {
                currentWaypointIndex = 0;
            }
        }
    }

    void WalkRandomly()
    {
        if (transform.position != nextWanderPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextWanderPoint, speed * Time.deltaTime);
        } else
        {
            moving = false;
            Vector2 pos = Random.insideUnitCircle;
            nextWanderPoint = new Vector3(pos.x, 0.75f, pos.y).normalized * wanderRadius + spawnerPosition;
        }
    }
    #endregion
}

