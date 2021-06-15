using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigator : MonoBehaviour
{
    public void LoadMyVillage()
    {
        SceneManager.LoadScene("MyVillage");
    }

    public void TowerUpgrade()
    {
        SceneManager.LoadScene("TowerUpgrade");
    }
}
