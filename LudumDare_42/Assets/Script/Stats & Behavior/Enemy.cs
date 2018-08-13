using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public EnemyStats stats;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Fire")
        {
            TakeDamage(col.GetComponent<FireStreamProjectilebehavior>().stats.damage);
            Destroy(col.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        stats.hitpoint -= damage;
        if (stats.hitpoint <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
