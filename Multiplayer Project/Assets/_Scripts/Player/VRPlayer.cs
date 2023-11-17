using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayer : MonoBehaviour
{
    public Transform headOffset;
    public Transform head;

    void Start()
    {
        Recenter();
    }

    public void Recenter()
    {
        headOffset.localEulerAngles = new Vector3(0f, 180f, 0f);
        headOffset.localPosition = new Vector3(-head.localPosition.x, 0f, -head.localPosition.z);
    }
}