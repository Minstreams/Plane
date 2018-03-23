using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleMmp : MonoBehaviour {
    public int order;
    public void Add()
    {
        GetComponent<Renderer>().enabled = true;
    }
    public void Delete()
    {
        GetComponent<Renderer>().enabled = false;
    }
}
