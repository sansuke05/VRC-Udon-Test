
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class SyncSlider : UdonSharpBehaviour
{
    [UdonSynced(UdonSyncMode.None)]
    float sliderValue = 0;

    public Text uiText;

    public Slider uiSlider;

    public override void Interact()
    {
        if(Networking.GetOwner(this.gameObject) != Networking.LocalPlayer)
        {
            Networking.SetOwner(Networking.LocalPlayer, this.gameObject);
        }

        sliderValue = uiSlider.value;
    }

    void Update()
    {
        uiSlider.value = sliderValue;
        uiText.text = sliderValue.ToString();
    }
}
