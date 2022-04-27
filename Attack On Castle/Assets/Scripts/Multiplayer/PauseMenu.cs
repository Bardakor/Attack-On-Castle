using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    private bool disconnecting = false;

    public void TogglePause()
    {
        if(disconnecting) return;

        paused = !paused;

        transform.GetChild(0).gameObject.SetActive(paused);
        Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = paused;
    }

    public void Quit()
    {
        disconnecting = true;
        PhotonNetwork.Disconnect();
        Application.Quit();
    }

    private void Update()
    {
        bool pause = Input.GetKeyDown(KeyCode.Escape);

        if(pause)
        {
            GameObject.Find("Pause").GetComponent<PauseMenu>().TogglePause();
        }
        if(paused)
        {
            //disable all control from script CameraController
        }

    }
}
