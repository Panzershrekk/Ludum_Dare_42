using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStreamProjectilebehavior : MonoBehaviour
{

    public ProjectileStats stats;

    private Vector3 targetPosition;
	// Use this for initialization
	void Start () {
	    targetPosition = (GameObject.FindGameObjectWithTag("PlayerAim").transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update ()
	{
	    transform.position += (Vector3)targetPosition * stats.speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("PlayerAim").transform.position, Time.deltaTime * stats.speed);
        //transform.position += transform.up * Time.deltaTime * stats.speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Goop")
        {
            DataTile striked = col.gameObject.GetComponent<LesserGoopDuplicatation>().personnalInfo;
            striked.isGoop = false;
            striked.obj = striked.baseObj;
            Destroy(col.gameObject);

        }
    }
}
