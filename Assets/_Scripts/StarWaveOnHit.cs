using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarWaveOnHit : MonoBehaviour, IHittable {

    private WaveManager waveManager;

    private int countStart = 0;

    private void Start() {
        waveManager = FindObjectOfType<WaveManager>();
    }
    public void GetHit() {
        if (countStart <= 0) {
            waveManager.StartWave();
            countStart++;
        } else {
            waveManager.enemiesAlive = 0;
        }
    }
}
