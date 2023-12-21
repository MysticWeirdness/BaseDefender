using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene2 : MonoBehaviour
{
    [SerializeField] Rigidbody2D m1;
    [SerializeField] Rigidbody2D m2;
    [SerializeField] Rigidbody2D m3;
    [SerializeField] Rigidbody2D m4;


    private void Start()
    {
        m1.velocity = Vector2.down * 3;
        m2.velocity = Vector2.down * 5;
        m3.velocity = Vector2.down * 4;
        m4.velocity = Vector2.down * 6;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadSceneAsync(8);
    }
}
