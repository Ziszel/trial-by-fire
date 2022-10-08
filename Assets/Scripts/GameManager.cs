using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float restartDelay = 2.0f;
    // Start is called before the first frame update
    public void EndGame()
    {
        Debug.Log("You Won!");
        Invoke("Restart", restartDelay);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
