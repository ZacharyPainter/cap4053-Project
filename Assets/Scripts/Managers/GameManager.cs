using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public LevelManager levelScript;

	// Use this for initialization
	void Awake ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        levelScript = GetComponent<LevelManager>();
        InitGame();
	}

    void InitGame()
    {
        levelScript.setup();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
