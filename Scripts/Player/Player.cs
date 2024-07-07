using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    /// <summary>
    /// Is the name of the choosen class, Warrior, Archer, Mage
    /// </summary>
    public string characterClassName;
    /// <summary>
    /// lifepoints can only get added when cards for this matter appear and get activated,
    /// these are the points which get lost, when you walk over a trap.
    /// </summary>
    public int lifePoints;
    /// <summary>
    /// luck affects random events passively.
    /// for example: the higher your luck the higher is your chance to get an extra card on your turn
    ///              or you earn the possibility to increase your dicenumber by one
    ///it also affects the end of fights.              
    ///
    /// </summary>
    public int luck;
    /// <summary>
    /// toughness is your health-value of your character, if your toughness value reaches 0 you have to start at the start of the table
    /// </summary>
    public int toughness;
    /// <summary>
    /// The characterClass defines the class of your Character: Mage, Archer, Rogue, Warrior
    /// </summary>
    public CharacterClass characterClass;

    public int gemCount { get; set; }

    public int attack;

    public int defense;


    public string characterName;

 
    public List<Card> inventory { get; set; }

    public Dragon playerDragon;

    public int currentFieldIndex;
    

    public Player(string characterName, CharacterClass characterClass, Dragon dragon, int currentFieldIndex)
    {
        this.characterClassName = characterClass.characterName;
        this.attack = characterClass.attack;
        this.defense = characterClass.defense;
        this.characterName = characterName;
        this.lifePoints = characterClass.lifepoints;          
        this.luck = characterClass.luck;
        this.toughness = characterClass.toughness;
        this.playerDragon = dragon;
        this.currentFieldIndex = currentFieldIndex;
        this.inventory = new List<Card>();
        this.gemCount = 8;
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeGemCount (int changedGems)
    {
        this.gemCount += changedGems;
    }

    public void AddCard (Card card)
    {
        this.inventory.Add(card);
    }

    public void UseCard (Card card)
    {
       
    }

 
}
