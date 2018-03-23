using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC.TimeOfDaySystemFree;
using UnityStandardAssets.ImageEffects;

public class TimeControl : MonoBehaviour {
    public Transform 时间条;
    public float seconds=0;
    GameSystemOld gs;
    float cRx;
    float x;

    Bloom b;
    Color oc;
    public Color target;

    // Use this for initialization
    void Start()
    {
        b = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Bloom>();
        gs = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameSystemOld>();
        oc = b.bloomThresholdColor;
        seconds = 0;
        cRx = transform.rotation.eulerAngles.x;
    }
	// Update is called once per frame
	void Update () {
        float f = seconds / gs.secondsInADay;
        时间条.localScale = new Vector3(f,1,1);
        x = cRx-360 * f;
        while (x < -180) x += 180;
        while (x > 0) x -= 180;
        transform.rotation = Quaternion.Euler(x, 0, 0);
        seconds += Time.deltaTime;
        b.bloomThresholdColor = oc * (1 - f) + target * f;
        if (seconds >= gs.secondsInADay) gs.GameOver(true);
	}
}
