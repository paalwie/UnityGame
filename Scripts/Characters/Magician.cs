using UnityEngine;
using System.Collections;

public class Magician : CharacterClass {

    public Magician(int attack = 40, int defense = 5, string characterName = "Magier", int toughness = 20, int lifepoints = 3, int luck = 0) : base(attack, defense, characterName, toughness, lifepoints, luck)
    {
        this.characterName = characterName;
        this.attack = attack;
        this.defense = defense;
        this.toughness = toughness;
        this.lifepoints = lifepoints;
        this.luck = luck;
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //public void CharacterAbility() { }
}
