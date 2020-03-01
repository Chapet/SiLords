using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Player player;

    //handle all the actions happening when a round passes
    public void TimeSkip()
    {
        int tier = player.tier;
        player.time++;

        switch ((player.time - 1) % 24)
        {
            case 0:
                player.season = Player.Seasons.Printemps;
                break;
            case 6:
                player.season = Player.Seasons.Ete;
                break;
            case 12:
                player.season = Player.Seasons.Automne;
                break;
            case 18:
                player.season = Player.Seasons.Hiver;
                break;
        }

        player.ChangeGold(tier*50); //tier 0: 50, tier 1: 100, tier2: 150

        var rand = new System.Random();
        for (int i = 0; i < tier; i++)
        {
            switch (rand.Next(0, 4))
            {
                case 0:
                    player.ChangeWood(1);
                    break;
                case 1:
                    player.ChangeStone(1);
                    break;
                case 2:
                    player.ChangeGrain(1);
                    break;
                case 3:
                    player.ChangeIron(1);
                    break;
                default:
                    Debug.Log("error in GameController ressouce attribution");
                    break;
            }
        }
    }
}
