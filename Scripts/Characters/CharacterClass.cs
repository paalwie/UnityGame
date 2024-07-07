using UnityEngine;
using System.Collections;

public class CharacterClass : Character {


    public int toughness;
    private int LifePoints; 
    public int lifepoints { get {return LifePoints;} set {
            if (value > 5)
            {
                value = 5;
            }
            LifePoints = value;
        } }
    public int luck;

    public CharacterClass(int attack, int defense, string characterName, int toughness, int lifepoints, int luck) : base (attack,defense,characterName)
    {
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
    /// <summary>
    /// the CharacterAbility of the Characters Archer, Rogue, Magician and Warrior get defined here
    /// </summary>
    public virtual void CharacterAbility()
    {

    }


}
