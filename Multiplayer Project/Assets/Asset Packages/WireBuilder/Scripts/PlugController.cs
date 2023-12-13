using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlugController : Keyhole
{
    public int id;

    [HideInInspector]
    public Transform endAnchor;
    [HideInInspector]
    public Rigidbody endAnchorRB;
    [HideInInspector]
    public WireController wireController;

    public override void Update()
    {
        if (!canPickup)
        {
            key.transform.position = holePosition.position;

            Vector3 eulerRotation = new Vector3(this.transform.eulerAngles.x + 90,
                this.transform.eulerAngles.y, this.transform.eulerAngles.z);
                key.transform.rotation = Quaternion.Euler(eulerRotation);
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagToCheck)
        {
            key = other.gameObject;

            Wire wireComponent = other.GetComponent<Wire>();

            isComplete = (wireComponent.id == id);

            canPickup = false;

            SetKeyTransform();

            OnInsert();
            
            StartCoroutine(EnablePickup());
        }
    }
}