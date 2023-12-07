using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerLocation;

    private float missileSpeed = 1f;
    private float rotZ;
    private Vector3 diff;

    private void Update()
    {
        diff = playerLocation.position - transform.position;
        diff.Normalize();
        rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 90);
        transform.position += (transform.up) * -1 * missileSpeed * Time.deltaTime;
    }
}
