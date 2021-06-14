using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GlobalVariables;

public class PlayerCanvas : MonoBehaviour
{
    Player player;
    [SerializeField] Image hpLoader;
    [SerializeField] Image xpLoader;
    [SerializeField] Transform rankPos;
    [SerializeField] Image teleportLoader;

    // To make the loader work
    float minXP;
    float maxXP;
    float currentXP;
    float maxHP;

    float teleportReset = 10;

    [SerializeField] List<GameObject> ranks = new List<GameObject>();

    // Incase your rank changes during the game, you destory this one and instantiate a new one
    GameObject rankInstance;

    void Start()
    {
        player = FindObjectOfType<Player>();

        SetPlayerRank(player.rank);
        SetPlayerXP(player.XP);
    }

    #region Public Methods
    public void SetPlayerXP(float xp)
    {
        // Loaded goes from 0 to 1, so minXP, maxXP, currentXP are what we need
        xpLoader.fillAmount = currentXP / (maxXP - minXP);
    }

    public void SetPlayerHP(float hp)
    {

    }

    public void SetPlayerRank(PlayerRank rank)
    {
        ranks.ForEach(r =>
        {
            if (r.name == rank.ToString())
            {
                rankInstance = Instantiate(r, rankPos.transform.position, rankPos.rotation);
                rankInstance.transform.SetParent(rankPos);
            }
        });
    }
    #endregion
}
