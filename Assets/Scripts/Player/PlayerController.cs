using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class of the player.
/// </summary>
public class PlayerController : GameUnit
{
    private Vector2 _mousePos;

    [SerializeField] private Shooting _shooting = null; // attached by inspector
    

    private void Start()
    {
        base.Start();
    }
    private void Update()
    {
        // Start shooting if left mouse button pushed
        if(Input.GetButton("Fire1"))
        {
            _shooting.Shoot();
        }
    }
    private void FixedUpdate()
    {
        //rotate to the mouse position
        SetRotation();
    }

    /// <summary>
    /// The method that invokes when mobs or mobs bullets collision with player.
    /// </summary>
    public override void TakeDamage(float value)
    {
        //if damage more then current health
        if (!Hp.TakeDamage(value))
        {
            GameController.instance.GameEnd("You Lose :(");
        }
    }

    /// <summary>
    /// The method that set player health and shooting damage
    /// </summary>
    public void SetPlayerProperties(float health, float damage)
    {
        Hp.SetMaxHealth(health);
        _shooting.SetDamage(damage);
    }

    /// <summary>
    /// The method that rotate player to the mouse position
    /// </summary>
    private void SetRotation()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = _mousePos - Rb.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Rb.rotation = angle;
    }
}
