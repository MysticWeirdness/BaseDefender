using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] FollowMouse followMouse;
    [SerializeField] TurretHandler turretHandler;
    [SerializeField] private GameObject projectile;

    private float cooldownDuration = 0.1f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine("Cooldown");
        }
    }

    private IEnumerator Cooldown()
    {
        Destroy(Instantiate(projectile, turretHandler.currentMuzzle, Quaternion.Euler(0f, 0f, followMouse.rotZ - 90)), 2f);
        yield return new WaitForSeconds(cooldownDuration);
    }
}
