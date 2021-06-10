using UnityEngine;
using UnityEngine.UI;

public class HorizontalScroll : MonoBehaviour
{
    [SerializeField] Scrollbar scrollbar;

    void Start()
    {
        scrollbar.value = 1;
    }

    public void SetScrollValue(float value)
    {
        scrollbar.value = value;
    }
}
