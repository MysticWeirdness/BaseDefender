using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    private float health = 0f;
    private float healthDecrement = 0.001f;
    private int enemiesDestroyed = 0;
    public bool isDead = false;
    private Transform spriteTransform;
    [SerializeField] private GameController gameController;
    [SerializeField] private AudioController audioController;
    [SerializeField] private MissileGenerator missileGenerator;

    private void Start()
    {
        spriteTransform = transform.GetComponentInChildren<Transform>();
    }
    public void Damage()
    {
        audioController.Heartbeat();
        health += 0.15f;
        if (health >= 0.5f)
        {
            Death();
        }
    }

    public void ResetEnemiesDestroyed()
    {
        enemiesDestroyed = 0;
    }
    public void DestroyedEnemy()
    {
        enemiesDestroyed++;
        gameController.EnemyDestroyed(enemiesDestroyed, missileGenerator.GetTotalEnemies());
        if (enemiesDestroyed == missileGenerator.GetTotalEnemies())
        {
            gameController.IncrementWave();
        }
    }
    private void FixedUpdate()
    {
        if(health > 0)
        {
            health = health - healthDecrement;
        }
    }

    public float GetHealth()
    {
        return health;
    }
    private void Death()
    {
        isDead = true;
        gameController.Lose();
        spriteTransform.gameObject.SetActive(false);
    }
}
