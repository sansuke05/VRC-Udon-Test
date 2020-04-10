
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class SyncTimerSystem : UdonSharpBehaviour
{
    //[UdonSynced(UdonSyncMode.None)]
    float totalTime;

    //[UdonSynced(UdonSyncMode.None)]
    float oldSec;

    //[UdonSynced(UdonSyncMode.None)]
    int minutes;
    
    //[UdonSynced(UdonSyncMode.None)]
    float seconds;

    //[UdonSynced(UdonSyncMode.None)]
    public bool isTimerActive;

    public GameObject startButtonObject;

    public Slider minutesSlider;

    public Slider secondsSlider;
    
    public Text timerText;

    public Text timeUpText;

    public Button startButton;

    void Start()
    {
        totalTime = minutes * 60 + seconds;
        oldSec = 0;
    }


    ///<summary>
    ///Button.OnClickで呼ばれる
    ///</summary>
    public override void Interact()
    {
        if(Networking.GetOwner(startButtonObject) != Networking.LocalPlayer)
        {
            Networking.SetOwner(Networking.LocalPlayer, startButtonObject);
        }

        //処理同期
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "OnStartTimer");
    }


    public void OnStartTimer()
    {
        var minAndSec = timerText.text.Split(':');
        minutes = int.Parse(minAndSec[0]);
        seconds = float.Parse(minAndSec[1]);
        Debug.Log(minutes);
        Debug.Log(seconds);

        if (minutes <= 0 && seconds <= 0.01)
        {
            return;
        }

        totalTime = minutes * 60 + seconds;
        oldSec = 0;

        isTimerActive = true;

        // UI更新
        timeUpText.text = "";
        startButton.interactable = false;
        minutesSlider.interactable = false;
        secondsSlider.interactable = false;
    }


    void Update()
    {
        if (totalTime <= 0)
        {
            return;
        }

        if (isTimerActive)
        {
            totalTime = minutes * 60 + seconds;
            totalTime -= Time.deltaTime;

            minutes = (int)totalTime / 60;
            seconds = totalTime - minutes * 60;

            if ((int)seconds != (int)oldSec)
            {
                timerText.text = minutes.ToString("00") + ":" + ((int)seconds).ToString("00");
            }
            oldSec = seconds;

            if (totalTime <= 0f)
            {
                timeUpText.text = "Time Up";
                isTimerActive = false;
                
                // UIをActivate
                startButton.interactable = true;
                minutesSlider.interactable = true;
                secondsSlider.interactable = true;
            }
        }
    }
}
