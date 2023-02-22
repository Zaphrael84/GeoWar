using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour

{
    public Image healthBare; 
    public bool isTakingDamage;
    public float damageTimeOut = 1f;
    public int health;
    public int maxHealth = 20;
    public int heal = 5;
    public Slider slider;
    public Gradient gradient;
    public Image fill;


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
        if (col.CompareTag("UsableFiole"))
        {
            TakeHeal();
        }

        if (col.CompareTag("EnnemyWeapon") && !isTakingDamage)
        {
            TakeDamage();

            if (health == 0)
            {
                Application.Quit();
            }
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
        health -= 3;
        slider.value = health;
        StartCoroutine(TakingDamage());
    }
    
    private void TakeHeal()
    {
        health += 5;
        slider.value = health;
        StartCoroutine(TakingHeal());
    }
    
    private IEnumerator TakingHeal()
    {
        isTakingDamage = false;
        yield return new WaitForSeconds(5f);
        isTakingDamage = true;
        StartCoroutine(TakingHeal());

    }


    
}
