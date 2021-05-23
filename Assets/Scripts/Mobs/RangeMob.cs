using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class of arrow mob
/// </summary>
public class RangeMob : Mob
{
    //coefficients
    public override float DamageRatio => 1f; 
    public override float HealthRatio => 2f;
    public override float Speed => 1f;

    //shooting fields
    [SerializeField] private Shooting _shooting = null; // attached by inspector

    private float _rangeDistance = 5f; // distance at which the mob starts shooting
    private float _shootAngle;
    

    void Start()
    {
        base.Start();
        SetShootingAngle();
    }
    
    public override void FixedUpdate()
    {
        //if mob position more then his range distance. Walk to player
        if (Vector2.Distance(gameObject.transform.position, Player) > _rangeDistance)
        {
            Rb.transform.position = Vector2.MoveTowards(Rb.transform.position, Player, Speed * Time.deltaTime);
        }
        // if mob in range distance. Start shooting
        else
        {
            _shooting.MobShoot(_shootAngle);
        }
    }

    /// <summary>
    /// The method that set shooting damage and mob health.
    /// </summary>
    public override void SetMobProperties(float damage, float health)
    {
        Damage = DamageRatio * damage;
        _shooting.SetDamage(Damage);
        _shooting.IsMobBullets = true;

        health *= HealthRatio;
        Hp.SetMaxHealth(health);
    }

    /// <summary>
    /// The method that set angle from mob to player.
    /// </summary>
    private void SetShootingAngle()
    {
        Vector2 direction = Player - Rb.position;
        _shootAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
    }
}
