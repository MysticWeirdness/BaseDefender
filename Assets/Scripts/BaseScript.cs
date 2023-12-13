using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    private uint health = 10;
    [SerializeField] private AudioController controller;

    public void Damage()
    {
        health--;
        if(health <= 0)
        {
            Death();
        }
        controller.Heartbeat();
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    public void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
