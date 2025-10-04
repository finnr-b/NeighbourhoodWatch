using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteHealth : MonoBehaviour
{
    public float health = 150f;
    public float maxHealth = 150f;

    [SerializeField] HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.UpdateHealthBar(health, maxHealth);
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
            float damageAmount = 25f;

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
        healthBar.UpdateHealthBar(health, maxHealth);

        if (health <= 0)
        {
            Destroy(gameObject, .1f);
        }
    }
}