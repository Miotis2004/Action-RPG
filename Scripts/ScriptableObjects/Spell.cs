using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spell")]
public class Spell : ScriptableObject {

    [Header("Spell Info")]
    public string spellName;
    public string description;
    public Sprite icon;

    [Header("Spell Stats")]
    public float range;
    public float damage;

    public int manaCost;

}
