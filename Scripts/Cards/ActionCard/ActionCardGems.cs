using UnityEngine;
using System.Collections;

public class ActionCardGems : MonoBehaviour
{

    public enum ActionType { Drop, Receive };

    string cardName { get; set; }
    string flavorText { get; set; }
    string picturePath { get; set; }
    Player player { get; set; }
    ActionType actionType { get; set; }

    public ActionCardGems(string cardName, string flavorText, string picturePath, Player player, ActionType actionType)
    {
        this.cardName = cardName;
        this.flavorText = flavorText;
        this.picturePath = picturePath;
        this.player = player;
        this.actionType = actionType;
    }

    public void CardAction()
    {
        float randomFloat = Random.value;
        if (this.actionType == ActionType.Drop)
        {
            if (randomFloat >= 0.0 && randomFloat <= 0.35)
                player.gemCount--;
            else if (randomFloat > 0.35 && randomFloat <= 0.65)
                player.gemCount -= 2;
            else if (randomFloat > 0.65 && randomFloat <= 0.85)
                player.gemCount -= 4;
            else if (randomFloat > 0.85 && randomFloat <= 1)
                player.gemCount -= 5;
        }
        else if (this.actionType == ActionType.Receive)
        {
            if (randomFloat >= 0.0 && randomFloat <= 0.35)
                player.gemCount += 2;
            else if (randomFloat > 0.35 && randomFloat <= 0.65)
                player.gemCount += 4;
            else if (randomFloat > 0.65 && randomFloat <= 0.85)
                player.gemCount += 8;
            else if (randomFloat > 0.85 && randomFloat <= 1)
                player.gemCount += 10;
        }

    }
}
