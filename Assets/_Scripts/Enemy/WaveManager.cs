using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
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
    public int LastWave;
    private float timeSinceLastSpawn;
    public int enemiesAlive;
    public int enemiesLeftToSpawn;
    public bool isSpawning = false;
    public bool loseCondition = false;

    [Space]

    [SerializeField] private GameObject[] fireWorksprefab;

    private void Awake()
    {
        OnEnemyDestroy.AddListener(() => EnemyDestroy());
    }

    private void Start()
    {
        UIManager.Instance.waveCounterText.text = "0 / " + LastWave.ToString();
    }

    private void Update()
    {
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0) {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }
        if (loseCondition) return;

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0 && currentWave == LastWave) {
            UIManager.Instance.UpdateText("WIN");
            return;
        }
        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0) {
            SpawnFireWorks();
            EndWave();
        }
    }

    private void EnemyDestroy()
    {
        enemiesAlive--;
    }

    public void StartWave()
    {
        StartCoroutine(StartWaveIE());
    }

    private IEnumerator StartWaveIE()
    {

        yield return new WaitForSeconds(timeBetweenWaves);

        UIManager.Instance.waveCounterText.text = currentWave.ToString() + " / 10";
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }
    private void EndWave()
    {
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

    private void SpawnEnemy()
    {
        GameObject prefabToSpaw = enemiesPrefab[Random.Range(0, enemiesPrefab.Length)];
        Instantiate(prefabToSpaw, enemiesSpawnpoint[Random.Range(0, enemiesSpawnpoint.Length)].transform.position, Quaternion.identity);
    }

    private void SpawnFireWorks()
    {
        StartCoroutine(Fireworks());
    }

    IEnumerator Fireworks()
    {
        foreach (GameObject item in fireWorksprefab) {
            item.SetActive(true);
        }

        yield return new WaitForSeconds(5f);

        foreach (GameObject item in fireWorksprefab) {
            item.SetActive(false);
        }
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }
}
