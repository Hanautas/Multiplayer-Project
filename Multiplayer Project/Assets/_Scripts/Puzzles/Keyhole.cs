using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Keyhole : MonoBehaviour
{
    public bool isComplete = false;
    public bool canPickup = true;

    public string tagToCheck;

    public Transform holePosition;

    public GameObject key;

    public UnityEvent onInsert;

    public virtual void Update()
    {
        if (!canPickup)
        {
            SetKeyTransform();
        }
    }

    public void SetKeyTransform()
    {
        key.transform.position = holePosition.position;
        key.transform.rotation = holePosition.rotation;
    }

    public IEnumerator EnablePickup()
    {
        yield return new WaitForSeconds(0.5f);

        canPickup = true;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagToCheck)
        {
            key = other.gameObject;

            isComplete = true;

            canPickup = false;

            SetKeyTransform();

            onInsert.Invoke();

            StartCoroutine(EnablePickup());
        }
    }
}