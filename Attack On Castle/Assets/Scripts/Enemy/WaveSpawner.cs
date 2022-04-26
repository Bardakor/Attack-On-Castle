using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    [SerializeField]
    private Transform spawnPoint;


    [SerializeField]
    private float timeBetweenWaves = 5f;


    [SerializeField]
    public float countdown = 2f;

    private int waveIndex = 0;

    


    
    // Start is called before the first frame update


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
        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;

        if(waveIndex == waves.Length)
        {
            Debug.Log("End of the level");
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position , spawnPoint.rotation);
        EnemiesAlive++;

    }
}
