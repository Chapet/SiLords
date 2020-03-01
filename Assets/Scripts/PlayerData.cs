using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    //ressources & gold
    public int wood;
    public int stone;
    public int grain;
    public int iron;
    public int gold;

    //buildings
    public bool mill;
    public bool forge;
    public bool tavern;

    //troops
    public int pikemen;
    public int cavalry;
    public int archers;

    //tier
    public int tier;

    //GameState
    public int time;
    public bool readyState;


    public PlayerData(Player player)
    {
        //ressources & gold
        wood = player.wood;
        stone = player.stone;
        grain = player.grain;
        iron = player.iron;
        gold = player.gold;

        //buildings
        mill = player.mill;
        forge = player.forge;
        tavern = player.tavern;

        //troops
        pikemen = player.pikemen;
        cavalry = player.cavalry;
        archers = player.archers;

        //tier
        tier = player.tier;

        //GameState
        time = player.time;
        readyState = player.readyState;
    }
}
