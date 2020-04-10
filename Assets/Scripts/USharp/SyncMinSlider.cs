
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class SyncMinSlider : UdonSharpBehaviour
{
    [UdonSynced(UdonSyncMode.None)]
    float minutes = 0;

    public GameObject timerSystem;

    public Text timerText;

    public Slider minutesSlider;


    public override void Interact()
    {
        if(Networking.GetOwner(this.gameObject) != Networking.LocalPlayer)
        {
            Networking.SetOwner(Networking.LocalPlayer, this.gameObject);
        }

        minutes = minutesSlider.value;
    }

    void Update()
    {
        var timer = (UdonBehaviour) timerSystem.GetComponent(typeof(UdonBehaviour));
        var isTimerActive = (bool) timer.GetProgramVariable("isTimerActive");

        if (isTimerActive)
        {
            return;
        }

        minutesSlider.value = minutes;
        
        var min = (int)minutes;
        var minStr = "";
        var secStr = (timerText.text.Split(':'))[1];

        if (min < 10)
        {
            minStr = "0" + min.ToString();
        }
        else
        {
            minStr = min.ToString();
        }

        timerText.text = minStr + ":" + secStr;
    }
}
