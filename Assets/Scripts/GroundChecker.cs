using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private Rigidbody parentRigidbody;
    private int triggerCount;
    private bool isFalling;

    private void Awake()
    {
        triggerCount = 0;
        isFalling = false;
    }

    private void Start()
    {
        parentRigidbody = GetComponentInParent<Rigidbody>();
    }

    private void Update()
    {
        if(triggerCount <= 0 && !isFalling)
        {
            parentRigidbody.useGravity = true;
            parentRigidbody.constraints = RigidbodyConstraints.None;
            parentRigidbody.velocity = new Vector3(parentRigidbody.velocity.x * 0.5f, -3, parentRigidbody.velocity.z * 0.5f);
            parentRigidbody.drag = 0;
            GetComponentInParent<FP_ForceToPosition>().Enable(false);
            Transform canon = transform.parent.Find("Shooter").GetChild(0);
            canon.parent = null;
            canon.GetComponent<Rigidbody>().velocity = parentRigidbody.velocity;
            canon.GetComponent<Rigidbody>().isKinematic = false;
            isFalling = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            triggerCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            triggerCount--;
        }
    }
}
