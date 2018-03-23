using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {
    GameSystemOld gs;
    // Use this for initialization
    void Start () {
        gs = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameSystemOld>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            gs.GameStart();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
