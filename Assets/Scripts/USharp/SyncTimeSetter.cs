
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class SyncTimeSetter : UdonSharpBehaviour
{
    // 同期用変数
    [UdonSynced(UdonSyncMode.None)]
    float minutes = 0;

    [UdonSynced(UdonSyncMode.None)]
    float seconds = 0;

    public Text timerText;

    public GameObject syncTimerSystemObject;

    public GameObject minutesSliderObject;

    public GameObject secondsSliderObject;

    private SyncTimerSystem timerSystem;

    private Slider minutesSlider;

    private Slider secondsSlider;


    void Start()
    {
        timerSystem = syncTimerSystemObject.GetComponent<SyncTimerSystem>();
        minutesSlider = minutesSliderObject.GetComponent<Slider>();
        secondsSlider = secondsSliderObject.GetComponent<Slider>();
    }

    public override void Interact()
    {
        if(Networking.GetOwner(minutesSliderObject) != Networking.LocalPlayer)
        {
            Networking.SetOwner(Networking.LocalPlayer, minutesSliderObject);
        }

        if(Networking.GetOwner(secondsSliderObject) != Networking.LocalPlayer)
        {
            Networking.SetOwner(Networking.LocalPlayer, secondsSliderObject);
        }

        if(Networking.GetOwner(this.gameObject) != Networking.LocalPlayer)
        {
            Networking.SetOwner(Networking.LocalPlayer, this.gameObject);
        }

        minutes = minutesSlider.value;
        seconds = secondsSlider.value;
    }

    void Update()
    {
        if (timerSystem.isTimerActive)
        {
            return;
        }

        minutesSlider.value = minutes;
        secondsSlider.value = seconds;

        var min = (int)minutes;
        var sec = (int)seconds;

        // for Debug
        Debug.Log("min: " + min);
        Debug.Log("sec: " + sec);

        var minStr = "";
        var secStr = "";

        if (min < 10)
        {
            minStr = "0" + min.ToString();
        }
        else
        {
            minStr = min.ToString();
        }

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
