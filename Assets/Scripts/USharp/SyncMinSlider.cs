
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class SyncMinSlider : UdonSharpBehaviour
{
    [UdonSynced(UdonSyncMode.None)]
    public int minutes = 0;

    public Text timerText;

    public Slider minutesSlider;


    public override void Interact()
    {
        if(Networking.GetOwner(this.gameObject) != Networking.LocalPlayer)
        {
            Networking.SetOwner(Networking.LocalPlayer, this.gameObject);
        }
    }

    void Update()
    {
        
    }
}
