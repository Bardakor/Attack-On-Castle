using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bolt : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;
    public int damage = 25;
    //Find the target of the turret
    public void Seek (Transform _target)
    {
        target = _target;
    }
   

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate (dir.normalized * distanceThisFrame, Space.World);
    }

    // void HitTarget()
    // {
    //     GameObject effectIns = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
    //     Enemy enemy = target.GetComponent<Enemy>();
    //     if (enemy != null)
    //         enemy.TakeDamage(damage);
    //     else
    //         Debug.LogError("No script enemy on an enemy weird debug this shit");
    //     Destroy (effectIns, 2f);
    //     Destroy(gameObject);
    // }

    //rewrite HitTarget() to use PhotonNetwork.Instantiate()
    public void HitTarget()
    {
        GameObject effectIns = (GameObject)PhotonNetwork.Instantiate(impactEffect.name, transform.position, transform.rotation);
        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null)
            enemy.TakeDamage(damage);
        else
            Debug.LogError("No script enemy on an enemy weird debug this shit");
        Destroy(effectIns, 2f);
        Destroy(gameObject);
    }
    
}
