using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashedPlane : MonoBehaviour {
    public GameObject ping;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "mmpAmmo")
        {
            GameObject.Instantiate(ping, collision.transform.position, collision.transform.rotation, transform);
            Destroy(collision.gameObject);
        }
    }
}
