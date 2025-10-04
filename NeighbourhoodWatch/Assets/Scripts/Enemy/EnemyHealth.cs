using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Bullet"))
        {
            Bullet bulletScript = other.GetComponent<Bullet>();
            float damageAmount = 100f;

            if (bulletScript != null)
            {
                damageAmount = bulletScript.damageAmount;
            }

            TakeDamage(damageAmount);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject, .1f);
        }
    }
}