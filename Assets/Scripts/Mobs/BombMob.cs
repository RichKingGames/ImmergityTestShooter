using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class of melee Bomb mob.
/// </summary>
public class BombMob : Mob
{
    //coefficients
    public override float DamageRatio => 3f;
    public override float HealthRatio => 1f; 
    public override float Speed => 3f;

    

    public override void FixedUpdate()
    {
        // Walking to player.
        if (Vector2.Distance(gameObject.transform.position, Player) > 0.5f)
        {
            Rb.transform.position = Vector2.MoveTowards(Rb.transform.position, Player, Speed * Time.deltaTime);
        }
    }

    /// <summary>
    /// The method that set bomb mob damage and health.
    /// </summary>
    public override void SetMobProperties(float damage, float health)
    {
        Damage = DamageRatio * damage;
        health *= HealthRatio;
        Hp.SetMaxHealth(health);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Done damage to player and self destroy when collision with player.
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
    
}
