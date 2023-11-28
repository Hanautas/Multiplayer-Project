using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlugController : MonoBehaviour
{
    public bool canPickup = true;
    public bool isComplete = false;

    public int id;

    public Transform plugPosition;

    public UnityEvent onPlugged;

    [HideInInspector]
    public Transform endAnchor;
    [HideInInspector]
    public Rigidbody endAnchorRB;
    [HideInInspector]
    public WireController wireController;

    private void Update()
    {
        if (!canPickup)
        {
            endAnchor.transform.position = plugPosition.position;

            Vector3 eulerRotation = new Vector3(this.transform.eulerAngles.x + 90, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
            endAnchor.transform.rotation = Quaternion.Euler(eulerRotation);
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
        if (other.gameObject.tag == "WireEndAnchor")
        {
            endAnchor = other.transform;

            endAnchor.transform.position = plugPosition.position;
            endAnchor.transform.rotation = transform.rotation;

            canPickup = false;
            
            StartCoroutine(EnablePickup());

            if (other.gameObject.GetComponent<Wire>().id == id)
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