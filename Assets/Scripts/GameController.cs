using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int wave = 1;

    [SerializeField] private GameObject DeathUI;
    [SerializeField] private GameObject WinUI;
    [SerializeField] private GameObject HUD;
    [SerializeField] private UIHandler UIHandler;
    [SerializeField] private MissileGenerator missileGenerator;
    [SerializeField] private BaseScript baseScript;
    public void IncrementWave()
    {
        wave++;
        UIHandler.UpdateWave(wave);
        missileGenerator.OnNewWave();
        baseScript.ResetEnemiesDestroyed();
        UIHandler.UpdateEnemiesLeft(0, wave * 10);
    }

    public void EnemyDestroyed(int enemiesDestroyed, int totalEnemies)
    {
        UIHandler.UpdateEnemiesLeft(enemiesDestroyed, totalEnemies);
    }
    public void Lose()
    {
        DeathUI.SetActive(true);
    }

    public void Win()
    {
         WinUI.SetActive(true);
    }
}
