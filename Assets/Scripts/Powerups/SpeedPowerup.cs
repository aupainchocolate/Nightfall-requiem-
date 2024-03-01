using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/SpeedPowerup")]

public class SpeedPowerup : PowerupEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {
       target.GetComponent<PlayerMovement>().moveSpeed += amount;
    }
}
