using UnityEngine;

[System.Serializable]
public class Wave
{
    public Enemy enemy;
    public int count;
    public float rate;

    [SerializeField]
    public WayPoints spawnPoint;

    

}
