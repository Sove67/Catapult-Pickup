using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thank_You : MonoBehaviour {
    public GameObject footer;
    void Awake() {
        if (PlayerPrefs.GetFloat("FullAdCount") > 0 || PlayerPrefs.GetFloat("PartialAdCount") > 0)
        {
            footer.GetComponent<Text>().text = ("You have fully watched " + PlayerPrefs.GetFloat("FullAdCount").ToString() + " advertisements, and partially watched " + PlayerPrefs.GetFloat("PartialAdCount").ToString() + ". Thank You!");
            footer.transform.parent.gameObject.SetActive(true);
        }
    }
}