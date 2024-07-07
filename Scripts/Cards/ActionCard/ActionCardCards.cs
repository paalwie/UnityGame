using UnityEngine;
using System.Collections;



public class ActionCardCards : MonoBehaviour
{

    string cardName { get; set; }
    string flavorText { get; set; }
    string picturePath { get; set; }
    Player player { get; set; }
    int gemsQuantity { get; set; }

    public ActionCardCards(string cardName, string flavorText, string picturePath, Player player, int cardsQuantity)
    {
        this.cardName = cardName;
        this.flavorText = flavorText;
        this.picturePath = picturePath;
        this.player = player;
        this.gemsQuantity = gemsQuantity;
    }

    void CardAction()
    {
        float randomFloat = Random.value;

        if (randomFloat >= 0.0 && randomFloat <= 0.50)
            if (player.inventory.Count != 0)
                player.inventory.RemoveAt(Random.Range(0, (player.inventory.Count - 1)));
            else if (randomFloat > 0.50 && randomFloat <= 0.85)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (player.inventory.Count != 0)
                        player.inventory.RemoveAt(Random.Range(0, (player.inventory.Count - 1)));
                }
            }
            else if (randomFloat > 0.85 && randomFloat <= 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (player.inventory.Count != 0)
                        player.inventory.RemoveAt(Random.Range(0, (player.inventory.Count - 1)));
                }
            }
    }
}
