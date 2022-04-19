using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;

    private Transform target;
    private string rot;
    private int waypointIndex = 0;
    public float maxHealth = 100f;
    private float health;

    public Image healthbar;

    void Start()
    {
        target = WayPoints.points[0];
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
        if (waypointIndex >= WayPoints.points.Length - 1)
        {
            Destroy(gameObject);
        }
        else
        {
            waypointIndex++;
            target = WayPoints.points[waypointIndex];
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

    
}
