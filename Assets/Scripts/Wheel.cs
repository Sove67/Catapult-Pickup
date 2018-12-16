using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour {
    public float rotateSpeed = 2.5f;
    private Vector3 zAxis = new Vector3(0, 0, 1);

    private void Update()
    {
        this.transform.RotateAround(this.transform.position, zAxis, rotateSpeed);
    }
}
