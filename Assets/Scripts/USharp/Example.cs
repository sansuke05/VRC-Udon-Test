using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class Example : UdonSharpBehaviour
{
    public int a = 0;

    public int b = 0;

    public Text text;
    [UdonSynced]
    private string str = "";

    void Start()
    {
        //StartCoroutine(Add());
    }

    //IEnumurator Coroutine()
    //{
    //    a++;
    //}

    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        if (Networking.LocalPlayer == player)
        {
            SyncValue();
        }
    }

    public override void Interact()
    {
        if (!Networking.IsOwner(Networking.LocalPlayer, this.gameObject)) Networking.SetOwner(Networking.LocalPlayer, this.gameObject);
        str = text.text + "A";
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "SyncValue");
    }
    public void SyncValue()
    {
        text.text = str;
    }

    public int Add(int a, int b)
    {
        return a + b;
    }
}
