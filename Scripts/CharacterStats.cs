using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

    [Header("General")]
    public string characterName;
    public int level;
    public bool isDead;

    [Header("Hit/Magic Points")]
    public float currentHP;
    public float maxHP;

    public float currentMP;
    public float maxMP;

    public float hpRegenTimer;
    public float hpRegenAmount;

    public float mpRegenTimer;
    public float mpRegenAmount;

    [Header("Attack/Defense")]
    public float baseAttackPower;
    public float currentAttackPower;
    public float baseAttackSpeed;
    public float currentAttackSpeed;

    public float baseDefense;
    public float currentDefense;

    [Header("Stats")]
    public int strength;
    public int intelligence;
    public int wisdom;
    public int dexterity;
    public int constitution;

    [Header("Experience Points")]
    public float currentXP;
    public float maxXP;
}
