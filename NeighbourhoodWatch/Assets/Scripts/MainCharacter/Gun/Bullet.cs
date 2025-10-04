using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damageAmount = 10f;
    public float bulletSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
        // This is to prevent the bullet from staying spawned in forever if it doesn't hit any targets.
    }

    // Update is called once per frame
    private void Update()
    {

    }

    // Bullet Detection
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Brute
        if (other.gameObject.TryGetComponent(out BruteHealth bruteComponent))
        {
            bruteComponent.TakeDamage(damageAmount);
            Destroy(gameObject);
        }

        if (other.gameObject.TryGetComponent(out EnemyHealth enemyComponent))
        {
            Destroy(gameObject);
        }
    }
}