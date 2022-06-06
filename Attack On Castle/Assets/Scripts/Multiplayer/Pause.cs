using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool paused = false;
    private bool disconnecting = false;

    public void TogglePause()
    {
        if(disconnecting) return;

        paused = !paused;

        transform.GetChild(0).gameObject.SetActive(paused);
    }

    public void Quit()
    {
        disconnecting = true;
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(0);

    }

    public void Quitgame()
    {
        Application.Quit();
    }

    private void Update()
    {
        
    }
}
