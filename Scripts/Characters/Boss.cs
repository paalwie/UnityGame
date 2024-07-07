using UnityEngine;
using System.Collections;

public class Boss : NPC {
    private Dragon dragon;

    Boss(int attack, int defense, string characterName) : base(attack, defense, characterName)
    {
        this.characterName = characterName;
        this.attack = attack;
        this.defense = defense;
        this.dragon = new Dragon(110, 110, "Smaug");
        
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
