
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PrivateValue : UdonSharpBehaviour
{
    private int privateValue = 0;

    void Update()
    {
        privateValue++;
        Debug.Log("PrivateValue.privateValue: " + privateValue);
    }
}
