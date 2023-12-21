using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController1 : MonoBehaviour
{
    public int wave = 6;

    [SerializeField] private GameObject DeathUI;
    [SerializeField] private GameObject WinUI;
    [SerializeField] private GameObject HUD;
    [SerializeField] private UIHandler UIHandler;
    [SerializeField] private MissileGenerator1 missileGenerator;
    [SerializeField] private BaseScript1 baseScript;
    public void IncrementWave()
    {
        if(wave >= 5)
        {
            Win();
        }
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
        SceneManager.LoadSceneAsync(7);
    }

    public void Win()
    {
        SceneManager.LoadSceneAsync(8);
    }
}