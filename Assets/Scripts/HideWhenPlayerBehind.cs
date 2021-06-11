using UnityEngine;

public class HideWhenPlayerBehind : MonoBehaviour
{
    [SerializeField] Renderer objectToHide;

    [SerializeField] Material transparentMaterial;
    [SerializeField] Material normalMaterial;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Me")
        {
            MakeHouseTransparent(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Me")
        {
            MakeHouseTransparent(false);
        }
    }

    public void MakeHouseTransparent(bool status)
    {
        if (status)
        {
            objectToHide.material = transparentMaterial;
        }
        else
        {
            objectToHide.material = normalMaterial;
        }
    }
}
