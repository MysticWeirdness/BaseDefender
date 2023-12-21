using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene3 : MonoBehaviour
{
    [SerializeField] private GameObject firework;

    private float xLim = 7f;
    private float yLim = 3.5f;
    private int amountToGenerate = 10;
    private int index = 0;

    private void Start()
    {
        StartCoroutine(Fireworks());
    }

    private IEnumerator Fireworks()
    {
        if(index >= amountToGenerate)
        {
            SceneManager.LoadSceneAsync(1);
        }
        Instantiate(firework, new Vector2(UnityEngine.Random.Range(-xLim, xLim), UnityEngine.Random.Range(-yLim, yLim)), Quaternion.identity);
        yield return new WaitForSeconds(1);
        StartCoroutine(Fireworks());
        index++;
    }
}
