using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UI;

public class UMPlayerNameManager : MonoBehaviour
{
    [SerializeField] TMP_InputField usernameInput;
    
    void Start()
    {
        if(PlayerPrefs.HasKey("Username"))
        {
            usernameInput.text = PlayerPrefs.GetString("Username");
            PhotonNetwork.NickName = PlayerPrefs.GetString("Username");        
        }

        else
        {
            usernameInput.text = "Player" + Random.Range(0, 10000).ToString("0000");
            OnUsernameInputValueChanged();
        }
    }
    
    
    
    public void OnUsernameInputValueChanged()
    {
        PhotonNetwork.NickName = usernameInput.text;
        PlayerPrefs.SetString("username", usernameInput.text);
    }
}
