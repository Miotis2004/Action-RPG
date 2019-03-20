using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar;

    private float currentHP;
    private float MaxHP;

    private CharacterStats stats;

    private void Awake()
    {
        stats = GetComponent<CharacterStats>();
    }

    private void Start()
    {
        UpdateHealthBar();
    }

    private void Update()
    {
        //FOR TESTING --- REMOVE THIS CODE!!!!!
        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage(5.0f);
        }
        if (Input.GetMouseButtonDown(1))
        {
            HealDamage(5.0f);
        }
    }

    public void TakeDamage(float amount)
    {
        stats.currentHP -= amount;
        UpdateHealthBar();
    }

    public void HealDamage(float amount)
    {
        stats.currentHP += amount;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthBar == null)
        {
            return;
        }

        MaxHP = stats.maxHP;
        currentHP = stats.currentHP;

        float ratio = currentHP / MaxHP;

        if (ratio < 0)
        {
            ratio = 0;
        }

        if (ratio > 100)
        {
            ratio = 100;
        }

        healthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

}
