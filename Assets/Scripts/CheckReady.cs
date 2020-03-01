using UnityEngine;
using UnityEngine.UI;

public class CheckReady : MonoBehaviour
{
    public GameObject rect;
    public Player player;
    public GameController gameController;

    private Image img;


    private void Awake()
    {
        img = rect.GetComponent<Image>();
    }
    private void Update()
    {
        if (player.readyState && player.readyTest)
        {
            player.readyState = false;
            player.readyTest = false;

            gameController.TimeSkip();
        }
        if (player.readyState == true)
        {
            img.color = Color.green;
        }
        else
        {
            img.color = Color.red;
        }
    }
}