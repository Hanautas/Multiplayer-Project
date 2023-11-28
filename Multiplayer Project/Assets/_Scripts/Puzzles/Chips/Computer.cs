using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Computer : MonoBehaviour
{
    public ColorType type;

    public bool canPickup = true;
    public bool isComplete = false;

    public Transform plugPosition;

    private GameObject computerChip;

    public UnityEvent onPlugged;

    private void Update()
    {
        if (!canPickup)
        {
            computerChip.transform.position = plugPosition.position;
            computerChip.transform.rotation = plugPosition.rotation;
        }
    }

    public void OnPlugged()
    {
        onPlugged.Invoke();
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
            computerChip = other.gameObject;

            computerChip.transform.position = plugPosition.position;
            computerChip.transform.rotation = plugPosition.rotation;

            canPickup = false;

            StartCoroutine(EnablePickup());

            Chip chipComponent = other.gameObject.GetComponent<Chip>();

            if (chipComponent.type == type && chipComponent.isCorrect)
            {
                isComplete = true;
            }
            else
            {
                isComplete = false;
            }

            OnPlugged();
        }
    }
}