using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UI;

public class UMPlayerNameManager : MonoBehaviour
{
    [SerializeField] TMP_InputField usernameInput;
    
    public void OnUsernameInputValueChanged()
    {
        PhotonNetwork.NickName = usernameInput.text;
    }
}
