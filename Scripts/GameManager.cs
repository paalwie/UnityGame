using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;


public class GameManager : MonoBehaviour
{

    /// <summary>
    /// A Hepler Class with all the informaiton of a player.
    /// </summary>
    [System.Serializable]
    public class PlayerInfo
    {
        /// <summary>
        /// Current Position in the fields array of this player.
        /// </summary>
        public int currentIndex { get; set; }

        /// <summary>
        /// The Player Object in the scene.
        /// </summary>
        public GameObject playerObject { get; set; }

        /// <summary>
        /// The companion/dragon Object in the scene.
        /// </summary>
        public GameObject companionObject { get; set; }

        /// <summary>
        /// The target where the player has to move.
        /// </summary>
        public Transform target { get; set; }

        /// <summary>
        /// The NavMeshAgent for the player. This component is attached to a mobile character in the game to allow it to navigate the scene using the NavMesh.
        /// </summary>
        public NavMeshAgent agent { get; set; }

        /// <summary>
        /// Is for moving the character around?
        /// </summary>
        public ThirdPersonCharacter character { get; set; }

        /// <summary>
        /// The Stats of the player.
        /// </summary>
        public UserPlayer player { get; set; }

        /// <summary>
        /// Teleports the player and his companion to the choosen field.
        /// </summary>
        /// <param name="field">The field you want to teleport to.</param>
        public void TeleportPlayer(Field field)
        {
            playerObject.transform.position = field.transform.position;
            target = field.transform;
            currentIndex = field.GetIndex();
            player.currentFieldIndex = field.GetIndex();

            companionObject.transform.position = field.transform.position;
        }
    }

    /// <summary>
    /// A Helper Class with all the information of a NPC.
    /// </summary>
    [System.Serializable]
    public class EnemyInfo
    {
        /// <summary>
        /// The index of the npc in the fields array.
        /// </summary>
        public int currentIndex { get; set; }

        /// <summary>
        /// The stats of the enemy.
        /// </summary>
        public NPC enemy { get; set; }

        /// <summary>
        /// Constructor for a enemey Info.
        /// </summary>
        /// <param name="currentIndex">The index of the npc in the fields array. (postion)</param>
        /// <param name="enemy">The stats of the enemy.</param>
        public EnemyInfo(int currentIndex, NPC enemy)
        {
            this.currentIndex = currentIndex;
            this.enemy = enemy;
        }
    }

    /// <summary>
    /// An array with all the fields of board.
    /// </summary>
    [SerializeField]
    public Transform[] fields;

    /// <summary>
    /// A List with all the players in a game.
    /// </summary>
    public List<PlayerInfo> playerInfoList = new List<PlayerInfo>();

    /// <summary>
    /// A List with all the NPC Enemys in the game.
    /// </summary>
    public List<EnemyInfo> enemyInfoList = new List<EnemyInfo>();

    /// <summary>
    /// Number of fields a player has to move.
    /// </summary>
    [SerializeField]
    private int fieldsToMove = 0;
        
    /// <summary>
    /// The test UI that was created by Max.
    /// </summary>
    private UIManager ui;

    /// <summary>
    /// What?
    /// </summary>
    public Text playerName;

    /// <summary>
    /// The Index for the current Player. It´s the turn of the player in the playerInfoList at this position. 
    /// </summary>
    public int playerIndex = 0;

    /// <summary>
    /// Is this the first turn of the game?
    /// </summary>
    private bool firstTurn = true;


    /// <summary>
    /// Flag for the position the player started this turn.
    /// </summary>
    public Field lastField;

    /// <summary>
    /// Flag for the position the player started this turn.
    /// </summary>
    public Transform startField;

    /// <summary>
    /// The Prefab for a character in scene.
    /// </summary>
    [SerializeField]
    public GameObject CharacterPrefab;

    /// <summary>
    /// The Prefab for the companion of character(Dragon of the character).
    /// </summary>
    [SerializeField]
    public GameObject[] companionPrefabs;

    /// <summary>
    /// A Enum with the four character classes.
    /// </summary>
    enum CharacterClass { Krieger, Bogenschütze, Magier, Schurke };

    /// <summary>
    /// A Array wit the names of the four Character Classes of the CharacterClass Enum.
    /// </summary>
    string[] characterClass = Enum.GetNames(typeof(CharacterClass));



    /// <summary>
    /// Is called when the game starts. Creates the Players and NPCs and sets thier attributes.
    /// </summary>
    private void Start()
    {

        ui = GetComponent<UIManager>();


        CreatePlayers((PlayerPrefs.GetInt("Player Number")));

        ///
        ///  alt: -> CreatePlayers(4);
        ///

        CreateNpcEnemies();  
        SetCharacterAttribute();      
    }

