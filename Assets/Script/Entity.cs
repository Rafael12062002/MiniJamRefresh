using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Entity
{
    [Header("Name")]
    public string name;

    [Header("health")]
    public int health;

    public int maxHealth;
}
