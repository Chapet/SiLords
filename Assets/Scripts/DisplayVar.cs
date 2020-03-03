using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayVar : MonoBehaviour
{
    public Text textBoxConstantDisp;
    public Player player;
    private string savedText;
    public enum State {Time, Tier, Gold, Seasons, Ressources, Buildings, Troops};
    public State state;

    void Start()
    {
        textBoxConstantDisp = GetComponent<Text>();
        savedText = textBoxConstantDisp.text;
    }

    void Update()
    {
        if (state == State.Time)
        {
            textBoxConstantDisp.text = savedText + player.time.ToString();
        }
        else if (state == State.Gold)
        {
            textBoxConstantDisp.text = savedText + player.gold.ToString();
        }
        else if (state == State.Tier)
        {
            textBoxConstantDisp.text = savedText + player.tier.ToString();
        }
        else if (state == State.Seasons)
        {
            textBoxConstantDisp.text = savedText + player.season.ToString();
        }
        else if (state == State.Ressources)
        {
            textBoxConstantDisp.text = savedText + " Bois:" + player.wood.ToString() + " Pierre:" + player.stone.ToString() + " Grain:" +
                player.grain.ToString() + " Fer:" + player.iron.ToString();
        }
        else if (state == State.Buildings)
        {
            textBoxConstantDisp.text = savedText + " Moulin:" + player.mill.ToString() + " Forge:" + player.forge.ToString() + " Taverne:" +
                player.tavern.ToString();
        }
        else if (state == State.Troops)
        {
            textBoxConstantDisp.text = savedText + " Piquiers:" + player.pikemen.ToString() + " Cavaliers:" + player.cavalry.ToString() +
                " Archers:" + player.archers.ToString();
        }

        else { textBoxConstantDisp.text = "snif c kc";}
        
    }
}
