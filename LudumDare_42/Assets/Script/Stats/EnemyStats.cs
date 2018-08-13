using UnityEngine;

[System.Serializable]
public class EnemyStats
{
    public bool isBoss;
    public int maxHitpoint;
    public int damage;
    public int hitpoint;
    public float attackSpeed;
    public float moveSpeed;
    public float projectileDecay = 2.0f;
    public float range;
    public float rangeOfChase;
}
