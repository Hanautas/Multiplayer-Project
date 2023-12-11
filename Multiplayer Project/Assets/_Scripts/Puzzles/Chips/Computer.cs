using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : Keyhole
{
    public ColorType type;

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagToCheck)
        {
            key = other.gameObject;

            Chip chipComponent = other.GetComponent<Chip>();

            isComplete = (chipComponent.type == type && chipComponent.isCorrect);

            canPickup = false;

            SetKeyTransform();

            OnInsert();

            StartCoroutine(EnablePickup());
        }
    }
}