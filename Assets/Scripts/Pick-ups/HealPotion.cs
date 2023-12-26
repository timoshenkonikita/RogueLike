using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : Pickup , ICollectable
{
    public int healthToRestore;

    public void Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.RestoreHealth(healthToRestore);
    }
}
