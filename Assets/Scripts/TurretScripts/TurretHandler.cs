using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretHandler : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> turretRenderers = new List<SpriteRenderer>();
    [SerializeField] private List<Transform> muzzles = new List<Transform>();
    private enum Turrets { SmallTurret, MediumTurret, LargeTurret }
    [SerializeField] private Turrets currentTurret = Turrets.MediumTurret;
    public Vector3 currentMuzzle { get; private set; }

    private void Start()
    {
        MatchRendererToCurrentTurret();
    }

    private void Update()
    {
        MatchRendererToCurrentTurret();
    }
    private void MatchRendererToCurrentTurret()
    {
        switch (currentTurret)
        {
            case Turrets.SmallTurret:
                SwitchTurretRenderer(0);
                currentMuzzle = muzzles[0].position;
                break;
            case Turrets.MediumTurret:
                SwitchTurretRenderer(1);
                currentMuzzle = muzzles[1].position;
                break;
            case Turrets.LargeTurret:
                SwitchTurretRenderer(2);
                currentMuzzle = muzzles[2].position;
                break;
        }
    }
    private void SwitchTurretRenderer(int ListIndex)
    {
        for (int i = 0; i < turretRenderers.Count; i++)
        {
            turretRenderers[i].enabled = false;
        }
        turretRenderers[ListIndex].enabled = true;
    }
}
