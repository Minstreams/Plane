using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPlane : MonoBehaviour {
    //火花
    public GameObject ping;
    public GameObject crashed;
    public Transform target;
    public float Health = 30;
    public float speed;
    public float dieLight;
    blink准心 bb;
    BloomBlink bbb;

    PlayerStatus ps;
    private void Start()
    {
        bb = GameObject.FindGameObjectWithTag("zhunxin").GetComponent<blink准心>();
        bbb = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BloomBlink>();
        ps = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerStatus>();
        target = GameObject.FindGameObjectWithTag("target").transform;
        transform.LookAt(target);
        GetComponent<Rigidbody>().velocity = (target.position - transform.position).normalized * speed;
    }

    private void Update()
    {
        if (Health <= 0) Die();
        if ((transform.position - target.position).magnitude <= 9)
        {
            ps.Harm();
            Die();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //被子弹打产生火花
        if (other.tag == "ammo")
        {
            GameObject.Instantiate(ping, other.transform.position, other.transform.rotation, transform);
            other.GetComponentInParent<SingleAmmo>().bong();
            Health--;
            bb.Blink();
        }
        //被mmp打产生？
        if (other.tag == "mmpAmmo")
        {
            GameObject.Instantiate(ping, other.transform.position, other.transform.rotation, transform);
            other.GetComponent<dan>().Boom();
            Health--;
        }
    }

    void Die()
    {
        GameObject g=GameObject.Instantiate(crashed, transform.position, transform.rotation);
        g.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
        bbb.BlinkOnce(dieLight);
        Destroy(gameObject);
    }
}
