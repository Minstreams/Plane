using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro : MonoBehaviour {
    GameSystemOld gs;
    private void Start()
    {
        gs = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameSystemOld>();
    }
    void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            gs.GameInit();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
