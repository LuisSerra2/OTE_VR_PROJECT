using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : Singleton<EnemyController>, IHittable {
    public GameObject target;

    public NavMeshAgent agent;
    public int health = 2;

    private float countdown = 2;

    private EnemyManager enemyManager;
    private EnemyObjective enemyObjective;

    public HealthSystem _healthSystem;
    private CameraTakeDamageVisualEffect cameraTakeDamageVisualEffect;

    public bool isInsideBarrelRange;


    private void Start() {
        enemyManager = FindObjectOfType<EnemyManager>();
        enemyObjective = FindObjectOfType<EnemyObjective>();
        cameraTakeDamageVisualEffect = FindObjectOfType<CameraTakeDamageVisualEffect>();

        _healthSystem = new HealthSystem(health);
    }

    private void Update() {
        agent.SetDestination(target.transform.position);

        if (enemyObjective != null) {
            if (Vector3.Distance(gameObject.transform.position, enemyObjective.gameObject.transform.position) <= 2) {

                countdown -= Time.deltaTime;

                if (countdown <= 0) {
                    countdown = 2;
                    enemyObjective._healthSystem.TakeDamage(5);
                    cameraTakeDamageVisualEffect.CameraTakeDamageEffect();
                }
            }
        }
    }
    public void GetHit() {
        enemyManager.HitEnemy(gameObject);
        _healthSystem.TakeDamage(1);
    }

    public void BarrelExplode() {
        if (isInsideBarrelRange) {
            foreach (GameObject hit in enemyManager.enemiesInBarrelRange)
            enemyManager.HitEnemy(hit);
            _healthSystem.TakeDamage(2);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Trigger") {
            isInsideBarrelRange = true;
            enemyManager.enemiesInBarrelRange.Add(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Trigger") {
            isInsideBarrelRange = false;
            enemyManager.enemiesInBarrelRange.Remove(this.gameObject);
        }
    }
}
