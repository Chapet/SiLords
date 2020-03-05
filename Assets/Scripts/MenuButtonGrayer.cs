using UnityEngine;
using UnityEngine.Events;

public class MenuButtonGrayer : MonoBehaviour
{

    public UnityEvent menuEntered;
    public Player player;
    public GameObject curMenu;

    void Update()
    {
        if (curMenu.activeSelf) Gray();
    }

    void Gray()
    {
        menuEntered.Invoke();
    }
}
