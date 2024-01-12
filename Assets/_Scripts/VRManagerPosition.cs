using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRManagerPosition : MonoBehaviour
{
    private void Awake() {
        GameObject.Find("VRManager").transform.position = gameObject.transform.position;
    }
}
