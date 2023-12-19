using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] TextMeshProUGUI enemiesLeft;

    public void UpdateWave(int wave)
    {
        waveText.text = "Wave: " + wave.ToString();
    }

    public void UpdateEnemiesLeft(int enemiesDestroyed, int totalEnemies)
    {
        enemiesLeft.text = "Enemies Left: " + (totalEnemies - enemiesDestroyed).ToString();
    }
}
