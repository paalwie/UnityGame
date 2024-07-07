using UnityEngine;
using System.Collections;

public class ItemCard : Card {

    /// <summary>
    /// Cost of the object in at the trader
    /// </summary>
    public int value { get; private set; }

    public ItemCard(string name, string flavorText, string picturePath, int value) : base(name,flavorText, picturePath)
    {
        this.value = value;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
