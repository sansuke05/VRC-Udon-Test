using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private float totalTime;
    [SerializeField]
    private int min;
    [SerializeField]
    private float sec;

    private float oldSec;

    private Text timerText;

    // Start is called before the first frame update
    void Start() {
        totalTime = min * 60 + sec;
        oldSec = 0f;
        timerText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update() {
        if(totalTime <= 0f) {
            return;
        }

        totalTime = min * 60 + sec;
        totalTime -= Time.deltaTime;

        min = (int) totalTime / 60;
        sec = totalTime - min * 60;

        if((int)sec != (int)oldSec) {
            timerText.text = min.ToString("00") + ":" + ((int)sec).ToString("00");
        }
        oldSec = sec;
        if (totalTime <= 0f) {
            Debug.Log("制限時間終了");
        }
    }
}
