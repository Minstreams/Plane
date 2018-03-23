using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {
    public int maxHealth;
    float health;
    public int mmpMaxNumber;
    public float ammoTemperature;
    public int currentMmpNumber;
    int timer;
    public int reloadFrames;
    public Blink b;
    public scaleChanger 血条;
    GameSystemOld gs;
	// Use this for initialization
	void Start () {
        gs = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameSystemOld>();
        Init();
	}
	public void Init()
    {
        timer = 0;
        health = maxHealth;
        血条.ChangeTo(1);
    }
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            health = maxHealth;
            血条.ChangeTo(1);
            gs.GameOver(false);
        }
        timer++;
        if (timer >= reloadFrames)
        {
            Reload();
        }
	}

    public void Harm()
    {
        if(health>0)health--;
        b.BlinkOnce();
        血条.ChangeTo(health / maxHealth);
    }
    void Reload()
    {
        if (currentMmpNumber < mmpMaxNumber) currentMmpNumber++;
        timer = 0;
    }
}
