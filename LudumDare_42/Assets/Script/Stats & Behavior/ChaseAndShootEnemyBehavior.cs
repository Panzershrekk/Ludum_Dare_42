using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAndShootEnemyBehavior : MonoBehaviour {

    public GameObject projectileType;
    private EnemyStats stats;
    private float nextAttackAllowed;
    private Animator animator;

    // Use this for 

    void Start()
    {
        stats = GetComponent<Enemy>().stats;
        nextAttackAllowed = stats.attackSpeed;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        if (dist > stats.range && dist < stats.rangeOfChase)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, stats.moveSpeed * Time.deltaTime);
            Vector3 diff = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            animator.SetTrigger("IsWalking");
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

        }
        if (dist <= stats.range)
        {
            Vector3 diff = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
            if (Time.time > nextAttackAllowed)
            {
                nextAttackAllowed = Time.time + stats.attackSpeed;
                CreateProjectile();
            }
        }
    }

    void CreateProjectile()
    {
        GameObject obj = Instantiate(projectileType, new Vector3(transform.position.x, transform.position.y, -2.0f), Quaternion.identity);
        Destroy(obj, stats.projectileDecay);
    }
}
