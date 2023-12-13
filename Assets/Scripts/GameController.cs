using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int wave = 1;

    public void IncrementWave()
    {
        wave++;
    }
}
