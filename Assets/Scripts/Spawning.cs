using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour {
    public float time;

    public int roundTime;
    public int roundModifier;
    private int roundNum = 0;
    private bool roundStart = false;

    public GameObject spawnLocation;
    public GameObject skeleton;
    public List<GameObject> enemies = new List<GameObject>();


    void Update () {
        time += Time.deltaTime;
        if ((Mathf.FloorToInt(time) % roundTime) == 0 && !roundStart)
        {
            roundStart = true;
            roundNum += roundModifier;
            Round(roundNum);
        }
        if ((Mathf.FloorToInt(time) % roundTime) != 0 && roundStart)
        {
            roundStart = false;
        }
    }

    void Round(int num)
    {
        Vector3 position = spawnLocation.transform.position + new Vector3(Random.Range(0, 5), 0, 0);
        for (int i = 0; i < num; i++)
        {
            enemies.Add(Instantiate(skeleton, position, Quaternion.Euler(Vector3.zero)));
        }
    }
}