using UnityEngine;

[System.Serializable]
public class CharacterStats
{
    public bool isInvulnerable = false;
    public float moveSpeed;
    public int maxHitpoint;
    public int hitpoint;
    public int fuel;
    public int maxFuel;
    public float attackSpeed;
    public float recoveryTime = 0;
    public float universalRecoveryTime = 1.5f;
    public bool isDead = false;
    public float fuelRegenerationTick;
    public int fuelRegenValue;
    public float nextRegenFuelAllowed;
}
