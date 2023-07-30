using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "EnemyData")]
public class EnemyData : ScriptableObject 
{

    [Header("Enemy Damage Data")]
    public float normalEnemyDamage;
    public float fastEnemyDamage;
    public float slowEnemyDamage;
    public float exploderEnemyDamage;
}
