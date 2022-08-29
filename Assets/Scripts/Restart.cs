using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Button restartButton;
    public GameObject shipSpawn;

    Vector3 startPos = new Vector3(-5, -6, 0);

    private void Start()
    {
        RestartPress();
    }

    void RestartPress()
    {
        restartButton.onClick.AddListener(RestartGame);       
      
       
    }

    void SpawnShip()
    {
        Instantiate(shipSpawn, startPos, Quaternion.identity);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
