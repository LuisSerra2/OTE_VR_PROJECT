using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {
    public Transform target;

    private void Update() {
        Vector3 lookAtPosition = new Vector3(target.position.x , transform.position.y, transform.position.z);
        transform.LookAt(lookAtPosition);
    }
}