    /// <summary>
    /// Updates every Frame so the Players a Moving.... I think?
    /// </summary>
    private void Update()
    {
        for (int i = 0; i < playerInfoList.Count; i++)
        {
            if (playerInfoList[i].target != null)
            {
                playerInfoList[i].agent.SetDestination(playerInfoList[i].target.position);
            }

            if (playerInfoList[i].agent.remainingDistance > playerInfoList[i].agent.stoppingDistance)
            {
                playerInfoList[i].character.Move(playerInfoList[i].agent.desiredVelocity, false, false);
            }
            else
            {
                playerInfoList[i].character.Move(Vector3.zero, false, false);
            }
        }
    }

    /// <summary>
    /// Set the field where a character is supposed to move.
    /// </summary>
    /// <param name="target">The Transform/Field where the character should move.</param>
    public void SetTarget(Transform target)
    {
        playerInfoList[playerIndex].target = target;
    }

    public void OnCreateClicked()
    {
        playerName = GameObject.Find("PlayerName").GetComponent<Text>();

        int companionPrefabIndex = 0;

        GameObject player = Instantiate(CharacterPrefab, fields[0].position, Quaternion.Euler(new Vector3())) as GameObject;
        GameObject companion = Instantiate(
                                    companionPrefabs[companionPrefabIndex], fields[0].position, companionPrefabs[companionPrefabIndex].transform.rotation) as GameObject;
        companion.GetComponent<Companion>().target = player.transform;

        playerInfoList.Add(new PlayerInfo());

        playerInfoList[playerInfoList.Count - 1].playerObject = player;
        playerInfoList[playerInfoList.Count - 1].currentIndex = 0;
        playerInfoList[playerInfoList.Count - 1].target = fields[0];
        playerInfoList[playerInfoList.Count - 1].agent = player.GetComponent<NavMeshAgent>();
        playerInfoList[playerInfoList.Count - 1].character = player.GetComponent<ThirdPersonCharacter>();

        playerInfoList[playerInfoList.Count - 1].agent.updateRotation = false;
        playerInfoList[playerInfoList.Count - 1].agent.updatePosition = true;

        playerInfoList[playerInfoList.Count - 1].companionObject = companion;

        UserPlayer userPlayer = player.AddComponent<UserPlayer>();
        //player.SetName(playerName.text);
        userPlayer.defense = 100;

        ui.thePanel.SetActive(false);

    }

    /// <summary>
    /// The player is shuffling to move and moves when this is clicked.
    /// </summary>
    public void OnStartClicked()
    {
        NextTurn();
        lastField = GetCurrentField();
        fieldsToMove = UnityEngine.Random.Range(1, 7);
        ui.diceOutput.text = fieldsToMove.ToString();
        
        // Is the player currently standing on an intersection?
        if (lastField.GetChildFields().Length > 1)
        {
            SetTarget(lastField.transform);
            ui.moveLeft.interactable = true;
            ui.moveRight.interactable = true;
        }
        else
        {
            SetTarget(lastField.GetChildFields()[0].transform);
        }

        ui.roll.interactable = false;


    }

    /// <summary>
    /// Change the Number of Fields a player has to move.
    /// </summary>
    /// <param name="number">The number that is subtracted form <see cref="fieldsToMove"/></param>
    public void SubtractFromFieldsToMove(int number)
    {
        fieldsToMove -= number;

    }

    /// <summary>
    /// Returns the number of fields a character has to walk to get to this location.
    /// </summary>
    /// <returns>Number of Fields he has to move.</returns>
    public int GetFieldsToMove()
    {
        return fieldsToMove;
    }

    /// <summary>
    /// Sets the Index for the current Player.
    /// </summary>
    /// <param name="player">The Player where the Index is supposed to be set.</param>
    /// <param name="index">The Index where the player is.</param>
    public void SetIndex(Player player, int index)
    {
        player.currentFieldIndex = index;

        for (int i = 0; i < playerInfoList.Count; i++)
        {
            if(playerInfoList[i].player == player)
                playerInfoList[i].currentIndex = index;
        }
    }

    /// <summary>
    /// Get the current Field of the current Player.
    /// </summary>
    /// <returns>The Field where the current Player is standing.</returns>
    public Field GetCurrentField()
    {
        return fields[playerInfoList[playerIndex].currentIndex].GetComponent<Field>();
    }

    /// <summary>
    /// Reloads the scene of the Game.
    /// </summary>
    public void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Moves a player to the next field.
    /// </summary>
    /// <param name="moveLeft">Is he supposed to go right or left?</param>
    public void MoveToField(bool moveLeft)
    {
        //Get the Position of the next Field and set it as Target
        if (moveLeft)
        {
            SetTarget(GetCurrentField().GetChildFields()[0].transform);
        }
        else
        {
            SetTarget(GetCurrentField().GetChildFields()[1].transform);
        }
    }

