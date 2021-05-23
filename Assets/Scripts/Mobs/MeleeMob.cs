using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class of melee soldier mob.
/// </summary>
public class MeleeMob : Mob
{
    //coefficients
    public override float DamageRatio => 2f;
    public override float HealthRatio => 3f;
    public override float Speed => 1f;

    private float _attackRate = 1f; // time between attacks
    private float _nextAttack = 0f;

    public override void FixedUpdate()
    {
        //Walking to player
        if (Vector2.Distance(gameObject.transform.position, Player) > 0.5f)
        {
            Rb.transform.position = Vector2.MoveTowards(Rb.transform.position, Player, Speed * Time.deltaTime);
        }
    }

    /// <summary>
    /// The method that set melee mob damage and health.
    /// </summary>
    public override void SetMobProperties(float damage, float health)
    {
        Damage = DamageRatio * damage;
        health *= HealthRatio;
        Hp.SetMaxHealth(health);
    }
    

    private void OnCollisionStay2D(Collision2D collision)
    {
        // damages the player if the mob approached him
        if (collision.gameObject.tag == "Player")
        {
            Attack(collision.gameObject);
        }
    }

    /// <summary>
    /// The method that damages the player by attack rate.
    /// </summary>
    private void Attack(GameObject enemy)
    {   
        if(Time.time > _nextAttack)
        {
            _nextAttack = Time.time + _attackRate;
            enemy.GetComponent<PlayerController>().TakeDamage(Damage);
        }
        
    }
}
