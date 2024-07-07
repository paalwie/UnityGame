using UnityEngine;
using System.Collections;


public class Card : MonoBehaviour {
    /// <summary>
    /// a short descreption of how the card affects on attributes
    /// </summary>
    public string flavorText = string.Empty;
    /// <summary>
    /// is the name of the card
    /// </summary>
    public string cardName {get; private set;}
    /// <summary>
    /// the pathdescription of where the Picture for this card lays.
    /// </summary>
    public string picturePath { get; private set; }
    /// <summary>
    /// the value of gems, which this card costs
    /// </summary>

    public Card(string name, string flavorText, string picturePath)
    {
        this.flavorText = flavorText;
        this.cardName = name;
        this.picturePath = picturePath;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void Activate(Player player)
    {

    }
}
