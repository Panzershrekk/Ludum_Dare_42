using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{

    // Use this for initialization
    void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {

            if (Application.CanStreamedLevelBeLoaded(GameObject.FindGameObjectWithTag("Persitant").GetComponent<LevelData>()
                .sceneToLoadNext))
            {
                SceneManager.LoadScene(GameObject.FindGameObjectWithTag("Persitant").GetComponent<LevelData>()
                    .sceneToLoadNext);
            }
            else
            {
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                Destroy(GameObject.FindGameObjectWithTag("HealthBar"));
                Destroy(GameObject.FindGameObjectWithTag("FuelBar"));
                Destroy(GameObject.FindGameObjectWithTag("Persitant"));
                Destroy(GameObject.FindGameObjectWithTag("Music"));

                SceneManager.LoadScene("MainMenu");

            }
        }
        

    }
}
