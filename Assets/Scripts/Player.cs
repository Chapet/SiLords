using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //tier
    public int tier = 1;

    //GameState
    public int time = 1;
    public Seasons season = Seasons.Printemps;
    public bool readyState = false;
    public bool readyTest = false;

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
        wood += amount;
    }
    public void ChangeStone(int amount)
    {
        stone += amount;
    }

    public void ChangeGrain(int amount)
    {
        grain += amount;
    }
    public void ChangeIron(int amount)
    {
        iron += amount;
    }
    public void ChangeGold(int amount)
    {
        gold += amount;
    }
    public void AcquirePikemen(int amount)
    {
        pikemen++;
    }
    public void AcquireMill(int amount)
    {
        mill = true;
    }
    public void AcquireForge(int amount)
    {
        forge = true;
    }
    public void AcquireTavern(int amount)
    {
        tavern = true;
    }
    public void AcquireCavalry(int amount)
    {
        cavalry++;
    }
    public void AcquireArchers(int amount)
    {
        archers++;
    }
    public void ChangeTier(int amount)
    {
        tier += amount;
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

    #endregion
}
