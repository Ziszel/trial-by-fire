using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Static forces any classes that inherit this class to refer to the same variable (Instance) declared here
    // https://learn.unity.com/tutorial/implement-data-persistence-between-scenes#60b7415aedbc2a5532d1331c
    // I've used this to persist the deathCount variable when reloading the scene after dying
    // In combination with the code inside of the Awake method, this is an example of the Singleton design pattern.
    public static GameManager Instance;
    public Player player;
    public static float Timer = 0.0f;
    public static float BestTime;
    public static int DeathCount = 0;
    private const float SceneDelay = 2.0f;
    private bool _stopTimer;
    
    private void Awake()
    {
        // If we already have an Instance, we don't want another gameObject.
        // This stops duplication on reloading of the scene
        if (Instance != null)
        {
            // We already have an instance so destroy the newly created one.
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
            if (!_stopTimer) { Timer += Time.deltaTime; }
        }
    }

    public void EndGame()
    {
        player.SetMove(false); // stop the player from moving
        // make the final time (bestTime) = to the current time and stop the timer and music.
        BestTime = Timer;
        _stopTimer = true;
        FindObjectOfType<MusicController>().FadeAudio();
        Invoke("EndGameScene", SceneDelay); // Call the EndGameScene, delayed by sceneDelay
    }

    private void EndGameScene()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Die()
    {
        // When the player dies increment the death count, reset the timer and reload the scene
        DeathCount++;
        Timer = 0.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Reset()
    {
        // The same as 'Die', but this method will reset the death count and restart the timer
        // Level1 alludes to this scene, but this method is safe to call from other scenes because it is explicit
        Timer = 0.0f;
        DeathCount = 0;
        _stopTimer = false;
        SceneManager.LoadScene("Level1");
    }
}
