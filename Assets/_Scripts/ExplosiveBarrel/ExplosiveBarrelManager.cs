using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ExplosiveBarrelManager : Singleton<ExplosiveBarrelManager> {
    [SerializeField] private GameObject explosiveBarrelPrefab;

    [SerializeField] private GameObject explosiveEffect;

    private Dictionary<Vector3, float> barrelTimers = new Dictionary<Vector3, float>();
    private Dictionary<Vector3, Transform> barrelParents = new Dictionary<Vector3, Transform>();
    private float defaultBarrelSpawnerTimer = 15f;

    private void Update() {
        List<Vector3> barrelsToRemove = new List<Vector3>();

        foreach (var barrelPos in new List<Vector3>(barrelTimers.Keys)) {
            barrelTimers[barrelPos] -= Time.deltaTime;
            if (barrelTimers[barrelPos] <= 0) {
                SpawnBarrel(barrelPos, barrelParents[barrelPos]);
                barrelsToRemove.Add(barrelPos);
            }
        }

        foreach (var barrelPos in barrelsToRemove) {
            barrelTimers.Remove(barrelPos);
            barrelParents.Remove(barrelPos);
        }
    }

    private void SpawnBarrel(Vector3 position, Transform parent) {
        Instantiate(explosiveBarrelPrefab, position, Quaternion.identity, parent);
    }

    public void BarrelSpawnTimer(Vector3 barrel, Transform parent) {
        if (!barrelTimers.ContainsKey(barrel)) {
            barrelTimers.Add(barrel, defaultBarrelSpawnerTimer);
            barrelParents.Add(barrel, parent);
        }
    }

    public void RemoveBarrel(Vector3 barrel) {
        if (barrelTimers.ContainsKey(barrel)) {
            barrelTimers.Remove(barrel);
        }
    }

    public void SpawnExplosiveEffect(GameObject barrel) {
        GameObject explosiveEffectClone = Instantiate(explosiveEffect, barrel.transform.position, Quaternion.identity);
        Destroy(explosiveEffectClone, 5f);
    }
}
