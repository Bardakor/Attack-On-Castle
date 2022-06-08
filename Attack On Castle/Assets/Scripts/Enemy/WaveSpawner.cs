using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using System.IO;
using System.Net;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;
    public Wave[] waves2;
    public Wave[] waves3;

    private List<Wave[]> Waves = new List<Wave[]> { };

    public static bool win = false;





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
        {
            Waves.Add(waves2);
        }
            
        if (waves3.Length > 0)
            Waves.Add(waves3);
    }


    // Update is called once per frame
    void Update()
    {
        if (win || Enemy.loose)
            return;
        if (EnemiesAlive > 0)
            return;

        if (countdown <= 0f && waveIndex != waves.Length)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        
        if (waveIndex == waves.Length && EnemiesAlive == 0)
        {
            Debug.Log("End of the level");
            this.enabled = false;
            var url = "http://projects.armandblin.com:8080/win/" + PhotonNetwork.NickName+"_"+Survival.minutes.ToString();

            var request = WebRequest.Create(url);
            request.Method = "GET";

            using var webResponse = request.GetResponse();
            using var webStream = webResponse.GetResponseStream();

            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();

            Debug.Log("STATUS_SERVEUR" + data);
            
            //make UI of win appear
            //GameObject.Find("Win").GetComponent<Win>().TogglePause();

            win = true;
            //load scene 4
            PhotonNetwork.LoadLevel(5);
        }
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
        }
        
        waveIndex++;
    }





    void SpawnEnemy(Enemy enemy,Wave wave)
    {
        enemy.spawnPoint = wave.spawnPoint;
        Instantiate(enemy, wave.spawnPoint.points[0].position , wave.spawnPoint.points[0].rotation);
        EnemiesAlive++;

    }

    //rewrite spaxn enemy to use PhotonNetwork.Instantiate
    // void SpawnEnemy(GameObject enemy)
    // {
    //     PhotonNetwork.Instantiate(enemy.name, spawnPoint.position, spawnPoint.rotation, 0);
    //     EnemiesAlive++;
    // }


    



}
