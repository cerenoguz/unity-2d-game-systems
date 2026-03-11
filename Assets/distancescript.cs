using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using System;
public class distancescript : MonoBehaviour
{

    public TMP_Text highScoreText;

    private void Start()
    {

        HighScoreSettings.highScore =  PlayerPrefs.GetFloat("highscore", 0);

        if (highScoreText != null)
        {
            highScoreText.text = HighScoreSettings.highScore.ToString("0");
        }
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
