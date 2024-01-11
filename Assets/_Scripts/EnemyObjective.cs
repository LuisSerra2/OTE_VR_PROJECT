using System;
using UnityEngine;

public class EnemyObjective : MonoBehaviour
{
    public HealthSystem _healthSystem;

    WaveManager waveManager;

    private void Start() {
        waveManager = FindObjectOfType<WaveManager>();
        _healthSystem = new HealthSystem(20);
    }

    private void Update() {
        if (_healthSystem != null) {
            if (_healthSystem.IsDead()) {
                waveManager.loseCondition = true;
                AudioSource audio = gameObject.transform.parent.GetComponent<AudioSource>();
                audio.Play();
                Destroy(gameObject);

                UIManager.Instance.UpdateText("LOSE");
            }
        }
    }
}
