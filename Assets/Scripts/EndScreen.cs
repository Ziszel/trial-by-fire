using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public Text timer;
    public Text deathCount;
    public Text endMessage;
    public Text btnText;
    public Transform camera;
    public Button btn;

    private void Awake()
    {
        deathCount.text = "Deaths: " + GameManager.deathCount;
        timer.text = "BestTime: " + GameManager.bestTime;
        btn.onClick.AddListener(OnPlayAgainClick);
    }

    private void Update()
    {
        // If the camera has finished moving past the door, then draw the EndScreen
        if (camera.position.z > 0)
        {
            endMessage.enabled = true;
            timer.enabled = true;
            deathCount.enabled = true;
            btn.enabled = true;
            btnText.enabled = true;
        }
    }

    void OnPlayAgainClick()
    {
        FindObjectOfType<GameManager>().Reset();
    }
}
