using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseHealth : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
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

    // Enemy Detection

    private void OnTriggerEnter2D(Collider2D other)
    {
        float damageAmount = 0;
        bool isEnemy = false;

        // Basic Enemy
        {
            EnemyWalk enemyWalkScript = other.GetComponent<EnemyWalk>();

            if (enemyWalkScript != null)
            {
                isEnemy = true;
                damageAmount = enemyWalkScript.damageAmount;
            }

            if (isEnemy)
            {
                TakeDamage(damageAmount);
                healthBar.UpdateHealthBar(health, maxHealth);
            }
        }

        // The Brute
        {
            BruteWalk bruteWalkScript = other.GetComponent<BruteWalk>();

            if (bruteWalkScript != null)
            {
                isEnemy = true;
                damageAmount = bruteWalkScript.damageAmount;
            }

            if (isEnemy)
            {
                TakeDamage(damageAmount);
                healthBar.UpdateHealthBar(health, maxHealth);
            }
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver"); // :(
        }
    }
}