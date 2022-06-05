using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class Billboard : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] PhotonView PV;

    void Start()
    {
       text.text = PV.Owner.NickName;
    }
}
