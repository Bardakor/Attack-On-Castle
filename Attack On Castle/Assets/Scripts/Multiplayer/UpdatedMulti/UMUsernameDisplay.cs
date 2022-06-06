using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;

public class UMUsernameDisplay : MonoBehaviour
{
    [SerializeField] TMP_InputField usernameInputField;

    void Start()
    {
        if(PlayerPrefs.HasKey("username"))
        {
            usernameInputField.text = PlayerPrefs.GetString("username");
            PhotonNetwork.NickName = PlayerPrefs.GetString("username");
        }
        else
        {
            usernameInputField.text = "Player" + Random.Range(0, 10000).ToString("0000");
            OnUserNameInputValueChanged();
        }
    }

    public void OnUserNameInputValueChanged()
    {
        PhotonNetwork.NickName = usernameInputField.text;
        PlayerPrefs.SetString("username", usernameInputField.text);
    }
}
