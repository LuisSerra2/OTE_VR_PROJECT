using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour, IHittable {

    public void GetHit()
    {
        if (EnemyController.Instance != null) {
            EnemyController.Instance.BarrelExplode();
            Destroy(gameObject);
        }
    }
}
