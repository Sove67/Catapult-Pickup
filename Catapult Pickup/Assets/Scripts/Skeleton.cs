using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour {
    public int moveSpeed;
    public GameObject gameEnd;

    private void Start()
    {
        gameEnd = GameObject.Find("Game End");
    }

    void Update () {
        this.transform.position += new Vector3(moveSpeed*.01f, 0, 0);	
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y, Mathf.Clamp(this.transform.rotation.z, -20, 20));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Truck")
        {
            gameEnd.GetComponent<Game_End>().GameEnd();
        }
    }
}
