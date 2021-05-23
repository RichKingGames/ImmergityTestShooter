using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The main class of all mobs.
/// </summary>
public abstract class Mob : GameUnit
{
    public float Damage { internal set; get; }

    //coefficients
    public abstract float DamageRatio { get; }
    public abstract float HealthRatio { get; }
    public abstract float Speed { get; }

    //position of the player
    public Vector2 Player = new Vector2(0, 0);

    private void Start()
    {
        base.Start();
    }

    //overrides by another mobs classes
    public abstract void FixedUpdate();

    //overrides by another mobs classes
    public abstract void SetMobProperties(float damage, float health);

    /// <summary>
    /// The method invokes when mobs taking damage.
    /// </summary>
    public override void TakeDamage(float value)
    {
        //if damage more then current mob health
        if(!Hp.TakeDamage(value))
        {
            // Set Score
            Score.instance.SetScore(100);
            Destroy(gameObject);
        }      
    }
    
}
