using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magic : MonoBehaviour
{
    public Image magicBar;

    private float currentMP;
    private float MaxMP;

    private CharacterStats stats;

    private void Awake()
    {
        stats = GetComponent<CharacterStats>();
    }

    private void Start()
    {
        UpdateMagicBar();
    }

    private void Update()
    {
        //FOR TESTING --- REMOVE THIS CODE!!!!!
        if (Input.GetMouseButtonDown(0))
        {
            UseMagicPoints(5.0f);
        }
        if (Input.GetMouseButtonDown(1))
        {
            RestoreMagicPoints(5.0f);
        }
    }

    public void UseMagicPoints(float amount)
    {
        stats.currentMP -= amount;
        UpdateMagicBar();
    }

    public void RestoreMagicPoints(float amount)
    {
        stats.currentMP += amount;
        UpdateMagicBar();
    }

    private void UpdateMagicBar()
    {
        if (magicBar == null)
        {
            return;      
        }

        MaxMP = stats.maxMP;
        currentMP = stats.currentMP;

        float ratio = currentMP / MaxMP;

        if (ratio < 0)
        {
            ratio = 0;
        }

        if (ratio > 100)
        {
            ratio = 100;
        }

        magicBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

}
