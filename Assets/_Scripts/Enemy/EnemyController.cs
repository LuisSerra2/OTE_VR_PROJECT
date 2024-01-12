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
    private WaveManager waveManager;

    public HealthSystem _healthSystem;
    private CameraTakeDamageVisualEffect cameraTakeDamageVisualEffect;

    [Header("Audio")]
    [SerializeField] private AudioSource[] enemyAudio;


    private void Start() {
        enemyManager = FindObjectOfType<EnemyManager>();
        enemyObjective = FindObjectOfType<EnemyObjective>();
        cameraTakeDamageVisualEffect = FindObjectOfType<CameraTakeDamageVisualEffect>();
        waveManager = FindObjectOfType<WaveManager>();

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
        enemyManager.HitEnemy(gameObject, 1, enemyAudio[0], enemyAudio[1]);
    }

    public void BarrelExplode(GameObject barrel) {
        if (barrel.GetComponent<ExplosiveBarrel>().enemiesInBarrelRange.Count > 0) {

            List<GameObject> enemiesToRemove = new List<GameObject>(barrel.GetComponent<ExplosiveBarrel>().enemiesInBarrelRange);

            foreach (GameObject hit in enemiesToRemove) {
                enemyManager.HitEnemy(hit, 2, enemyAudio[0], enemyAudio[1]);
                barrel.GetComponent<ExplosiveBarrel>().enemiesInBarrelRange.Remove(hit);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Trigger") {
            other.gameObject.transform.parent.GetComponent<ExplosiveBarrel>().enemiesInBarrelRange.Add(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Trigger") {
            other.gameObject.transform.parent.GetComponent<ExplosiveBarrel>().enemiesInBarrelRange.Remove(this.gameObject);
        }
    }
}
