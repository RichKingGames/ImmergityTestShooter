using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class that contain game properties.
/// </summary>
public static class GameProperties 
{
    public static float PlayerHealth = 2000f;
    public static float PlayerDamage = 200f;
    public static float MobsHealth = 200f;
    public static float MobsDamage = 100f;
    public static float SpawnTime  = 2f;

    /// <summary>
    /// The method that set game properties
    /// </summary>
    public static void SetProperties(float playerHealth, float playerDamage,
        float mobsHealth, float mobsDamage, float spawnTime)
    {
        PlayerHealth = playerHealth;
        PlayerDamage = playerDamage;
        MobsHealth = mobsHealth;
        MobsDamage = mobsDamage;
        SpawnTime = spawnTime;
    }
}

