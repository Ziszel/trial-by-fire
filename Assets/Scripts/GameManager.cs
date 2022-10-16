using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Static forces any classes that inherit this class to refer to the same variable (Instance) declared here
    // https://learn.unity.com/tutorial/implement-data-persistence-between-scenes#60b7415aedbc2a5532d1331c
    // I've used this to persist the deathCount variable when reloading the scene after dying
    // In combination with the code inside of the Awake method, this is an example of the Singleton design pattern.
    public static GameManager Instance;
    
    public float timer = 0.0f;
    public int deathCount = 0;
    private float sceneDelay = 2.0f;

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
        timer += Time.deltaTime;
        Debug.Log(timer);
        Debug.Log(deathCount);
    }

    public void EndGame()
    {
        Debug.Log("You Won!");
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
}
