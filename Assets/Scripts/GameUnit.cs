using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The main class of all game units (mobs or player).
/// </summary>
public abstract class GameUnit : MonoBehaviour
{
    public Rigidbody2D Rb { private set; get; }
    public Health Hp; //attached by inspector
    public void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// The method that invokes when player or mob taking damage
    /// </summary>
    public abstract void TakeDamage(float value);
   
}
