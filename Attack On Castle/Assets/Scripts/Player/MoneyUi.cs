using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUi : MonoBehaviour
{

    public Text moneyText;
    void Update()
    {
        moneyText.text = PlayerStat.money.ToString();
    }
}
