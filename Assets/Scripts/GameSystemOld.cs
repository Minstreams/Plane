using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AC.TimeOfDaySystemFree;

public class GameSystemOld : MonoBehaviour {
    public sightShift 镜头切换;
    public GameObject GameOverSight;
    public GameObject IntroductionSight;
    public GameObject GameWinSight;
    public PlayerStatus 玩家状态;
    public GameObject 飞机生成;
    public mmp mmp;
    public Gun gunL;
    public Gun gunR;
    public GameObject UI;

    public TimeControl tc;
    public LightControl lc;
    public TimeOfDayManager tfdm;
    public float secondsInADay;

    bool isTimeTruning=false;
    float timeLine;
    public float switchRate=0.03f;
	// Use this for initialization
	void Start () {
        secondsInADay = tfdm.dayInSeconds;
        timeLine = tfdm.timeline;
        Introduction();
    }
    private void Update()
    {
        if (isTimeTruning)
        {
            float td = timeLine - tfdm.timeline;
            if (td < 0) td += 24;
            tfdm.timeline += td * switchRate;
            if (td < 0.01f)
            {
                isTimeTruning = false;
                GameInit();
            }
        }
    }
    void SetAllBool(bool b)
    {
        飞机生成.SetActive(b);
        mmp.enabled = b;
        if (!b)
        {
            gunL.Stop();
            gunR.Stop();
        }
        else
        {
            gunL.enabled = true;
            gunR.enabled = true;
        }
        UI.SetActive(b);
        tc.seconds = 0;
        tc.enabled = b;
        tfdm.playTime = b;
        Cursor.visible = !b;
    }
    public void Introduction()
    {
        IntroductionSight.SetActive(true);
        SetAllBool(false);
        镜头切换.ShiftToIntroduction();
    }
    public void GameStart()
    {
        isTimeTruning = true;
        GameWinSight.SetActive(false);
        GameOverSight.SetActive(false);
    }
    public void GameInit()
    {
        GetComponent<AudioSource>().Play();
        lc.setF(0);
        SetAllBool(true);
        IntroductionSight.SetActive(false);
        玩家状态.Init();
        镜头切换.ShiftToGameVision();
    }
    public void GameOver(bool isWin)
    {
        if (isWin)
        {
            GameWinSight.SetActive(true);
        }
        else
        {
            GetComponent<AudioSource>().Stop();
            GameOverSight.SetActive(true);
        }
        SetAllBool(false);
        镜头切换.ShiftToIntroduction();
    }
}
