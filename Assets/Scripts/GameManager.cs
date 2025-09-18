using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public MeteorSpawner meteorSpawner;
    public bool gameOver = false;

  // Start is called before the first frame update
    private void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameOver)
        {
            meteorSpawner.StopSpawning();
        }

        if (Input.GetKeyDown(KeyCode.R) && gameOver)
        {
            RestartGame();
        }
    }

    private void SpawnPlayer()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
    
    private void RestartGame()
    {
        SceneManager.LoadScene("Week5Lab");
    }
}
