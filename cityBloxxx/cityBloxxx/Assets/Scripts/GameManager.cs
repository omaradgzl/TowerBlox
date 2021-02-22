using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class GameManager : MonoBehaviour
{
    private CubeSpawner[] spawners;
    private CubeSpawner currentSpawner;
    private int spawnerIndex;

    private void Awake()
    {
        spawners = FindObjectsOfType<CubeSpawner>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (MovingCube.CurrentCube!=null)
                MovingCube.CurrentCube.Stop();
            spawnerIndex = spawnerIndex == 0 ? 1 : 0;
            currentSpawner = spawners[spawnerIndex];
            
            currentSpawner.SpawnCube();
        }
    }
}
