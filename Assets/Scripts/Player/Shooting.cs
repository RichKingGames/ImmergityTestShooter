using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class that controlls shooting and instantiate bullets.
/// </summary>
public class Shooting : MonoBehaviour
{
    public Transform FirePoint; //start point of bullet
    public GameObject BulletPrefab;
    public bool IsMobBullets = false; // who shooting? mob or player

    private float _damage; // bullet damage

    private float _fireRate = 0.2f; // time between shots
    private float _nextFire = 0.0F;

    private float _force = 10f; // bullet speed

    /// <summary>
    /// The method of player shooting.
    /// </summary>
    public void Shoot()
    {
        if (Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
           
            GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(FirePoint.up * _force, ForceMode2D.Impulse);

            bullet.GetComponent<Bullet>().IsMobBullets = IsMobBullets;
            bullet.GetComponent<Bullet>().Damage = _damage;
        }
    }

    /// <summary>
    /// The method of mobs shooting.
    /// </summary>
    public void MobShoot(float angle)
    {
        if (Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            FirePoint.rotation = Quaternion.Euler(0f, 0f, angle);
            GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(FirePoint.up * _force, ForceMode2D.Impulse);

            bullet.GetComponent<Bullet>().IsMobBullets = IsMobBullets;
            bullet.GetComponent<Bullet>().Damage = _damage;
        }
    }

    /// <summary>
    /// The method that set damage of bullet.
    /// </summary>
    public void SetDamage(float damage)
    {
        _damage = damage;
    }
}
