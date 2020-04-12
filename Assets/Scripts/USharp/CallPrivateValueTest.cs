
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class CallPrivateValueTest : UdonSharpBehaviour
{
    public GameObject valueClass;

    void Update()
    {
        var udon = (UdonBehaviour)valueClass.GetComponent(typeof(UdonBehaviour));
        var calledPrivateValue = (int)udon.GetProgramVariable("privateValue");
        Debug.Log("CallPrivateValueTest.calledPrivateValue: " + calledPrivateValue);
    }
}
