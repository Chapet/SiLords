using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public enum Seasons {Printemps, Ete, Automne, Hiver};

    //ressources & gold
    public int wood = 5;
    public int stone = 5;
    public int grain = 5;
    public int iron = 5;
    public int gold = 1050;

    //buildings
    public bool mill = false;
    public bool forge = false;
    public bool tavern = true;

    //troops
    public int pikemen = 1;
    public int cavalry = 0;
    public int archers = 0;
    public int sellswords = 0;
    public int siegeEngine = 0;

    //tier
    public int tier = 1;
    public int upkeep = 0; //nbr d'upgrades d'upkeep

    //reputation
    public int reputation = 0;

    //GameState
    public int time = 1;
    public Seasons season = Seasons.Printemps;
    public bool readyState = false;
    public bool readyTest = false;
    public int currentEvent = 0;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        //ressources
        wood = data.wood;
        stone = data.stone;
        grain = data.grain;
        iron = data.iron;
        gold = data.gold;

        //buildings
        mill = data.mill;
        forge = data.forge;
        tavern = data.tavern;

        //troops
        pikemen = data.pikemen;
        cavalry = data.cavalry;
        archers = data.archers;

        //tier
        tier = data.tier;

        //GameState
        time = data.time;
        readyState = data.readyState;
}

    #region Set Methods

    public void ChangeWood(int amount)
    {
        if (wood + amount < 0) wood = 0;
        else wood += amount;
    }
    public void ChangeStone(int amount)
    {
        if (stone + amount < 0) wood = 0;
        else stone += amount;
    }

    public void ChangeGrain(int amount)
    {
        if (grain + amount < 0) wood = 0;
        else grain += amount;
    }
    public void ChangeIron(int amount)
    {
        if (iron + amount < 0) wood = 0;
        else iron += amount;
    }
    public void ChangeGold(int amount)
    {
        if (gold + amount < 0) wood = 0;
        else gold += amount;
    }
    public void ChangeReputation(int amount)
    {
        if (reputation + amount < 0) reputation = 0;
        else reputation += amount;
    }
    public void AcquireMill()
    {
        if (!mill && HasEnough(500, 2, 3, 0, 0)) //doesn't already own a mill & has the recquired ressources
        {
            mill = true;
            Buy(500, 2, 3, 0, 0);
        }
        return;
    }
    public void AcquireForge()
    {
        if (!forge && HasEnough(500, 1, 3, 0, 2)) //doesn't already own a forge & has the recquired ressources
        {
            forge = true;
            Buy(500, 1, 3, 0, 2);
        }
        return;
    }
    public void AcquireTavern()
    {
        if (!tavern && HasEnough(500, 3, 1, 1, 0)) //doesn't already own a tavern & has the recquired ressources
        {
            tavern = true;
            Buy(500, 3, 1, 1, 0);
        }
        return;
    }
    public void AcquirePikemen()
    {
        int upkp = upkeep*20 + tier*50;
        int curUpkeep = (pikemen + cavalry + archers + sellswords + siegeEngine)*10;
        if (upkp > curUpkeep && HasEnough(100, 0, 0, 0, 1))
        {
            pikemen++;
            Buy(100, 0, 0, 0, 1);
        }
        return;
    }
    public void AcquireCavalry()
    {
        int upkp = upkeep * 20 + tier * 50;
        int curUpkeep = (pikemen + cavalry + archers + sellswords + siegeEngine) * 10;
        if (upkp > curUpkeep && HasEnough(100, 0, 0, 0, 1))
        {
            cavalry++;
            Buy(100, 0, 0, 0, 1);
        }
        return;
    }
    public void AcquireArchers()
    {
        int upkp = upkeep * 20 + tier * 50;
        int curUpkeep = (pikemen + cavalry + archers + sellswords + siegeEngine) * 10;
        if (upkp > curUpkeep && HasEnough(100, 0, 0, 0, 1))
        {
            archers++;
            Buy(100, 0, 0, 0, 1);
        }
        return;
    }
    public void AcquireSellswords()
    {
        int upkp = upkeep * 20 + tier * 50;
        int curUpkeep = (pikemen + cavalry + archers + sellswords + siegeEngine) * 10;
        if (upkp > curUpkeep && HasEnough(250, 0, 0, 1, 0) && tier > 1)
        {
            sellswords++;
            Buy(250, 0, 0, 1, 0);
        }
        return;
    }
    public void AcquireSiegeEngine()
    {
        int upkp = upkeep * 20 + tier * 50;
        int curUpkeep = (pikemen + cavalry + archers + sellswords + siegeEngine) * 10;
        if (upkp > curUpkeep && HasEnough(200, 1, 0, 0, 1) && tier > 2)
        {
            siegeEngine++;
            Buy(200, 1, 0, 0, 1);
        }
        return;
    }
    public void ChangeTier(int level)
    {
        switch (level) 
        {
            case 1: //has been defeated and thus tier goes back to 1
                tier = 1;
                break;
            case 2:
                if (tier == 1) tier = 2;
                break;
            case 3:
                if (tier == 2) tier = 3;
                break;
        }
    }
    public void ChangeReadystate()
    {
        readyState = true;
        readyTest = true;
    }
    public void ChangeTime(int amount)
    {
        time += amount;
    }

    //checks if the player owns the ressources he needs to buy X
    private bool HasEnough(int go, int w, int s, int gr, int i) //gold, wood, stone, grain, iron
    {
        if (gold < go || wood < w || stone < s || grain < gr || iron < i) return false;
        else return true;
    }
    private void Buy(int go, int w, int s, int gr, int i) //gold, wood, stone, grain, iron
    {
        gold -= go; wood -= w; stone -= s; grain -= gr; iron -= i;
    }

    public void HasEnough_UI(string param) //gold, wood, stone, grain, iron, upkeep, reqTier, toBuyName, Buttonname
    {
        string[] s = param.Split(',');
        bool isNotOk = gold < int.Parse(s[0]) || wood < int.Parse(s[1]) || stone < int.Parse(s[2]) || grain < int.Parse(s[3]) 
            || iron < int.Parse(s[4]) || (pikemen + cavalry + archers + sellswords + siegeEngine + int.Parse(s[5])) * 10 > upkeep * 20 + tier * 50 || int.Parse(s[6]) > tier
            || IsOwned(s[7]);

        GameObject but = GameObject.Find(s[8]);
        Button butt = but.GetComponent<Button>();
        butt.interactable = !isNotOk;
    }
    public bool IsOwned(string bOrT)
    {
        if ((bOrT == "mill" && mill) || (bOrT == "forge" && forge) || (bOrT == "tavern" && tavern) || (bOrT == "tier2" && tier >= 2) 
            || (bOrT == "tier3" && tier >= 3))
        {
            return true;
        }
        return false;
    }
    #endregion
}
