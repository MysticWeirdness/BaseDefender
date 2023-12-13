using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissileCollisions : MonoBehaviour
{
    private BaseScript baseScript;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Color startingColor;
    private float health = 3;
    private float hitIndicatorDur = 0.1f;

    private void Awake()
    {
        spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        startingColor = spriteRenderer.color;
        baseScript = GameObject.FindWithTag("Base").GetComponent<BaseScript>();
    }

    private void Update()
    {
        if(health <= 0)
        {
            Death();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Base")
        {
            baseScript.Damage();
            Destroy(gameObject);
        }
       else if (collision.gameObject.tag == "Projectile")
        {
            Destroy(collision.gameObject);
            Damage();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
    private void Damage()
    {
        health--;
        StartCoroutine("HitIndicator");
    }
    private IEnumerator HitIndicator()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(hitIndicatorDur);
        spriteRenderer.color = startingColor;
    }
}
