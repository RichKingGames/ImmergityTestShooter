using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class of bullets.
/// </summary>
public class Bullet : MonoBehaviour
{
    public GameObject HitEffect; // effect when bullet dies
    private float widthLimit = 20; // edge where bullet dies
    private float heightLimit = 10;

    public float Damage;

    public bool IsMobBullets = false;

    public void Update()
    {
        // Destroy bullets if x position is less than widthLimit
        if (transform.position.x < -widthLimit || transform.position.x > widthLimit)
        {
            Destroy(gameObject);
        }
        // Destroy bullets if y position is less than heightLimit
        else if (transform.position.y < -heightLimit || transform.position.y > heightLimit)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if player bullets collision with mobs
        if(collision.gameObject.tag == "Mob" && !IsMobBullets)
        {
            collision.gameObject.GetComponent<Mob>().TakeDamage(Damage);
            GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.3f);
            Destroy(gameObject);
        }
        // if mob bullets collision with player
        else if(collision.gameObject.tag == "Player" && IsMobBullets)
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(Damage);
            GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.3f);
            Destroy(gameObject);
        }   
    }
}
