using UnityEngine;
using System.Collections;

public class NPC : Character {

    public NPC(int attack, int defense, string characterName) : base(attack, defense,characterName)
    {
        this.attack = attack;
        this.defense = defense;
        this.characterName = characterName;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
