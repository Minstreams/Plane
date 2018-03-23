using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mmps : MonoBehaviour {
    singleMmp [] ms;
    public int maxAmmo=10;
    public int currentAmmo=10;
    public float reloadSeconds;
    int reloadFrames;
    int timer = 0;
	// Use this for initialization
	void Start () {
        reloadFrames = (int)(reloadSeconds / Time.deltaTime);
        GameObject[] t = GameObject.FindGameObjectsWithTag("mmpImage");
        ms = new singleMmp[t.Length];
        for(int i = 0; i < t.Length; i++)
        {
            ms[t[i].GetComponent<singleMmp>().order] = t[i].GetComponent<singleMmp>();
        }
	}
    private void Update()
    {
        if (currentAmmo < maxAmmo)
        {
            timer++;
            if (timer >= reloadFrames)
            {
                timer = 0;
                AddOne();
            }
        }else
        {
            timer = 0;
        }
    }

    public void AddOne()
    {
        if (currentAmmo < maxAmmo)
        {
            ms[currentAmmo].Add();
            currentAmmo++;
        }
    }

    public bool DeleteOne()
    {
        bool b = false;
        if (currentAmmo > 0)
        {
            currentAmmo--;
            ms[currentAmmo].Delete();
            b = true;
        }
        return b;
    }

}
