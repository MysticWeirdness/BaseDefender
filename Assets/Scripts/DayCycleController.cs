using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycleController : MonoBehaviour
{
    private bool isDay;
    private float duration = 10;

    [SerializeField] private GameObject spotlight;
    [SerializeField] private GameObject globalLight;

    private void Start()
    {
        DayMode();
 //       StartCoroutine(DayCycleTimer());
    }

    private IEnumerator DayCycleTimer()
    {
        yield return new WaitForSeconds(duration);
        ToggleDayCycle();
        StartCoroutine(DayCycleTimer());
    }
    public void ToggleDayCycle()
    {
        switch (isDay)
        {
            case true:
                NightMode();
                break;
            case false:
                DayMode();
                break;
        }
    }

    private void NightMode()
    {
        isDay = false;
        globalLight.SetActive(false);
        spotlight.SetActive(true);
    }

    private void DayMode()
    {
        isDay = true;
        globalLight.SetActive(true);
        spotlight.SetActive(false);
    }
}
