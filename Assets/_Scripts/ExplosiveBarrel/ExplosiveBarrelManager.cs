using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrelManager : Singleton<ExplosiveBarrelManager>
{
    [SerializeField] private GameObject explosiveBarrelPrefab;
    [SerializeField] private GameObject[] explosiveBarrelSpawnPosition;

    [SerializeField] private GameObject explosiveEffect;


    public void SpawnExplosiveEffect(GameObject barrel) {
        GameObject explosiveEffectClone = Instantiate(explosiveEffect, barrel.transform.position, Quaternion.identity);

        Destroy(explosiveEffectClone, 5f);
    }
}
