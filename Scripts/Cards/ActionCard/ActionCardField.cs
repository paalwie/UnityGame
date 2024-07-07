using UnityEngine;
using System.Collections;

public class ActionCardField : MonoBehaviour {

    string cardName { get; set; }
    string flavorText { get; set; }
    string picturePath { get; set; }
    Player player { get; set; }
    int gemsQuantity { get; set; }
    ActionType actionType { get; set; }
    GameManager manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    public enum ActionType { Ahead, Back };

    public ActionCardField(string cardName, string flavorText, string picturePath, Player player, ActionType actionType)
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
        if (this.actionType == ActionType.Ahead)
        {
            
            if (randomFloat >= 0.0 && randomFloat <= 0.50 )
                manager.playerInfoList[manager.playerIndex].TeleportPlayer(manager.fields[manager.playerInfoList[manager.playerIndex].currentIndex -2].GetComponent<Field>());
            else if (randomFloat > 0.50 && randomFloat <= 0.85)
                manager.playerInfoList[manager.playerIndex].TeleportPlayer(manager.fields[manager.playerInfoList[manager.playerIndex].currentIndex - 3].GetComponent<Field>());
            else if (randomFloat > 0.85 && randomFloat <= 1)
                manager.playerInfoList[manager.playerIndex].TeleportPlayer(manager.fields[manager.playerInfoList[manager.playerIndex].currentIndex - 4].GetComponent<Field>());
        }
        else if (this.actionType == ActionType.Back)
        {
            if (randomFloat >= 0.0 && randomFloat <= 0.50)
                if ((manager.playerInfoList[manager.playerIndex].currentIndex - 2) >= 0)
                    manager.playerInfoList[manager.playerIndex].TeleportPlayer(manager.fields[manager.playerInfoList[manager.playerIndex].currentIndex - 2].GetComponent<Field>());
                else manager.playerInfoList[manager.playerIndex].TeleportPlayer(manager.fields[0].GetComponent<Field>());
            else if (randomFloat > 0.50 && randomFloat <= 0.85)
                if ((manager.playerInfoList[manager.playerIndex].currentIndex - 3) >= 0)
                    manager.playerInfoList[manager.playerIndex].TeleportPlayer(manager.fields[manager.playerInfoList[manager.playerIndex].currentIndex - 3].GetComponent<Field>());
                else manager.playerInfoList[manager.playerIndex].TeleportPlayer(manager.fields[0].GetComponent<Field>());
            else if (randomFloat > 0.85 && randomFloat <= 1)
                if ((manager.playerInfoList[manager.playerIndex].currentIndex - 4) >= 0)
                    manager.playerInfoList[manager.playerIndex].TeleportPlayer(manager.fields[manager.playerInfoList[manager.playerIndex].currentIndex - 4].GetComponent<Field>());
                else manager.playerInfoList[manager.playerIndex].TeleportPlayer(manager.fields[0].GetComponent<Field>());
        }

    }




}
