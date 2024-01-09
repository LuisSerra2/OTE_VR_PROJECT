using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bowPrefab;

    private void SpawnBow() {
        Instantiate(bowPrefab);
    }

    private void OnTriggerEnter(Collider other) {
        SpawnBow();
        Destroy(gameObject, 1f);
    }
}
