using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleSnapProvider : MonoBehaviour
{
    [SerializeField] private Toggle _snapProvider;

    private void Update() {
        if (_snapProvider.isOn) {
            GameObject.Find("XR Origin").GetComponent<ActionBasedContinuousTurnProvider>().enabled = false;
            GameObject.Find("XR Origin").GetComponent<ActionBasedSnapTurnProvider>().enabled = true;   
        } else {
            GameObject.Find("XR Origin").GetComponent<ActionBasedContinuousTurnProvider>().enabled = true;
            GameObject.Find("XR Origin").GetComponent<ActionBasedSnapTurnProvider>().enabled = false;
        }
    }
}
