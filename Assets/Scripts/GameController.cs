using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int wave = 1;

    [SerializeField] private GameObject DeathUI;
    [SerializeField] private GameObject WinUI;

    public void IncrementWave()
    {
        wave++;
    }

    public void Lose()
    {
        DeathUI.SetActive(true);
    }

    public void Win()
    {
         WinUI.SetActive(true);
    }
}
