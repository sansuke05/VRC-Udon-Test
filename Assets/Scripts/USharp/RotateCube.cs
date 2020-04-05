
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class RotateCube : UdonSharpBehaviour
{
    public float mRotateSpeed;

    void Update()
    {
        this.gameObject.transform.Rotate(this.gameObject.transform.up * mRotateSpeed * Time.deltaTime);
    }
}
