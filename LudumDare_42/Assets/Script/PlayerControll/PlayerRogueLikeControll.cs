using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRogueLikeControll : MonoBehaviour
{
    public CharacterStats stats;
    public GameObject projectilePrefab;
    public float nextAttackAllowed;
    public LayerMask blockingLayer;
    private Player player;
    private AudioSource audioDatashoot;


    private Animator animator;

    void Start()
    {
        audioDatashoot = GetComponents<AudioSource>()[1];

        player = GetComponent<Player>();
        nextAttackAllowed = Time.time + stats.attackSpeed;
        stats.nextRegenFuelAllowed = Time.time + stats.fuelRegenerationTick;

        animator = GetComponent<Animator>();
        //animator.SetBool("idle", true);
    }

    void Update()
    {
        if (stats.isDead == false)
        {
            Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Move();
            Attack();
            RegenFuel();
        }
    }

    void Move()
    {
        if (Input.GetKey("up")) //Press up arrow key to move forward on the Y AXIS
        {
            animator.SetBool("IsWalking", true);
            transform.Translate(0, stats.moveSpeed * Time.deltaTime, 0, Space.World);
        }
        else if (Input.GetKey("down")) //Press up arrow key to move forward on the Y AXIS
        {
            animator.SetBool("IsWalking", true);
            transform.Translate(0, -stats.moveSpeed * Time.deltaTime, 0, Space.World);
        }
        else if (Input.GetKey("right")) //Press up arrow key to move forward on the Y AXIS
        {
            animator.SetBool("IsWalking", true);
            transform.Translate(stats.moveSpeed * Time.deltaTime, 0, 0, Space.World);
        }
        else if (Input.GetKey("left")) //Press up arrow key to move forward on the Y AXIS
        {
            animator.SetBool("IsWalking", true);
            transform.Translate(-stats.moveSpeed * Time.deltaTime, 0, 0, Space.World);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    void Attack()
    {
        if (Input.GetMouseButton(0) && stats.fuel > 0)
        {
            if (Time.time > nextAttackAllowed)
            {
                audioDatashoot.Play(0);
                stats.fuel -= 1;
                player.UpdateFuel();
                GameObject obj = GameObject.Instantiate(projectilePrefab, transform.position + new Vector3(0.3f, 0), transform.rotation);
                nextAttackAllowed = Time.time + stats.attackSpeed;
                Destroy(obj, 0.5f);
                GameObject obj2 = GameObject.Instantiate(projectilePrefab, transform.position + new Vector3(-0.3f, 0), transform.rotation);
                Destroy(obj2, 0.5f);
            }
        }

    }

    void RegenFuel()
    {
        if (Time.time > stats.nextRegenFuelAllowed)
        {
            stats.fuel += stats.fuelRegenValue;
            player.UpdateFuel();
            stats.nextRegenFuelAllowed = Time.time + stats.fuelRegenerationTick;
        }
    }
}