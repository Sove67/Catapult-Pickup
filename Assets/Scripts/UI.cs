using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class UI : MonoBehaviour {
    public void ButtonStart()
    {
        SceneManager.LoadScene("Game");
    }
    public void ButtonHighscore()
    {
        SceneManager.LoadScene("Highscores");
    }
    public void Restart()
    {
        PlayerPrefs.Save();
        StartCoroutine("Ads");
    }

    IEnumerator Ads()
    {
        if (!Advertisement.IsReady())
        {
            yield return new WaitForSeconds(1);
        }

        if (Advertisement.IsReady())
        {
            Advertisement.Show(new ShowOptions() { resultCallback = HandleShowResult });
            PlayerPrefs.SetFloat("AdCount", (PlayerPrefs.GetFloat("AdCount") + 1));
            yield return new WaitUntil(() => !Advertisement.isShowing);
        }

        SceneManager.LoadScene("Game");
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                PlayerPrefs.SetFloat("FullAdCount", PlayerPrefs.GetFloat("FullAdCount") + 1);
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                PlayerPrefs.SetFloat("PartialAdCount", PlayerPrefs.GetFloat("PartialAdCount") + 1);
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
}
