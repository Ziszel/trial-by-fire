using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCount : MonoBehaviour
{
    public GameManager gm;
    public Text deathCount;
    void Update()
    {
        deathCount.text = "Deaths: " + gm.deathCount;
    }
}
