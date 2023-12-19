using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissileCollisions : MonoBehaviour
{
    private BaseScript baseScript;
    private SpriteRenderer spriteRenderer;
    private AudioController audioController;
    private Rigidbody2D rb;
    [SerializeField] private GameObject explosionEffect;
    private Color startingColor;
    [SerializeField] private float health;
    private float hitIndicatorDur = 0.1f;

    private void Awake()
    {
        audioController = GameObject.FindWithTag("AudioController").GetComponent<AudioController>();
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
            Death();
        }
       else if (collision.gameObject.tag == "Projectile")
        {
            Destroy(collision.gameObject);
            Damage();
        }
    }

    
    private void Death()
    {
        baseScript.DestroyedEnemy();
        audioController.Explosion();
        Destroy(Instantiate(explosionEffect, transform.position, Quaternion.identity), 0.5f);
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
