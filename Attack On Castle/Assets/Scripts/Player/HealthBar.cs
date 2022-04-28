using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = PlayerStat.startHealth;
        slider.value = PlayerStat.life;
    }

    
    // Update is called once per frame
    void Update()
    {
        slider.value = PlayerStat.life;
    }
}
