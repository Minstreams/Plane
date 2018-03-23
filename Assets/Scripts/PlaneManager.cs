using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour {
    public GameObject plane;
    public float xRange =80;
    public float yRange = 20;
    public Vector3 center;
    public int PlaneNum;
    int timer;
    int produceTime;

    GameSystemOld gs;
	// Use this for initialization
	void Start () {
        gs = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameSystemOld>();
        produceTime = (int)(gs.secondsInADay / (PlaneNum * Time.deltaTime));
	}
	
	// Update is called once per frame
	void Update () {
        timer++;
        if (timer >= produceTime)
        {
            timer = 0;
            planeProduce();
        }
	}

    void planeProduce()
    {
        GameObject.Instantiate(plane, new Vector3((float)Random.Range(-xRange, xRange),(float)Random.Range(-yRange, yRange),0)+center,Quaternion.identity);
    }
}
