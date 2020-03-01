using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayVar : MonoBehaviour
{
    public Text textBox;
    public Player player;
    private string savedText;
    public enum State {Time, Tier, Gold, Seasons, Ressources, Buildings, Troops};
    public State state;

    void Start()
    {
        textBox = GetComponent<Text>();
        savedText = textBox.text;
    }

    void Update()
    {
        if (state == State.Time)
        {
            textBox.text = savedText + player.time.ToString();
        }
        else if (state == State.Gold)
        {
            textBox.text = savedText + player.gold.ToString();
        }
        else if (state == State.Tier)
        {
            textBox.text = savedText + player.tier.ToString();
        }
        else if (state == State.Seasons)
        {
            textBox.text = savedText + player.season.ToString();
        }
        else if (state == State.Ressources)
        {
            textBox.text = savedText + " Bois:" + player.wood.ToString() + " Pierre:" + player.stone.ToString() + " Grain:" +
                player.grain.ToString() + " Fer:" + player.iron.ToString();
        }
        else if (state == State.Buildings)
        {
            textBox.text = savedText + " Moulin:" + player.mill.ToString() + " Forge:" + player.forge.ToString() + " Taverne:" +
                player.tavern.ToString();
        }
        else if (state == State.Troops)
        {
            textBox.text = savedText + " Piquiers:" + player.pikemen.ToString() + " Cavaliers:" + player.cavalry.ToString() +
                " Archers:" + player.archers.ToString();
        }

        else {textBox.text = "snif c kc";}
        
    }
}
