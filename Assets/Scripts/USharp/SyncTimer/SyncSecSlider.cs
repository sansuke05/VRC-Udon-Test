
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class SyncSecSlider : UdonSharpBehaviour
{
    [UdonSynced(UdonSyncMode.None)]
    float seconds = 0;

    public GameObject timerSystem;

    public Text timerText;

    public Slider secondsSlider;


    public override void Interact()
    {
        if(Networking.GetOwner(this.gameObject) != Networking.LocalPlayer)
        {
            Networking.SetOwner(Networking.LocalPlayer, this.gameObject);
        }

        seconds = secondsSlider.value;
    }

    void Update()
    {
        var timer = (UdonBehaviour) timerSystem.GetComponent(typeof(UdonBehaviour));
        var isTimerActive = (bool) timer.GetProgramVariable("isTimerActive");

        if (isTimerActive)
        {
            return;
        }

        secondsSlider.value = seconds;
        
        var sec = (int)seconds;
        var minStr = (timerText.text.Split(':'))[0];
        var secStr = "";

        if (sec < 10)
        {
            secStr = "0" + sec.ToString();
        }
        else
        {
            secStr = sec.ToString();
        }

        timerText.text = minStr + ":" + secStr;
    }
}
