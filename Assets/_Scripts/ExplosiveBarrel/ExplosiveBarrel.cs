using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : Singleton<ExplosiveBarrel>, IHittable {

    public List<GameObject> enemiesInBarrelRange = new List<GameObject>();

    public void GetHit() {
        ExplosiveBarrelManager.Instance.BarrelSpawnTimer(this.gameObject.transform.position);
        if (enemiesInBarrelRange.Count > 0) {
            EnemyController.Instance.BarrelExplode(this.gameObject);
            ExplosiveBarrelManager.Instance.SpawnExplosiveEffect(this.gameObject);
            Destroy(gameObject);
        } else {
            ExplosiveBarrelManager.Instance.SpawnExplosiveEffect(this.gameObject);
            Destroy(gameObject);
        }
    }

}
