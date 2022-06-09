using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survival : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public static int Round = 8;
    public static int maxWaves = 2;


    public static string roundtxt = $"";
    public static string Timertxt = $"";


    public static float TimeElapsed = 300f;
    public static int minutes = Mathf.FloorToInt(Survival.TimeElapsed / 60F);
    public static int seconds = Mathf.FloorToInt(Survival.TimeElapsed - minutes * 60);

    public Enemy SlowEnemy;
    public Enemy MidEnemy;
    public Enemy FastEnemy;

    public Enemy MiniBoss;
    public WayPoints Spawn1;
    public WayPoints Spawn2;
    public WayPoints Spawn3;

    private List<WayPoints> SpawnPoints = new List<WayPoints> { };
    private List<Enemy> Enemies = new List<Enemy> { };

    [SerializeField]
    private float timeBetweenWaves = 5f;


    [SerializeField]
    public float countdown = 2f;





    // Start is called before the first frame update
    void Start()
    {
        SpawnPoints.Add(Spawn1);
        SpawnPoints.Add(Spawn2);
        SpawnPoints.Add(Spawn3);
        Enemies.Add(SlowEnemy);
        Enemies.Add(MidEnemy);
        Enemies.Add(FastEnemy);
        Enemies.Add(MidEnemy);
        Timertxt = string.Format("{0:0}:{1:00}", minutes, seconds);
        roundtxt = "Round 0";


    }

    // Update is called once per frame
    void Update()
    {
        TimeElapsed += Time.deltaTime;
        minutes = Mathf.FloorToInt(Survival.TimeElapsed / 60F);
        seconds = Mathf.FloorToInt(Survival.TimeElapsed - minutes * 60);
        Timertxt = string.Format("{0:0}:{1:00}", minutes, seconds);
        
        
        if (EnemiesAlive > 0)
            return;
        if (countdown > 0f)
        {
            countdown -= Time.deltaTime;
            return;
        }


        Round += 1;
        roundtxt = $"Round {Round}";
        if (Round % 2 == 0)
            maxWaves += 1;
        
        if (Round % 4 == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Enemies[i].maxHealth = (float)(Enemies[i].maxHealth * 1.10);
                Enemies[i].damage = Enemies[i].damage + 5;
                Enemies[i].max = Enemies[i].max + 1; 
                Debug.Log(Enemies[i].maxHealth);
            }
        }

        if (Round % 6 == 0)
            Enemies.Add(SlowEnemy);
        if (Round % 10 == 0)
            SpawnEnemy(MiniBoss, SpawnPoints[Random.Range(0, 3)]);

        countdown = timeBetweenWaves;
        int nbWaves = Random.Range(maxWaves, maxWaves + 3);
        StartCoroutine(SpawnWave(nbWaves));
    }

    void SpawnEnemy(Enemy enemy, WayPoints spawn)
    {
        enemy.spawnPoint = spawn;
        Instantiate(enemy, spawn.points[0].position, spawn.points[0].rotation);
        EnemiesAlive++;
    }

    IEnumerator SpawnWave(int nbWaves)
    {
        for (int i = 0; i < nbWaves; i++)
        {
            WayPoints spawn = SpawnPoints[Random.Range(0, 3)];
            Enemy enemy = Enemies[Random.Range(0, Enemies.Count)];
            int nbEnemies = Random.Range(enemy.max, enemy.max + 3);
            for (int j = 0; j < enemy.max; j++)
            {
                SpawnEnemy(enemy, spawn);
                yield return new WaitForSeconds(1f);
            }
        }

    }
}
