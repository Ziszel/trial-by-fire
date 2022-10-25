using UnityEngine;
using UnityEngine.UI;

public class DeathCount : MonoBehaviour
{
    public Text deathCount;
    void Update()
    {
        deathCount.text = (MainMenuManager.language == "English") ? "Deaths: " + GameManager.deathCount : "死亡人数: " + GameManager.deathCount;
    }
}
