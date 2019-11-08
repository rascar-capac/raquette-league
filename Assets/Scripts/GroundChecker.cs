using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private Rigidbody parentRigidbody;
    private int triggerCount;

    private void Awake()
    {
        triggerCount = 0;
    }

    private void Start()
    {
        parentRigidbody = GetComponentInParent<Rigidbody>();
    }

    private void Update()
    {
        if(triggerCount <= 0)
        {
            parentRigidbody.useGravity = true;
            parentRigidbody.constraints = RigidbodyConstraints.None;
            GetComponentInParent<FP_ForceToPosition>().Enable(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerCount++;
    }

    private void OnTriggerExit(Collider other)
    {
        triggerCount--;
    }
}
