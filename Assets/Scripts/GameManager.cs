using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Static forces any classes that inherit this class to refer to the same variable (Instance) declared here
    // https://learn.unity.com/tutorial/implement-data-persistence-between-scenes#60b7415aedbc2a5532d1331c
    // I've used this to persist the deathCount variable when reloading the scene after dying
    // In combination with the code inside of the Awake method, this is an example of the Singleton design pattern.
    public static GameManager Instance;
    public Player player;
    public static float timer = 0.0f;
    public static float bestTime;
    public static int deathCount = 0;
    private float sceneDelay = 2.0f;
    private bool stopTimer;

    private void Awake()
    {
        // If we already have an Instance, we don't want another gameObject.
        // This stops duplication on reloading of the scene
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // don't destroy the empty game object when loading a new scene
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            // neaten up the display when you finish a level
            if (!stopTimer) { timer += Time.deltaTime; }
        }
        /*else if (SceneManager.GetActiveScene().name == "level2")
        {
            // do nothing
        }
        */
    }

    public void EndGame()
    {
        Debug.Log("You Won!");
        player.setMove(false);
        bestTime = timer;
        stopTimer = true;
        FindObjectOfType<MusicController>().FadeAudio();
        Invoke("EndGameScene", sceneDelay);
    }

    private void EndGameScene()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Die()
    {
        Debug.Log("you died!");
        deathCount++;
        timer = 0.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Reset()
    {
        timer = 0.0f;
        deathCount = 0;
        stopTimer = false;
        SceneManager.LoadScene("Level1");
    }
}
