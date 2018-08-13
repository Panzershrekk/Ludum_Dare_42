using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelData : MonoBehaviour
{

    public int currentLevel = 1;
    public string affix = "Classic";
    public string sceneToLoadNext = "Level1Classic";

    void Awake()
    {
        //OnEnable();
        DontDestroyOnLoad(this.gameObject);
    }
	// Use this for initialization
	void Start () {
	}

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        currentLevel++;
        sceneToLoadNext = "Level" + currentLevel + affix;
        Debug.Log("Next level to load " + sceneToLoadNext);
    }

}
