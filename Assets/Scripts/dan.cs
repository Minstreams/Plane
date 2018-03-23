using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class dan : MonoBehaviour {
    public GameObject huohua;
    public Transform target;
    public float trackTime;
    public float randomRange;
    public float timer = 0;
    public Vector3 v;
    Vector3 tpo;
    Vector3 vo;
	// Use this for initialization
	void Start () {
        trackTime += Random.Range(-randomRange, randomRange);
    }
	
	// Update is called once per frame
	void Update () {
        timer += (1/ trackTime) * Time.deltaTime;
        if (target != null)
        {
            v = vo * (1 - timer * timer) + (target.position - transform.position) * timer * timer;
            tpo = target.position;
        }
        transform.position += v;
        if (timer >= 1||(transform.position - (target==null?tpo:target.position)).magnitude < 0.1f)
        {
            GameObject.Instantiate(huohua, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        //
	}
    public void fixVo()
    {
        vo = v;
    }
    public void Boom()
    {
        Destroy(gameObject);
    }
}
