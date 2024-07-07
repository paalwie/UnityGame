using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Field : MonoBehaviour
{
    /// <summary>
    /// Index of this Field in the fields array in GameManager.
    /// </summary>
    [SerializeField]
    private int index;

    /// <summary>
    /// Childs of the field. Field has childs when there is a crossing (Left or right).
    /// </summary>
    [SerializeField]
    private Field[] childs;

    /// <summary>
    /// The GameManager Object.
    /// </summary>
    private GameManager manager;

    /// <summary>
    /// The UI.
    /// </summary>
    private UIManager ui;

    /// <summary>
    /// The number of Cards that are supposed to be drawn.
    /// </summary>
    public int cardsOnThisField { get; private set; }

    private int attackerIndexInPlayerInfo;

    private int defenderIndexInPlayerInfo;


    /// <summary>
    /// Is called when a Field is created.
    /// </summary>
    private void Start()
    {
        cardsOnThisField = 2;
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        ui = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIManager>();
    }

    void playerFight()
    {
        Player looser = Fight.PlayerVsPlayer(manager.playerInfoList[manager.playerIndex].player, manager.playerInfoList[defenderIndexInPlayerInfo].player);
        // Teleport the Looser to the other field.
        // Attacker has lost.
        if (looser == manager.playerInfoList[attackerIndexInPlayerInfo].player)
        {
            Debug.Log("Attacker has lost -> Teleport to Field: " + manager.lastField);
            manager.playerInfoList[manager.playerIndex].TeleportPlayer(manager.lastField);
        }
        // Defender has lost.
        else
        {
            Debug.Log("Defender has lost -> Teleport to Field: " + manager.lastField);
            manager.playerInfoList[defenderIndexInPlayerInfo].TeleportPlayer(manager.lastField);
        }
    }

    void NPCFight()
    {
        bool won = Fight.PlayerVsNPC(manager.playerInfoList[manager.playerIndex].player, manager.enemyInfoList[defenderIndexInPlayerInfo].enemy);
        // Player has won.
        if (won == true)
        {
            Debug.Log("Attacker has won against NPC.");
            manager.enemyInfoList.Remove(manager.enemyInfoList[defenderIndexInPlayerInfo]);
        }
        // Player has lost.
        else
        {
            Debug.Log("Attacker has lost against NPC -> Teleport to Field: " + manager.lastField);
            manager.playerInfoList[manager.playerIndex].TeleportPlayer(manager.lastField);
        }
    }

    void playerFlee()
    {
        Debug.Log("Attacker has run away -> Teleport to Field: " + manager.lastField);
        manager.playerInfoList[manager.playerIndex].TeleportPlayer(manager.lastField);
    }

    /// <summary>
    /// Is called when a player enters a field. Triggers almost everything (Fights, Trade, drawing cards)
    /// </summary>
    /// <param name="col">The Object that enters the field.</param>
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag != "Player") return;


        manager.SubtractFromFieldsToMove(1);
        manager.SetIndex(col.GetComponent<Player>(), index);

        if (manager.GetFieldsToMove() == 0)
        {
            //ActionCardField fieldCard = new ActionCardField("fuck you too", null, null, manager.playerInfo[manager.playerIndex].player, ActionCardField.
            //    ActionType.Back);
            //fieldCard.CardAction();
            //ActionCardGems gemsCard = new ActionCardGems("fuck you", null,null, manager.playerInfoList[manager.playerIndex].player, ActionCardGems.
            //    ActionType.Receive);
            //gemsCard.CardAction();
            //Debug.Log(manager.playerInfoList[manager.playerIndex].player.characterName + " recieved gems and he has: " + manager.playerInfoList[manager.playerIndex].player.gemCount);

            // Are two players on the same field?
            for (int i = 0; i < manager.playerInfoList.Count; i++)
            {
                // Checks if the current player is on the same field like a other player and it is not himself.
                if (manager.playerInfoList[manager.playerIndex].currentIndex == manager.playerInfoList[i].currentIndex && manager.playerIndex != i)
                {
                    //// Fight against each other.
                    Player attacker = manager.playerInfoList[manager.playerIndex].player;
                    attackerIndexInPlayerInfo = manager.playerIndex;
                    Player defender = manager.playerInfoList[i].player;
                    defenderIndexInPlayerInfo = i;
                    FightPanel fightPanel = FightPanel.Instance();
                    fightPanel.fightPlayerVsPlayer(playerFight,playerFlee,attacker,defender);                 
                }
                
            }

            // Fight against NPC enemies
            for (int i = 0; i < manager.enemyInfoList.Count; i++)
            {
                if (manager.playerInfoList[manager.playerIndex].currentIndex == manager.enemyInfoList[i].currentIndex)
                {
                    Player attacker = manager.playerInfoList[manager.playerIndex].player;
                    attackerIndexInPlayerInfo = manager.playerIndex;
                    NPC defender = manager.enemyInfoList[i].enemy;
                    defenderIndexInPlayerInfo = i;
                    FightPanel fightPanel = FightPanel.Instance();
                    fightPanel.fightPlayerVsNPC(NPCFight, playerFlee, attacker, defender);
                }
            }
       
            ui.roll.interactable = true;
        }
        else if(manager.GetFieldsToMove() < 0)
        {

            ui.roll.interactable = true;
            return;
        }


        if (childs.Length > 1 && manager.GetFieldsToMove() > 0)  // If there is an intersection and the player can move
        {
            ui.moveLeft.interactable = true;
            ui.moveRight.interactable = true;
        }
        else if (childs.Length <= 1 && manager.GetFieldsToMove() > 0) // If there is no intersection and the player can move
        {
            ui.moveLeft.interactable = false;
            ui.moveRight.interactable = false;

            if (childs[0] != null)
                manager.SetTarget(childs[0].transform);

        }
        else
        {
            ui.moveLeft.interactable = false;
            ui.moveRight.interactable = false;
        }


    }

    /// <summary>
    /// Returns the child fields.
    /// </summary>
    /// <returns>The Fields that are following the crossing.</returns>
    public Field[] GetChildFields()
    {
        return childs;
    }

    /// <summary>
    /// Returns the Index of this field.
    /// </summary>
    /// <returns></returns>
    public int GetIndex()
    {
        return index;
    }
}
