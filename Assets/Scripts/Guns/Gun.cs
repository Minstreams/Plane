using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public GameObject ammo;

    public float shootPower;
    public bool is附武器;
    //开火频率
    public int fireRate = 7;
    int firePoint;
    int fixedFrames;
    bool isLaunching = false;
    int timer = 0;
    //炮台旋转
    float rotateSpeed = 0;
    public float rotateDeltaSpeed = 1;
    public float rotateMaxSpeed = 20;
    //子弹散射
    public float maxBurstRate = 3;
    public float burstDeltaRate = 0.03f;
    float burstRate = 0;
    //模型后坐力模拟
    public Transform shakeModel;
    public float shakePower;
    //镜头动感效果
    public Camera c;//临时
    float viewRange;
    public float viewChangeRate;
    //过热
    public 过热 gr;
    public float grd;
    //准心特效
    public AutoRotate ar准心;
    Vector3 originV;
    public float rotateRate;
    public float shakeRate;
    void Start() {
        if(c!=null)viewRange = c.fieldOfView;
        isLaunching = false;
        timer = 0;
        fixedFrames = (int)(1/(fireRate * Time.deltaTime));
        if (fixedFrames < 1)fixedFrames = 1;
        firePoint = 1;
        if (is附武器)
        {
            firePoint += fixedFrames / 2;
        }
        else
        {
            originV = ar准心.v;
        }
    }
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            isLaunching = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isLaunching = false;
        }
        if (isLaunching)
        {
            if (rotateSpeed <= rotateMaxSpeed)
            {
                rotateSpeed += rotateDeltaSpeed;
            }
            if(burstRate<=maxBurstRate)
            {
                burstRate += burstDeltaRate;
            }
            timer++;
            if (timer == firePoint) Launch();
            if (timer >= fixedFrames)
            {
                timer = 0;
            }
        }
        else
        {
            if (rotateSpeed > 0)
            {
                rotateSpeed -= rotateDeltaSpeed;
            }
            else
            {
                rotateSpeed = 0;
            }
            if (burstRate > 0)
            {
                burstRate -= burstDeltaRate;
            }
            else
            {
                burstRate = 0;
            }
        }
        if (is附武器)
        {
            
            transform.Rotate(rotateSpeed, 0, 0);
        }
        else
        {
            transform.Rotate(-rotateSpeed, 0, 0);
            ar准心.v = originV + new Vector3(0, 0, rotateSpeed * rotateRate);
            c.fieldOfView = viewRange + rotateSpeed * viewChangeRate;
        }
    }
    void Launch()
    {
        GameObject a= GameObject.Instantiate(ammo, transform.position, transform.rotation);
        a.GetComponent<Rigidbody>().velocity = transform.right*shootPower+(transform.up+transform.forward)*burstRate;
        shakeModel.localPosition -= new Vector3(0, 0, shakePower);
        gr.f += grd;
        ar准心.GetComponent<zhunxinKuoSan>().setX(shakePower * shakeRate);
    }
    public void Stop()
    {
        isLaunching = false;
        this.enabled = false;
    }
}
