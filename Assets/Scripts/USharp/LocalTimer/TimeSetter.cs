
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class TimeSetter : UdonSharpBehaviour
{
    public Text timerText;

    public Slider minutesSlider;

    public Slider secondsSlider;

    public override void Interact()
    {
        var min = (int)(minutesSlider.value);
        var sec = (int)(secondsSlider.value);
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
