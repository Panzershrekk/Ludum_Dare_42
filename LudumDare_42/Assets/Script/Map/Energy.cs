using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{

    public EnergyStats stats;
	// Use this for initialization
	void Start () {
		
	}
	

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<Player>().Regenerate(stats);
            Destroy(this.gameObject);
        }
    }
}
