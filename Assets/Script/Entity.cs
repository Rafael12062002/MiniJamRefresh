using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe de entidade para separar os atributos dos outros scripts de personagem
[Serializable]
public class Entity
{
    [Header("Name")]
    public string name;

    [Header("health")]
    public int health;

    public int maxHealth;
}
