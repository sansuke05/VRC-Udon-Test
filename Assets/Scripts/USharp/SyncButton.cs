
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class SyncButton : UdonSharpBehaviour
{
    [UdonSynced(UdonSyncMode.None)]
    int clickCount = 0;

    public Text uiText;

    public override void Interact()
    {
        if(Networking.GetOwner(this.gameObject) != Networking.LocalPlayer)
        {
            Networking.SetOwner(Networking.LocalPlayer, this.gameObject);
        }

        CountUp();
    }

    public void CountUp()
    {
        clickCount++;
    }

    void Update()
    {
        uiText.text = clickCount.ToString();
    }
}
