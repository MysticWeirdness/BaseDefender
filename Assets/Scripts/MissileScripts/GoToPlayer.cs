using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPlayer : MonoBehaviour
{
    private Transform playerLocation;
    private BaseScript baseScript;
    private float missileSpeed = 1f;
    private float rotZ;
    private Vector3 diff;

    private void Start()
    {
        baseScript = GameObject.FindWithTag("Base").GetComponent<BaseScript>();
        playerLocation = GameObject.FindWithTag("Base").GetComponent<Transform>();
    }
    private void Update()
    {
        if (!baseScript.isDead)
        {
            diff = playerLocation.position - transform.position;
            diff.Normalize();
            rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 90);
            transform.position += (transform.up) * -1 * missileSpeed * Time.deltaTime;

        }
    }
}
