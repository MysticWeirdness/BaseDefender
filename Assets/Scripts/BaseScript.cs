using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    private uint health = 10;

    public void Damage()
    {
        health--;
    }

    public void Update()
    {
        Debug.Log(health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
