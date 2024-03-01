using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Powerups/HealthPowerup")]
public class HealthPowerup : PowerupEffect

{
    public float amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<CharacterHealth> ().health.value += amount;
    }
}