using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public Transform[] points;
   void Awake()
   {
        points = new Transform[transform.childCount];
        Debug.Log(transform.childCount+" Feo");
        
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
   }
}
