using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public ColorType type;

    public Transform plugPosition;

    public GameObject computerChip;

    public bool canPickup = true;
    public bool isConnected = false;
    public bool isComplete = false;

    private void Update()
    {
        if (isConnected && !canPickup)
        {
            computerChip.transform.position = plugPosition.position;
            Vector3 eulerRotation = new Vector3(this.transform.eulerAngles.x + 90, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
            computerChip.transform.rotation = plugPosition.rotation;
        }
    }

    private IEnumerator EnablePickup()
    {
        yield return new WaitForSeconds(0.5f);

        canPickup = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ComputerChip")
        {
            isConnected = true;
            computerChip = other.gameObject;
            other.gameObject.transform.position = plugPosition.position;
            other.gameObject.transform.rotation = plugPosition.rotation;
            canPickup = false;
            StartCoroutine(EnablePickup());
        }
    }
}