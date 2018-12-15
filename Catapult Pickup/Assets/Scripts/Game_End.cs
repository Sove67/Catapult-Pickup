using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Game_End : MonoBehaviour {
    public GameObject truck;
    public GameObject spawner;
    public GameObject road;
    public GameObject canvas;

	public void GameEnd() {
        SetScore();
        truck.SetActive(false);
        spawner.SetActive(false);
        spawner.GetComponent<Spawning>().enemies.Clear();
        road.GetComponent<Animator>().StopPlayback();
        canvas.SetActive(true);
    }

    public void SetScore()
    {
        PlayerPrefs.SetFloat("NewScore", (float)Math.Round(GameObject.Find("Spawning Controller").GetComponent<Spawning>().time, 1));
    }
}