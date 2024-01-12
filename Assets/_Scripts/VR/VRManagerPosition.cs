using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRManagerPosition : MonoBehaviour {
    [SerializeField] private AudioClip m_AudioSource;
    [SerializeField] private float audioVolume;
    [SerializeField] private bool restartAudio;
    private void Awake() {
        GameObject.Find("VRManager").transform.position = gameObject.transform.position;
        GameObject.Find("Camera Offset").GetComponent<AudioSource>().clip = m_AudioSource;
        if (restartAudio) {
            GameObject.Find("Camera Offset").GetComponent<AudioSource>().Play();
        }
        GameObject.Find("Camera Offset").GetComponent<AudioSource>().volume = audioVolume;
    }
}
