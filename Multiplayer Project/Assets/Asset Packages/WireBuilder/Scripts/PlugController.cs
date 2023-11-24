using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlugController : MonoBehaviour
{
    public bool canPickup = true;
    public bool isConnected = false;
    public bool isComplete = false;

    public int id;

    public UnityEvent OnWirePlugged;
    public Transform plugPosition;

    [HideInInspector]
    public Transform endAnchor;
    [HideInInspector]
    public Rigidbody endAnchorRB;
    [HideInInspector]
    public WireController wireController;

    public void OnPlugged()
    {
        OnWirePlugged.Invoke();
    }

    private void Update()
    {
        if (isConnected && !canPickup)
        {
            endAnchorRB.isKinematic = true;
            endAnchor.transform.position = plugPosition.position;
            Vector3 eulerRotation = new Vector3(this.transform.eulerAngles.x + 90, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
            endAnchor.transform.rotation = Quaternion.Euler(eulerRotation);
        }
    }

    private IEnumerator EnablePickup()
    {
        yield return new WaitForSeconds(0.5f);

        canPickup = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        if (other.gameObject.tag == "WireEndAnchor")
        {
            endAnchor = other.transform;
            isConnected = true;
            endAnchorRB.isKinematic = true;
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