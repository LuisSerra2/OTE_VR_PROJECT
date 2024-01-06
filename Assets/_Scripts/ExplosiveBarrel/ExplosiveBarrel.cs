using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : Singleton<ExplosiveBarrel>, IHittable {

    public List<GameObject> enemiesInBarrelRange = new List<GameObject>();

    public void GetHit() {
        if (enemiesInBarrelRange.Count > 0) {
            EnemyController.Instance.BarrelExplode(this.gameObject);
            Destroy(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}
