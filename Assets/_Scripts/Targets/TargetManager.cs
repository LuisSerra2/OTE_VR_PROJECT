using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TargetManager : Singleton<TargetManager>
{
    [SerializeField] private GameObject target;

    private Dictionary<Vector3, float> targetTimers = new Dictionary<Vector3, float>();
    private Dictionary<Vector3, Transform> targetParents = new Dictionary<Vector3, Transform>();

    private float defaultTargetSpawnerTimer = 15f;

    private void Update() {
        List<Vector3> targetToRemove = new List<Vector3>();

        foreach (var targetPos in new List<Vector3>(targetTimers.Keys)) {
            targetTimers[targetPos] -= Time.deltaTime;
            if (targetTimers[targetPos] <= 0) {
                SpawnTarget(targetPos, targetParents[targetPos]);
                targetToRemove.Add(targetPos);
            }
        }

        foreach (var targetPos in targetToRemove) {
            targetTimers.Remove(targetPos);
            targetParents.Remove(targetPos);
        }
    }

    private void SpawnTarget(Vector3 position, Transform parent) {
        Instantiate(target, position, Quaternion.identity, parent);
    }

    public void DestroyTarget(GameObject target) {
        Destroy(target, 5f);
    }

    public void TargetSpawnTimer(Vector3 target, Transform parent) {
        if (!targetTimers.ContainsKey(target)) {
            targetTimers.Add(target, defaultTargetSpawnerTimer);
            targetParents.Add(target, parent);
        }
    }

    public void RemoveTarget(Vector3 target) {
        if (targetTimers.ContainsKey(target)) {
            targetTimers.Remove(target);
        }
    }
}
