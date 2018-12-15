using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour {
    public void ButtonStart()
    {
        SceneManager.LoadScene("Game");
    }
    public void ButtonHighscore()
    {
        SceneManager.LoadScene("Highscores");
    }
}
