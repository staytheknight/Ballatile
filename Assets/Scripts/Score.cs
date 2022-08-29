using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Globalization;
using System;
using TMPro;

public class Score : MonoBehaviour
{
    private Stopwatch watch;
    private TMP_Text tmp;
    private TimeSpan currentTime = new TimeSpan();

    [SerializeField] GameObject ship;
    [SerializeField] Canvas timer;
    [SerializeField] Camera switchCam;

    enum RenderModeStates { camera, overlay, world };
    RenderModeStates renderMode;

    private bool isGameOver = false;

    public bool checkGameOver()
    {
        return isGameOver;
    }

    private void Start()
    {
        watch = new Stopwatch();
        watch.Start();

        tmp = GetComponent<TMP_Text>();
        //timer = GetComponent<Canvas>();
    }

    private void Update()
    {
        currentTime = watch.Elapsed;

        if (!Application.isFocused)
        {
            watch.Stop();
        }

        if (Application.isFocused && !watch.IsRunning && !isGameOver)
        {
            watch.Start();
        }

        if (ship == null)
        {
            if (!isGameOver) {

                watch.Stop();
                timer.worldCamera = switchCam;
                tmp.rectTransform.anchoredPosition = new Vector2(0, 150);

                if (PlayerPrefs.HasKey("HighScore")) {
                    string currentHighScore = PlayerPrefs.GetString("HighScore");
                    CultureInfo culture = CultureInfo.CurrentCulture;
                    TimeSpan currentHSTime = TimeSpan.ParseExact(currentHighScore, @"mm\:ss\.ff", culture);
                    if (currentTime.CompareTo(currentHSTime) > 0)
                    {
                        PlayerPrefs.SetString("HighScore", currentTime.ToString(@"mm\:ss\.ff"));
                    }

                }
                else
                {
                    PlayerPrefs.SetString("HighScore", currentTime.ToString(@"mm\:ss\.ff"));
                }


                isGameOver = true;
            }                       
        }



        // Change the text on the text component.
        tmp.text = currentTime.ToString(@"mm\:ss\.ff");

    }
}
