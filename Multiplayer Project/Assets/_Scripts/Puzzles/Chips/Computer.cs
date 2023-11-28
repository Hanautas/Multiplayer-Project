using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public ColorType type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ComputerChip")
        {

        }
    }
}