using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSpawn : MonoBehaviour
{
    public int scoreNeeded; 
    public GameObject spawn;
    public GameObject boss;
    public float reloadTime;
    public float StartReloadTime;

    void Update()
    {
        if (reloadTime <= 0){
            Instantiate(boss, spawn.transform.position, spawn.transform.rotation);
            reloadTime = StartReloadTime;
        }
        else
        {
            reloadTime -= Time.deltaTime;
        }
    }
}
