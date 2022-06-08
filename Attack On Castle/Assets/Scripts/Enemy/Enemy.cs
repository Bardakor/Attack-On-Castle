using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.Net;
using System.IO;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public WayPoints spawnPoint;
    private Transform target;
    private string rot;
    private int waypointIndex = 0;
    public float maxHealth = 100f;
    private float health;
    public int money = 50;
    public int damage = 100;
    public int max = 2;

    public string name;

    public static bool loose = false;

    public Image healthbar;

    void Start()
    {
        target = spawnPoint.points[0];
        rot = target.tag;
        health = maxHealth;
    }

    public void TakeDamage (int damage)
    {
        health -= damage;
        healthbar.fillAmount = health / maxHealth;

        if (health <= 0)
            Die();
    }
    private void Die()
    {
        PlayerStat.money += money;
        Debug.Log(PlayerStat.money);
        
        WaveSpawner.EnemiesAlive--;
        Survival.EnemiesAlive--;
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            
            Rotate();
            GetNextWaypoint();
        }
    }
    // Start is called before the first frame update
    void GetNextWaypoint()
    {
        if (waypointIndex >= spawnPoint.points.Length - 1)
        {
            Damage();
            WaveSpawner.EnemiesAlive--;
            Survival.EnemiesAlive--;

            Destroy(gameObject);
        }
        else
        {
            waypointIndex++;
            target = spawnPoint.points[waypointIndex];
            rot = target.tag;
        }
    }

    void Rotate()
    {
        if (rot == "right")
        {
            transform.Rotate(0, 90, 0);  
        }
        else if (rot == "left")
        {
            transform.Rotate(0, -90, 0);
        }
       
    }

    void Damage()
    {
        PlayerStat.life -= damage;

        if(PlayerStat.life <= 0)
        {
            Debug.Log("You loose");
            var url = "http://projects.armandblin.com:8080/lost/" + PhotonNetwork.NickName;

            var request = WebRequest.Create(url);
            request.Method = "GET";

            using var webResponse = request.GetResponse();
            using var webStream = webResponse.GetResponseStream();

            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();

            Debug.Log("STATUS_SERVEUR" + data);

            //make UI of loose appear
            //GameObject.Find("Loose").GetComponent<Loose>().TogglePause();

            loose = true;

            //load scene 5
            PhotonNetwork.LoadLevel(6);
        }
    }

    
}
