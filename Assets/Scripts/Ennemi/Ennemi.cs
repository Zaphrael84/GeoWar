using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ennemi : MonoBehaviour
{

    public Image healthBare; 
    public bool isTakingDamage;
    public float damageTimeOut = 1f;
    public int health;
    public int maxHealth = 10;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public GameObject deathEffect;
    // Start is called before the first frame update
    private void Start()
    {
        health = maxHealth;
        SetMaxHealth(health);
    }

    private void SetMaxHealth(int health)
    {
        slider.maxValue = maxHealth;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("PlayerWeapon") && !isTakingDamage)
        {
            TakeDamage();

        }
    }
    
    private IEnumerator TakingDamage()
    {
        isTakingDamage = false;
        yield return new WaitForSeconds(damageTimeOut);
        isTakingDamage = true;
        StartCoroutine(TakingDamage());

    }
    
    private void TakeDamage()
    {
        health -= 5;
        slider.value = health;
        StartCoroutine(TakingDamage());
        if (health <= 0)
        {
            Die();
        }

    }
    
    private void Die()
    {
        GameObject deathParticles = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deathParticles, 2f);

        waveSpawner.EnnemisAlive--;
        
        Destroy((gameObject));
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
