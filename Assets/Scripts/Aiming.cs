using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    [SerializeField] private string horizontalAxis = null;
    [SerializeField] private string verticalAxis = null;
    [SerializeField] [Range(0, 1f)] private float speed = 0.3f;

    private void Update()
    {
        Vector3 lookDirection = new Vector3(Input.GetAxis(horizontalAxis), 0, Input.GetAxis(verticalAxis));
        if(lookDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), speed);
        }

        // float directionAngle = Mathf.Rad2Deg * Mathf.Atan2(-Input.GetAxis(verticalAxis), Input.GetAxis(horizontalAxis));
        // Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 90 + directionAngle, transform.rotation.eulerAngles.z);
        // float angle = Quaternion.Angle(transform.rotation, targetRotation);
        // transform.RotateAround(transform.parent.position, Vector3.up, angle);
    }
}
