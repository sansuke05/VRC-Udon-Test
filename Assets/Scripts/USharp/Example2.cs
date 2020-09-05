
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

namespace AliceLaboratory
{
    public class Example2 : UdonSharpBehaviour
    {
        float totalTime;

        float oldSec;

        int minutes;

        float seconds;

        bool isTimerPause;

        public bool isTimerActive;

        public Slider minutesSlider;

        public Slider secondsSlider;

        public Text timerText;

        public Text timeUpText;

        public Button startButton;

        public Button stopButton;

        public Button resetButton;

        public AudioSource alarm;
        void Start()
        {

        }
    }
}

