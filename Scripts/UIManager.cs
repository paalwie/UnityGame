using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Button moveLeft;
    public Button moveRight;
    public Button roll;
    public Text diceOutput;
    public GameObject thePanel;

    [SerializeField]
    private Dropdown cameraView;

    public int GetCameraViewValue()
    {
        return cameraView.value;
    }

    public void OnMoveLeftClicked()
    {
        moveLeft.interactable = false;
        moveRight.interactable = false;
        GetComponent<GameManager>().MoveToField(true);
    }

    public void OnMoveRightClicked()
    {
        moveLeft.interactable = false;
        moveRight.interactable = false;
        GetComponent<GameManager>().MoveToField(false);
    }

    public void onCreatePlayerClicked()
    {
        thePanel.SetActive(true);
    }

}
