using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {
    public InputField Username;
    private int SelectedScore;
    private void Awake()
    {
        for (int i = 1; i < 5; i++)
        {
            if ((PlayerPrefs.GetFloat("Score" + i.ToString()) < PlayerPrefs.GetFloat("NewScore")))
            {
                for (int x = 4; x >= 1; x--)
                {
                    PlayerPrefs.SetFloat("Score" + (x + 1).ToString(), PlayerPrefs.GetFloat("Score" + x.ToString()));
                    PlayerPrefs.SetString("Name" + (x + 1).ToString(), PlayerPrefs.GetString("Name" + x.ToString()));
                }
                PlayerPrefs.SetFloat("Score" + i.ToString(), PlayerPrefs.GetFloat("NewScore"));
                SelectedScore = i;
                break;
            }
        }
        PlayerPrefs.SetFloat("NewScore", 0);
    }

    public void Update()
    {
        PlayerPrefs.SetString("Name" + SelectedScore.ToString(), Username.text.ToString());
        GameObject.Find("Score 1").GetComponent<Text>().text = (PlayerPrefs.GetString("Name1") + " - " + PlayerPrefs.GetFloat("Score1").ToString() + "s");
        GameObject.Find("Score 2").GetComponent<Text>().text = (PlayerPrefs.GetString("Name2") + " - " + PlayerPrefs.GetFloat("Score2").ToString() + "s");
        GameObject.Find("Score 3").GetComponent<Text>().text = (PlayerPrefs.GetString("Name3") + " - " + PlayerPrefs.GetFloat("Score3").ToString() + "s");
        GameObject.Find("Score 4").GetComponent<Text>().text = (PlayerPrefs.GetString("Name4") + " - " + PlayerPrefs.GetFloat("Score4").ToString() + "s");
    }

    public void Clear()
    {
        SelectedScore = 0;
        PlayerPrefs.SetFloat("Score1", 0);
        PlayerPrefs.SetFloat("Score2", 0);
        PlayerPrefs.SetFloat("Score3", 0);
        PlayerPrefs.SetFloat("Score4", 0);
        PlayerPrefs.SetString("Name1", "Empty");
        PlayerPrefs.SetString("Name2", "Empty");
        PlayerPrefs.SetString("Name3", "Empty");
        PlayerPrefs.SetString("Name4", "Empty");
    }
}
