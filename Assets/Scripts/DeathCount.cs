using UnityEngine;
using UnityEngine.UI;

public class DeathCount : MonoBehaviour
{
    public Text deathCount;
    private void Update()
    {
        deathCount.text = (MainMenuManager.Language == "English") ? "Deaths: " + GameManager.DeathCount : "死亡人数: " + GameManager.DeathCount;
    }
}
