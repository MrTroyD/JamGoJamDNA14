using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLane : MonoBehaviour
{
    public GameObject[] shootLanes;
    public GameObject[] oilSlicks;

    // Start is called before the first frame update
    void Start()
    {
        int rnd = Random.Range(0, shootLanes.Length);
        for (int i = 0; i < shootLanes.Length; i++)
        {
            if (i == rnd) continue;
            shootLanes[i].SetActive(false);

            if (Random.Range(0f, 1.01f) < .85f) oilSlicks[i].SetActive(false);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
