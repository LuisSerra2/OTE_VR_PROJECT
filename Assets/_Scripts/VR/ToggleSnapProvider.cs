using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleSnapProvider : MonoBehaviour
{
    [SerializeField] private Toggle _snapProvider;

    private static ToggleSnapProvider _instance;

    private void Awake() {
       
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        UpdateSnapTurnProviderState();
    }

    private void Update() {
        UpdateSnapTurnProviderState();
    }

    private void UpdateSnapTurnProviderState() {
        if (_snapProvider.isOn) {
            GameObject.Find("XR Origin").GetComponent<ActionBasedContinuousTurnProvider>().enabled = false;
            GameObject.Find("XR Origin").GetComponent<ActionBasedSnapTurnProvider>().enabled = true;
        } else {
            GameObject.Find("XR Origin").GetComponent<ActionBasedContinuousTurnProvider>().enabled = true;
            GameObject.Find("XR Origin").GetComponent<ActionBasedSnapTurnProvider>().enabled = false;
        }
    }
}
