using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    /// <summary>
    /// characterName defines the name of the casted character
    /// </summary>
    public string characterName { get; set; }
    /// <summary>
    /// attack defines the attack value of your character
    /// </summary>
    public int attack { get; set; }
    /// <summary>
    /// defense defines the defense value of your character
    /// </summary>
    public int defense { get; set; }

    /// <summary>
    /// The path were the Picture of the character is stored.
    /// </summary>
    public string picturePath { get; set; }



    public Character(int attack, int defense, string characterName, string picturePath = "")
    {
        this.attack = attack;
        this.defense = defense;
        this.characterName = characterName;
        this.picturePath = picturePath;
    }



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetName(string characterName) {
        this.characterName = characterName;
    }

    /// <summary>
    /// changes the attack value, by the parameter-value
    /// </summary>
    /// <param name="changeAttackValue"></param>
    public void ChangeAttack(int changeAttackValue)
    {
        this.attack += changeAttackValue;
    }
    /// <summary>
    /// changes the defense value, by the parameter-value
    /// </summary>
    /// <param name="changeDefenseValue"></param>
    public void ChangeDefense(int changeDefenseValue)
    {
        this.defense += changeDefenseValue;
    }

  
}
