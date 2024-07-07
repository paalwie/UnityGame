using UnityEngine;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script
using System.Collections;

public class PlayerCount : MonoBehaviour
{
    public Button startText;
    public Button playerCount1;
    public Button playerCount2;
    public Button playerCount3;
    public Button playerCount4;

    void Start()

    {

        startText = startText.GetComponent<Button>();
        playerCount1 = playerCount1.GetComponent<Button>();
        playerCount2 = playerCount2.GetComponent<Button>();
        playerCount3 = playerCount3.GetComponent<Button>();
        playerCount4 = playerCount4.GetComponent<Button>();

    }

    public void PlayerCount1() //this function will be used on our Play button

    {
        PlayerPrefs.SetInt("Player Number", 1);

    }


    public void PlayerCount2() //this function will be used on our Play button

    {
        PlayerPrefs.SetInt("Player Number", 2);

    }


    public void PlayerCount3() //this function will be used on our Play button

    {
        PlayerPrefs.SetInt("Player Number", 3);

    }


    public void PlayerCount4() //this function will be used on our Play button

    {
        PlayerPrefs.SetInt("Player Number", 4);

    }


    /// <summary>
    ///  PlayerPrefs.SetInt("Player Score", 10);
    /// </summary>



    public void StartLevel() //this function will be used on our Play button

    {
        Application.LoadLevel(2); //this will load our first level from our build settings. "1" is the second scene in our game

    }


}