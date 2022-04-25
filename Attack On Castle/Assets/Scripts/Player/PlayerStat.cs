using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{


    public static int life;
    public static int money;

    public int startMoney = 200;
    public int startHealth = 1500;

    // Start is called before the first frame update
    void Start()
    {
        money = startMoney;

        life = startHealth;
        Debug.Log(PlayerStat.money);
        Debug.Log(PlayerStat.life);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
