using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowSpawner : MonoBehaviour {
    [SerializeField] private GameObject bowPrefab;
    [SerializeField] private GameObject bowSpawnPoint;

    private void SpawnBow() {
        Instantiate(bowPrefab, bowSpawnPoint.transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "BowTrigger" || other.gameObject.name == "BowTrigger2") {
            SpawnBow();
            Destroy(gameObject);
        }
    }
}
