using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Player player;
    public PopupSystem pop;
    public enum PersonalEvents {Bandits, Discontent, SendKid, Merchant, Hunt};
    public enum SpringEvents {BountyfulSpring, Flood};
    public enum SummerEvents {BountyfulSummer, ForestFire};
    public enum FallEvents {BountyfulFall, Disease};
    public enum WinterEvents {HarshWinter};

    //handle all the actions happening when a round passes
    public void TimeSkip()
    {
        var rand = new System.Random();

        int tier = player.tier;
        player.time++;


        switch ((player.time - 1) % 24) //seasons begin + global events (50% chance) + personal events (50% chance)
        {
            case 0: //spring
                player.season = Player.Seasons.Printemps;
                break;
            case 1: //spring event global (2d)
                if (rand.Next(0, 2) == 1) // 2[ -> 50% chance
                {
                    //select randomly an event from the SeasonalEvents (here, spring) enum
                    SpringEvents gEvent = (SpringEvents)rand.Next(SpringEvents.GetNames(typeof(SpringEvents)).Length);
                    Debug.Log("SpringgEvent = " + gEvent);

                    if (gEvent == SpringEvents.BountyfulSpring)
                    {
                        pop.PopMessage(PopupSystem.Popup.PopBountyString);
                    }
                    else //gEvent == SpringEvents.Flood
                    {
                        pop.PopMessage(PopupSystem.Popup.PopFlood);
                    }
                }
                break;
            case 3: //spring personnal event (4th)
                if (rand.Next(0, 2) == 1) // 2[ -> 50% chance
                {
                    PopPersonnal();
                }
                break;
            case 6: //summer
                player.season = Player.Seasons.Ete;
                break;
            case 7: //summer event global (2d)
                if (rand.Next(0, 2) == 1) // 2[ -> 50% chance
                {
                    SummerEvents gEvent = (SummerEvents)rand.Next(SummerEvents.GetNames(typeof(SummerEvents)).Length);
                    Debug.Log("SummergEvent = " + gEvent);

                    if (gEvent == SummerEvents.BountyfulSummer)
                    {
                        pop.PopMessage(PopupSystem.Popup.PopBountySummer);
                    }
                    else //gEvent == SummerEvents.ForestFire
                    {
                        pop.PopMessage(PopupSystem.Popup.PopForestFire);
                    }
                }
                break;
            case 9: //summer personnal event (4th)
                if (rand.Next(0, 2) == 1) 
                {
                    PopPersonnal();
                }
                break;
            case 12: //fall
                player.season = Player.Seasons.Automne;
                break;
            case 13: //fall event global (2d)
                if (rand.Next(0, 2) == 1)
                {
                    FallEvents gEvent = (FallEvents)rand.Next(FallEvents.GetNames(typeof(FallEvents)).Length);
                    Debug.Log("FallgEvent = " + gEvent);

                    if (gEvent == FallEvents.BountyfulFall)
                    {
                        pop.PopMessage(PopupSystem.Popup.PopBountyFall);
                    }
                    else //gEvent == FallEvents.Disease
                    {
                        pop.PopMessage(PopupSystem.Popup.PopDisease);
                    }
                }
                break;
            case 15: //fall personnal event (4th)
                if (rand.Next(0, 2) == 1)
                {
                    PopPersonnal();
                }
                break;
            case 18: //winter
                player.season = Player.Seasons.Hiver;
                break;
            case 19: //winter event global (2d)
                if (rand.Next(0, 2) == 1)
                {
                    WinterEvents gEvent = (WinterEvents)rand.Next(WinterEvents.GetNames(typeof(WinterEvents)).Length);
                    Debug.Log("WintergEvent = " + gEvent);

                    pop.PopMessage(PopupSystem.Popup.PopHarshWinter); //winter has no good gEvent
                }
                break;
            case 21: //winter personnal event (4th)
                if (rand.Next(0, 2) == 1)
                {
                    PopPersonnal();
                }
                break;
        }

        player.ChangeGold(tier*50); //tier 0: 50, tier 1: 100, tier2: 150

        for (int i = 0; i < tier; i++)
        {
            switch (rand.Next(0, 4)) // 4[
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

    private void PopPersonnal()
    {
        var rand = new System.Random();
        //selects a random event from the PersonalEvents enum
        PersonalEvents pEvent = (PersonalEvents)rand.Next(PersonalEvents.GetNames(typeof(PersonalEvents)).Length);
        Debug.Log("Personal Event chosen: " + pEvent);

        switch (pEvent) 
        {
            case PersonalEvents.Bandits:
                pop.PopMessage(PopupSystem.Popup.PopBandit);
                break;
            case PersonalEvents.Discontent:
                pop.PopMessage(PopupSystem.Popup.PopDiscontent);
                break;
            case PersonalEvents.Hunt:
                pop.PopMessage(PopupSystem.Popup.PopHunt);
                break;
            case PersonalEvents.Merchant:
                pop.PopMessage(PopupSystem.Popup.PopMerchant);
                break;
            case PersonalEvents.SendKid:
                pop.PopMessage(PopupSystem.Popup.PopSendKid);
                break;
        }
    }
}