    /// <summary>
    /// This method creates the characters with thier companions.
    /// </summary>
    /// <param name="numberOfPlayers">The amount of player that are created.</param>
    public void CreatePlayers(int numberOfPlayers)
    {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            GameObject player = Instantiate(CharacterPrefab, fields[0].position, Quaternion.Euler(new Vector3())) as GameObject;
            GameObject companion = Instantiate(companionPrefabs[i], fields[0].position, companionPrefabs[i].transform.rotation) as GameObject;
            companion.GetComponent<Companion>().target = player.transform;

            playerInfoList.Add(new PlayerInfo());

            playerInfoList[i].playerObject = player;
            playerInfoList[i].currentIndex = 0;
            playerInfoList[i].target = fields[0];
            playerInfoList[i].agent = player.GetComponent<NavMeshAgent>();
            playerInfoList[i].character = player.GetComponent<ThirdPersonCharacter>();

            playerInfoList[i].agent.updateRotation = false;
            playerInfoList[i].agent.updatePosition = true;
            
            playerInfoList[i].companionObject = companion;
           
        }
    }

    /// <summary>
    /// This Methods initiates the next turn, so the next Player can walk.
    /// </summary>
    public void NextTurn()
    {
        // check if this is the first round, else increment the playerIndex so the next Player is choosen
        if (firstTurn == true)
        {
            firstTurn = false;
        }
        else
        {
            playerIndex++;
        }


        if (playerIndex > playerInfoList.Count - 1)
        {
            playerIndex = 0;

        }
        UserPlayer player = playerInfoList[playerIndex].player;
        player.currentFieldIndex = playerIndex;
        
        startField = GetCurrentField().transform;
        GetComponent<CameraManager>().RefreshCurrentPlayerTrans();
    }

    /// <summary>
    /// This Methods sets the Attributes of the four different classes to each player.
    /// </summary>
    public void SetCharacterAttribute()
    {

        for (int i = 0; i < characterClass.Length; i++)
        {
            UserPlayer player = playerInfoList[i].playerObject.AddComponent<UserPlayer>();
            playerInfoList[i].player = player;

            switch (characterClass[i])
            {
                // Warrior
                case "Krieger":
                    Warrior warrior = new Warrior();
                    player.characterName = "Aragon";
                    player.characterClass = warrior;
                    player.defense = warrior.defense;
                    player.lifePoints = warrior.lifepoints;
                    player.attack = warrior.attack;
                    player.luck = warrior.luck;
                    player.toughness = warrior.toughness;
                    player.gemCount = 8;
                    player.playerDragon = new Dragon(0,0,"PflichtbewussterStaatsbürger");
                    break;
                    // Archer
                case "Bogenschütze":
                    Archer archer = new Archer();
                    player.characterName = "Legolas";
                    player.characterClass = archer;
                    player.defense = archer.defense;
                    player.lifePoints = archer.lifepoints;
                    player.attack = archer.attack;
                    player.luck = archer.luck;
                    player.toughness = archer.toughness;
                    player.playerDragon = new Dragon(0, 0, "BulgarianDragon");
                    player.gemCount = 8;
                    break;
                    //Magician
                case "Magier":
                    Magician magician = new Magician();
                    player.characterName = "Gandalf";
                    player.characterClass = magician;
                    player.defense = magician.defense;
                    player.lifePoints = magician.lifepoints;
                    player.attack = magician.attack;
                    player.luck = magician.luck;
                    player.toughness = magician.toughness;
                    player.playerDragon = new Dragon(0, 0, "Atzeeeeen");
                    player.gemCount = 8;
                    break;
                    // Rouge
                case "Schurke":
                    Rogue rogue = new Rogue();
                    player.characterName = "Nathanael";
                    player.characterClass = rogue;
                    player.defense = rogue.defense;
                    player.lifePoints = rogue.lifepoints;
                    player.attack = rogue.attack;
                    player.luck = rogue.luck;
                    player.toughness = rogue.toughness;
                    player.playerDragon = new Dragon(0, 0, "TurkishKillerEliteNinja");
                    player.gemCount = 8;
                    break;
            }


        }
    }



    /// <summary>
    /// Creates the normal NPC Enemies on the Field.
    /// </summary>
    private void CreateNpcEnemies()
    {
        for (int i = 1; i < this.fields.Length; i++)
        {
            enemyInfoList.Add(new EnemyInfo(i, new NPC(10, 10, "Test-Gegner")));
        }
    }

}
