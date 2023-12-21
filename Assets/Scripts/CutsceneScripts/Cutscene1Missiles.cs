using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene1Missiles : MonoBehaviour
{
    [SerializeField] private Transform m1;
    [SerializeField] private Transform m2;
    [SerializeField] private SpriteRenderer flashbang;
    private Rigidbody2D m1rb;
    private Rigidbody2D m2rb;
    private float speed = 1.0f;

    private void Start()
    {
        flashbang.enabled = false;   
        m1rb = m1.GetComponent<Rigidbody2D>();
        m2rb = m2.GetComponent<Rigidbody2D>();
        m1rb.velocity = Vector2.right * speed;
        m2rb.velocity = Vector2.left * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "missile")
        {
            flashbang.enabled = true;
            StartCoroutine(LoadNextScene());
        }
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync(5);
    }
}
