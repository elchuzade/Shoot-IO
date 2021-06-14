using UnityEngine;
using UnityEngine.UI;
using static GlobalVariables;

public class Mob : MonoBehaviour
{
    Player player;
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

    // For wander movements
    public Vector3 spawnerPosition;
    Vector3 nextWanderPoint;
    [SerializeField] float wanderRadius;

    int currentWaypointIndex = 0;
    [SerializeField] float speed = 50f;

    float time = 0;
    bool moving = false;
    bool looping = false;

    void Start()
    {
        player = FindObjectOfType<Player>();
        player.LoadPlayer();

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

    #region Private Methods
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
            Debug.Log(nextWanderPoint);
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

