using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    private float health = 0f;
    private float healthDecrement = 0.001f;
    public bool isDead = false;
    private Transform spriteTransform;
    [SerializeField] private GameController gameController;
    [SerializeField] private AudioController controller;

    private void Start()
    {
        spriteTransform = transform.GetComponentInChildren<Transform>();
    }
    public void Damage()
    {
        controller.Heartbeat();
        health += 0.15f;
        if (health >= 0.5f)
        {
            Death();
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
