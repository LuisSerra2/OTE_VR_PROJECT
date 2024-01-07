using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ExplosiveBarrelManager : Singleton<ExplosiveBarrelManager> {
    [SerializeField] private GameObject explosiveBarrelPrefab;
    [SerializeField] private GameObject[] explosiveBarrelSpawnPosition;

    [SerializeField] private GameObject explosiveEffect;

    private Queue<Vector3> barrelPositions = new Queue<Vector3>();

    private float barrelSpawnerTimer = 20;
    private bool canStartBarrelSpawnTimer = false;

    private void Update() {
        if (canStartBarrelSpawnTimer && barrelPositions.Count > 0) { 
            barrelSpawnerTimer -= Time.deltaTime;
            if (barrelSpawnerTimer <= 0) {
                Vector3 nextBarrelPosition = barrelPositions.Dequeue(); 
                Instantiate(explosiveBarrelPrefab, nextBarrelPosition, Quaternion.identity);
                barrelSpawnerTimer = 20;
            }
        }
    }

    public void BarrelSpawnTimer(Vector3 barrel) {
        if (!barrelPositions.Contains(barrel)) { 
            barrelPositions.Enqueue(barrel);
        }
        if (!canStartBarrelSpawnTimer && barrelPositions.Count > 0) {
            canStartBarrelSpawnTimer = true; 
        }
    }


    public void SpawnExplosiveEffect(GameObject barrel) {
        GameObject explosiveEffectClone = Instantiate(explosiveEffect, barrel.transform.position, Quaternion.identity);

        Destroy(explosiveEffectClone, 5f);
    }
}
