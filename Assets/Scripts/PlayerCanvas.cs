using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GlobalVariables;

public class PlayerCanvas : MonoBehaviour
{
    Navigator navigator;
    Player player;
    [SerializeField] Image hpLoader;
    [SerializeField] Image xpLoader;
    [SerializeField] Transform rankPos;
    [SerializeField] Image tpLoader;

    // To make the loader work
    float minXP;
    float maxXP;

    float maxHP;
    float minHP = 0;

    float regenHP = 10; // 1 hp per second
    float timerHP = 0;

    float resetTP = 10;
    float timerTP = 0;
    bool readyTP = false;

    [SerializeField] List<GameObject> ranks = new List<GameObject>();

    // Incase your rank changes during the game, you destory this one and instantiate a new one
    GameObject rankInstance;

    void Start()
    {
        navigator = FindObjectOfType<Navigator>();
        player = FindObjectOfType<Player>();
        //player.ResetPlayer();
        player.LoadPlayer();

        maxHP = player.maxHP;

        SetPlayerRank();
        SetPlayerHP();
        SetPlayerXP();
    }

    void Update()
    {
        // HEALTH POINTS
        if (player.HP < player.maxHP)
        {
            // Health is not max, regen it per second
            if (timerHP > 1)
            {
                player.HP += regenHP;
                // This is to not allow hp more than max
                if (player.HP > maxHP)
                {
                    player.HP = maxHP;
                }
                player.SavePlayer();
                SetPlayerHP();
                // Reset HP regen timer
                timerHP = 0;
            } else
            {
                timerHP += Time.deltaTime;
            }
        }
        // TELEPORT
        if (!readyTP)
        {
            if (timerTP > resetTP)
            {
                readyTP = true;
                timerTP = 0;
                tpLoader.gameObject.SetActive(false);
            } else
            {
                timerTP += Time.deltaTime;
                tpLoader.fillAmount = 1 - (timerTP / resetTP);
            }
        }
    }

    #region Public Methods
    public void ClickTeleportButton()
    {
        navigator.LoadMyVillage();
    }

    public void SetPlayerXP()
    {
        PlayerRank nextRank;

        PlayerRank[] allRanks = (PlayerRank[])Enum.GetValues(typeof(PlayerRank));

        for (int i = 0; i < allRanks.Length; i++)
        {
            if (player.rank == allRanks[i] && i < allRanks.Length - 1)
            {
                nextRank = allRanks[i+1];
                maxXP = GetRankXP(nextRank);
                break;
            } else
            {
                // This is to show that there is no next rank
                maxXP = 1000000000;
            }
        }

        minXP = GetRankXP(player.rank);

        // Loaded goes from 0 to 1, so minXP, maxXP, currentXP are what we need
        xpLoader.fillAmount = player.XP / (maxXP - minXP);
    }

    public void SetPlayerHP()
    {
        hpLoader.fillAmount = player.HP / (maxHP - minHP);
    }

    public void SetPlayerRank()
    {
        ranks.ForEach(r =>
        {
            if (r.name == player.rank.ToString())
            {
                rankInstance = Instantiate(r, rankPos.transform.position, rankPos.rotation);
                rankInstance.transform.SetParent(rankPos);
            }
        });
    }
    #endregion

    #region Private Methods
    // Methods that will take in rank and return xp that is needed to pass that rank and promote to the next one
    float GetRankXP (PlayerRank rank)
    {
        switch (rank)
        {
            case PlayerRank.Rank0:
                return 50;
            case PlayerRank.Rank1:
                return 100;
            case PlayerRank.Rank2:
                return 200;
            case PlayerRank.Rank3:
                return 300;
            case PlayerRank.Rank4:
                return 400;
            case PlayerRank.Rank5:
                return 500;
            case PlayerRank.Rank6:
                return 600;
            case PlayerRank.Rank7:
                return 700;
            case PlayerRank.Rank8:
                return 800;
            case PlayerRank.Rank9:
                return 900;
            case PlayerRank.Rank10:
                return 1000;
            case PlayerRank.Rank11:
                return 1100;
            case PlayerRank.Rank12:
                return 1200;
            case PlayerRank.Rank13:
                return 1300;
            case PlayerRank.Rank14:
                return 1400;
            case PlayerRank.Rank15:
                return 1500;
            case PlayerRank.Rank16:
                return 1600;
            case PlayerRank.Rank17:
                return 1700;
            case PlayerRank.Rank18:
                return 1800;
            case PlayerRank.Rank19:
                return 1900;
            case PlayerRank.Rank20:
                return 2000;
            case PlayerRank.Rank21:
                return 2100;
            case PlayerRank.Rank22:
                return 2200;
            case PlayerRank.Rank23:
                return 2300;
            case PlayerRank.Rank24:
                return 2400;
            case PlayerRank.Rank25:
                return 2500;
            case PlayerRank.Rank26:
                return 2600;
            case PlayerRank.Rank27:
                return 2700;
            case PlayerRank.Rank28:
                return 2800;
            case PlayerRank.Rank29:
                return 2900;
            case PlayerRank.Rank30:
                return 3000;
            case PlayerRank.Rank31:
                return 3100;
            case PlayerRank.Rank32:
                return 3200;
            case PlayerRank.Rank33:
                return 3300;
            case PlayerRank.Rank34:
                return 3400;
            case PlayerRank.Rank35:
                return 3500;
            case PlayerRank.Rank36:
                return 3600;
            case PlayerRank.Rank37:
                return 3700;
            case PlayerRank.Rank38:
                return 3800;
            case PlayerRank.Rank39:
                return 3900;
            case PlayerRank.Rank40:
                return 4000;
            case PlayerRank.Rank41:
                return 4100;
            case PlayerRank.Rank42:
                return 4200;
            case PlayerRank.Rank43:
                return 4300;
            case PlayerRank.Rank44:
                return 4400;
            case PlayerRank.Rank45:
                return 4500;
            case PlayerRank.Rank46:
                return 4600;
            case PlayerRank.Rank47:
                return 4700;
            case PlayerRank.Rank48:
                return 4800;
            case PlayerRank.Rank49:
                return 4900;
            case PlayerRank.Rank50:
                return 5000;
            case PlayerRank.Rank51:
                return 5100;
            case PlayerRank.Rank52:
                return 5200;
            case PlayerRank.Rank53:
                return 5300;
            case PlayerRank.Rank54:
                return 5400;
            case PlayerRank.Rank55:
                return 5500;
        }
        return 1000000000;
    }
    #endregion
}
