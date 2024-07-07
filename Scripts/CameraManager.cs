using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private float zoomSpeed = 1f;

    [SerializeField]
    private float movementSpeed = 1f;
    
    [SerializeField]
    private Transform[] camPos;

    [SerializeField]
    private float lerpSpeed = 2f;

    private int currentView = 0;
    private Transform playerTrans;
    private float cameraDistance = 10f;
    private UIManager ui;
    private GameManager manager;

    private void Start()
    {
        ui = GetComponent<UIManager>();
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        playerTrans = manager.playerInfoList[manager.playerIndex].playerObject.transform;

        SwitchView();
    }

    public void SwitchView()
    {
        currentView = ui.GetCameraViewValue();

        switch(currentView)
        {
            case 0:
                Camera.main.transform.position = camPos[0].position;
                Camera.main.transform.rotation = camPos[0].rotation;
                Camera.main.orthographic = true;
                Camera.main.orthographicSize = 56.8f;
                break;
            case 1:
                Camera.main.transform.position = camPos[1].position;
                Camera.main.transform.rotation = camPos[1].rotation;
                Camera.main.orthographic = false;
                break;

            case 2:
                Camera.main.transform.position = playerTrans.position + Vector3.up * 2.5f;
                Camera.main.transform.rotation = playerTrans.rotation;
                Camera.main.orthographic = false;
                break;
        }
    }
    
	private void Update ()
    {
        switch (currentView)
        {
            case 0:
                if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                {
                    Camera.main.transform.position += new Vector3(Input.GetAxis("Horizontal") * movementSpeed, 0 , Input.GetAxis("Vertical") * movementSpeed);
                }
                if (Input.GetAxis("Mouse ScrollWheel") != 0)
                {
                    Camera.main.orthographicSize += Mathf.Min(zoomSpeed * Input.GetAxis("Mouse ScrollWheel"), 6);
                }
                break;
            case 1:
                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, playerTrans.position + (playerTrans.forward * -cameraDistance) + (playerTrans.up * cameraDistance), Time.deltaTime * lerpSpeed);
                Camera.main.transform.LookAt(playerTrans);

                if (Input.GetAxis("Mouse ScrollWheel") != 0)
                {
                    cameraDistance += zoomSpeed * Input.GetAxis("Mouse ScrollWheel");
                }
                break;

            case 2:
                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, playerTrans.position + (Vector3.forward * -cameraDistance*3) + (Vector3.up * cameraDistance*3), Time.deltaTime * lerpSpeed);
                Camera.main.transform.LookAt(playerTrans);

                if (Input.GetAxis("Mouse ScrollWheel") != 0)
                {
                    cameraDistance += zoomSpeed * Input.GetAxis("Mouse ScrollWheel");
                }
                break;
        }
    }

    public void RefreshCurrentPlayerTrans()
    {
        playerTrans = manager.playerInfoList[manager.playerIndex].playerObject.transform;
    }
}
