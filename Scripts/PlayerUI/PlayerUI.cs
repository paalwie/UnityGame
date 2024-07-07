using UnityEngine;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script
using System.Collections;

public class PlayerUI : MonoBehaviour

{
    public Canvas quitMenu;
    public Canvas quitMenu2;
    public Button exitText;
    public Button exitText2;

    void Start()

    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        quitMenu2 = quitMenu2.GetComponent<Canvas>();
        exitText = exitText.GetComponent<Button>();
        exitText2 = exitText.GetComponent<Button>();
        quitMenu.enabled = false;
        quitMenu2.enabled = false;

    }

    public void ExitPress() //this function will be used on our Exit button

    {
        quitMenu.enabled = true; //enable the Quit menu when we click the Exit button
        exitText.enabled = false;
        exitText2.enabled = true;

    }

    public void NoPress() //this function will be used for our "NO" button in our Quit Menu

    {
        quitMenu.enabled = false; //we'll disable the quit menu, meaning it won't be visible anymore
        exitText.enabled = true;

    }

    public void ExitPress2() //this function will be used on our Exit button

    {
        quitMenu2.enabled = true; //enable the Quit menu when we click the Exit button
        exitText2.enabled = false;
        exitText.enabled = true;

    }

    public void NoPress2() //this function will be used for our "NO" button in our Quit Menu

    {
        quitMenu2.enabled = false; //we'll disable the quit menu, meaning it won't be visible anymore
        exitText2.enabled = true;

    }




}
