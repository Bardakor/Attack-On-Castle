using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using System.IO;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;
    public Wave[] waves2;
    public Wave[] waves3;

    private List<Wave[]> Waves = new List<Wave[]> { };





    [SerializeField]
    private float timeBetweenWaves = 5f;


    [SerializeField]
    public float countdown = 2f;

    private int waveIndex = 0;






    // Start is called before the first frame update
    private void Start()
    {
        Waves.Add(waves);
        if (waves2.Length > 0)
            Debug.Log("Popo");
        if (waves3.Length > 0)
            Waves.Add(waves3);
    }


    // Update is called once per frame
    void Update()
    {
        if (EnemiesAlive > 0)
            return;

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        foreach (Wave[] waves in Waves)
        {

            Wave wave = waves[waveIndex];

            for (int i = 0; i < wave.count; i++)
            {
                SpawnEnemy(wave.enemy, wave);
                yield return new WaitForSeconds(1f / wave.rate);
            }

            waveIndex++;

            if (waveIndex == waves.Length)
            {
                Debug.Log("End of the level");
                this.enabled = false;
            }
        }
    }





    void SpawnEnemy(GameObject enemy,Wave wave)
    {
        Instantiate(enemy, wave.spawnPoint.position , wave.spawnPoint.rotation);
        EnemiesAlive++;

    }

    //rewrite spaxn enemy to use PhotonNetwork.Instantiate
    // void SpawnEnemy(GameObject enemy)
    // {
    //     PhotonNetwork.Instantiate(enemy.name, spawnPoint.position, spawnPoint.rotation, 0);
    //     EnemiesAlive++;
    // }


    



}
