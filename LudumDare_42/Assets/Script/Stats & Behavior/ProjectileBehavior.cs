using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{

    public ProjectileStats projectileStats;
    private GameObject target;
    private Vector2 targetPosition;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player");
	    targetPosition = (target.transform.position - transform.position).normalized;

        //targetPosition = new Vector2(target.transform.position.x, target.transform.position.y);
    }

    // Update is called once per frame
    void Update () {
        transform.position += (Vector3)targetPosition * projectileStats.speed * Time.deltaTime;

        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, projectileStats.speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Player player = target.GetComponent<Player>();
            player.TakeDamage(projectileStats.damage);
            player.UpdateHealth();
            Destroy(gameObject);
        }
    }
}
