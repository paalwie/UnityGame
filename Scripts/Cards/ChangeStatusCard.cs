using UnityEngine;
using System.Collections;

public class ChangeStatusCard : Card {

    public enum Target { Dragon, Player};

    Target dragonOrPlayer;

    int attack;
    int defense;

    public ChangeStatusCard(string name, string flavorText, string picturePath, Target dragonOrPlayer, int attack, int defense) : base(flavorText, flavorText, picturePath)
    {
        this.dragonOrPlayer = dragonOrPlayer;
        this.attack = attack;
        this.defense = defense;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void changeStatusPlayer (Player player)
    {
        player.attack += attack;
        player.defense += defense;
    }

    public void changeStatusDragon (Player player)
    {
        player.playerDragon.attack += attack;
        player.playerDragon.defense += defense;
    }

    public override void Activate(Player player)
    {
        if (dragonOrPlayer == Target.Player)
        {
            changeStatusPlayer(player);
        }
        else if (dragonOrPlayer == Target.Dragon)
        {
            changeStatusDragon(player);
        }       
        base.Activate(player);
    }
}
