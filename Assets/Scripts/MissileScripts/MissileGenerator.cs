using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileGenerator : MonoBehaviour
{
    private float yGenerator = 6;
    private float xLimit = 12;
    private float duration = 1f;
    private int amountAlreadySpawned = 0;
    private int amountOfEnemies;
    private int monitorWave;

    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private GameController gameController;

    private void Start()
    {
        amountOfEnemies = gameController.wave * 10;
        StartCoroutine("MissileTimer");
    }

    public void OnNewWave()
    {
        amountAlreadySpawned = 0;
        amountOfEnemies = gameController.wave * 10;
    }

    private IEnumerator MissileTimer()
    {
        yield return new WaitForSeconds(duration);
        amountAlreadySpawned++;
        Instantiate(missilePrefab, new Vector3(UnityEngine.Random.Range(-xLimit, xLimit), yGenerator, 0f), Quaternion.identity);
        if(amountAlreadySpawned < amountOfEnemies)
        {
            StartCoroutine(MissileTimer());
        }
        else if(amountAlreadySpawned >= amountOfEnemies)
        {
            yield break;
        }
    }
}