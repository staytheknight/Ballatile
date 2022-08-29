using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    [SerializeField] GameObject ship;
    [SerializeField] Score score;

    private TMP_Text tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ship == null && score.checkGameOver()) {
            string currentHighScore = PlayerPrefs.GetString("HighScore");
            tmp.text = "High Score: " + currentHighScore;
        }
    }
}
