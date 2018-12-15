using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deletion : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Truck")
        {
            Destroy(this.gameObject, 1f);
        }
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
    }
}