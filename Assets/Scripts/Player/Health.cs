using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The class controlls Health and healthBar of Game Unit(player/mobs)
/// </summary>

public class Health : MonoBehaviour
{
    private float _maxHealth;
    private float _currentHealth;

    private Image _healthBar;

    private void Start()
    {
        _healthBar = GetComponent<Image>();
    }

    /// <summary>
    /// The method that set max health of Game Unit. Invokes at Start.
    /// </summary>

    public void SetMaxHealth(float value)
    {
        _maxHealth = value;
        _currentHealth = value;
    }

    /// <summary>
    /// The method that invokes when Game Unity taking damage.
    /// </summary>
    public bool TakeDamage(float value)
    {
        if (_currentHealth <= value)
        {
            return false;
        }
        //refresh health and healthbar
        _currentHealth -= value;
        _healthBar.fillAmount = _currentHealth / _maxHealth; 
        return true;
    }
}
