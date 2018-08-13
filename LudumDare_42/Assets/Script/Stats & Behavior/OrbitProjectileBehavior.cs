using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitProjectileBehavior : MonoBehaviour
{
    public ProjectileStats stats;
	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {
        transform.position = transform.parent.position + (transform.position - transform.parent.position).normalized * stats.orbitRange;
        transform.RotateAround(transform.parent.position, new Vector3(0, 0, 1), stats.speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
    }
}
