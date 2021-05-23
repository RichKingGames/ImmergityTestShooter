using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class that controls mobs spawn.
/// </summary>
public class SpawnController : MonoBehaviour
{
    public List<GameObject> MobPrefabs = new List<GameObject>(); // all mobs variation

    // edges where mobs spawn
    private float widthMax = 15f; 
    private float widthMin = 10f;

    private float heightMax = 10f;
    private float heightMin = 6f;


    /// <summary>
    /// The method that start spawning mobs.
    /// </summary>
    public void SetSpawnProperties(float spawnTime)
    {
        InvokeRepeating("SpawnMobs", 0f, spawnTime);
    }

    [System.Obsolete]

    /// <summary>
    /// The method that spawning mobs.
    /// </summary>
    void SpawnMobs()
    {
        
        bool trigger = false;
        while(!trigger)
        {
            Vector2 pos = new Vector2(Random.RandomRange(-widthMax, widthMax), Random.RandomRange(-heightMax, heightMax));

            // if Random Vector2 in Screen Space do nothing 
            if(pos.x > -widthMin && pos.x < widthMin && pos.y > -heightMin && pos.y < heightMin)
            {
            }
            // else spawn mob and set parameters
            else
            { 
                int i = Random.RandomRange(0, MobPrefabs.Count);
                GameObject mob = Instantiate(MobPrefabs[i], pos, Quaternion.identity);
                mob.GetComponent<Mob>().SetMobProperties(GameProperties.MobsDamage, GameProperties.MobsHealth);

                trigger = true;
            }
        }
    }

    /// <summary>
    /// The method that interrupts invoke of mobs spawn
    /// </summary>
    public void StopSpawning()
    {
        CancelInvoke("SpawnMobs");
    }
}
