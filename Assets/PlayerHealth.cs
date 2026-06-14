using System;
using System.Collections;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth = 3;
    private float health;
    private bool canRecieveDamage = true;
    public float invincibilityTimer = 2;

    public delegate void HealthChangedHandler(float health, float amountChanged);
    public event HealthChangedHandler OnHealthChanged;

    public delegate void HealthInitHandler(float newHealth);
    public event HealthInitHandler OnHealthInit;

    void Start()
    {
        health = MaxHealth;
        OnHealthInit?.Invoke(health);
    }
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kolec"))
        {
            AddDamage(1f);
        }
    }

    public void AddDamage(float damage)
    {
        if (canRecieveDamage)
        {
            health -= damage;
            OnHealthChanged?.Invoke(health, -damage);
            canRecieveDamage = false;
            StartCoroutine(InvincibilityTimer(invincibilityTimer, ResetInvincibility));
            Debug.Log("AUA! Zostało mi: " + health + " zdrowia");

            if (health <= 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }
    }

    IEnumerator InvincibilityTimer(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }

    private void ResetInvincibility()
    {
        canRecieveDamage = true;
        Debug.Log("reset");
    }
    public void AddHealth(float heal)
    {
        health += heal;
        OnHealthChanged?.Invoke(health, heal);
        Debug.Log(health);
    }

    public class PlayerStats
    {
        private float currentHealth;
        public event Action<float> OnHealthInitialized;
        
        public void InitializeHealth(float startAmount)
            { currentHealth = startAmount; 
        OnHealthInitialized?.Invoke(currentHealth);
            Console.WriteLine("Øycie zosta≥o zainicjowane");
        }

    }
}
