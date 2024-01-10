using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour {

    [SerializeField] private GameObject[] enemiesPrefab;
    [SerializeField] private GameObject[] enemiesSpawnpoint;

    [SerializeField] private int baseEnemies = 3;
    [SerializeField] private float enemiesPerSecond = .5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyScalingFactor = .75f;

    public static UnityEvent OnEnemyDestroy = new UnityEvent();

    public int currentWave = 1;
    
    [Space]
    private float timeSinceLastSpawn;
    public int enemiesAlive;
    public int enemiesLeftToSpawn;
    public bool isSpawning = false;


    private void Awake() {
        OnEnemyDestroy.AddListener(() => EnemyDestroy());
    }

    private void Start() {
        UIManager.Instance.waveCounterText.text = "0 / 10";
    }

    private void Update() {
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0) {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0) {
            EndWave();
        }
    }

    private void EnemyDestroy() {
        enemiesAlive--;
    }

    public void StartWave() {
        StartCoroutine(StartWaveIE());
    }

    private IEnumerator StartWaveIE() {

        yield return new WaitForSeconds(timeBetweenWaves);

        UIManager.Instance.waveCounterText.text = currentWave.ToString() + " / 10";
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }
    private void EndWave() {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        if (enemiesPerSecond <= 1f) {
            enemiesPerSecond += .1f;
        } else {
            enemiesPerSecond = 1f;
        }

        StartCoroutine(StartWaveIE());
    }

    private void SpawnEnemy() {
        GameObject prefabToSpaw = enemiesPrefab[Random.Range(0, enemiesPrefab.Length)];
        Instantiate(prefabToSpaw, enemiesSpawnpoint[Random.Range(0, enemiesSpawnpoint.Length)].transform.position, Quaternion.identity);
    }

    private int EnemiesPerWave() {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }
}
