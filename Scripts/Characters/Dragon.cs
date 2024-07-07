using UnityEngine;
using System.Collections;

public class Dragon : Character {

    public Dragon(int attack, int defense, string characterName) : base(attack,defense,characterName)
    {
        this.characterName = characterName;
        int random = Random.Range(1, 7);

        switch (random)
        {
            case 1:
                this.attack = 10;
                this.defense = 10;
                break;
            case 2:
                this.attack = 15;
                this.defense = 15;
                break;
            case 3:
                this.attack = 20;
                this.defense = 20;
                break;
            case 4:
                this.attack = 30;
                this.defense = 30;
                break;
            case 5:
                this.attack = 35;
                this.defense = 35;
                break;
            case 6:
                this.attack = 40;
                this.defense = 40;
                break;

        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
