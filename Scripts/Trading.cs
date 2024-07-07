using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trading : MonoBehaviour
{

    private List<ItemCard> offers = new List<ItemCard>();

    public Trading()
    {

    }
    // <summary>
    // Player is buying a card, which he has chosen from offers
    // </summary>
    // <param name = "buyingPlayer" ></ param >
    // < param name="chosenCard"></param>
    public static void PlayerBuy(Player customer, ItemCard chosenCard)
    {
        if ((customer.gemCount - chosenCard.value) > 0)
        {
            customer.gemCount = customer.gemCount - chosenCard.value;
            customer.inventory.Add(chosenCard);
        }
        else
        {
            Console.WriteLine("not enough gems");
        }
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Fills the shop with the given amount of Cards.
    /// </summary>
    /// <param name="amountOfOffers">The number of cards you want to generate.</param>
    public void FillShopWithOffers(int amountOfOffers)
    {
        for (int i = 0; i < amountOfOffers; i++)
        {
            offers.Add(GenerateOffer());
        }
    }

    /// <summary>
    /// Generate a ItemCard. NOT IMPLEMENTED!
    /// </summary>
    /// <returns>The Generated Card.</returns>
    public ItemCard GenerateOffer()
    {
        return new ItemCard("Test", "Das ist ein Test", "Hier wäre der Pfad des Bildes", 5);
    }

}
