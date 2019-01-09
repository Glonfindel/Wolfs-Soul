using UnityEngine;
using System.Collections;

public class SmoothCameraWithBumper : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private float distance = 3.0f;
    [SerializeField] private float height = 1.0f;
    [SerializeField] private float damping = 5.0f;
    [SerializeField] private bool smoothRotation = true;
    [SerializeField] private float rotationDamping = 10.0f;

    [SerializeField] private Vector3 targetLookAtOffset;

    [SerializeField] private float bumperDistanceCheck = 2.5f;
    [SerializeField] private float bumperCameraHeight = 1.0f;
    [SerializeField] private Vector3 bumperRayOffset;

    private void Awake()
    {
        transform.parent = target;
    }

    private void FixedUpdate()
    {
        Vector3 wantedPosition = target.TransformPoint(0, height, -distance);
        RaycastHit hit;
        Vector3 back = target.transform.TransformDirection(-1 * Vector3.forward);
        
        if (Physics.Raycast(target.TransformPoint(bumperRayOffset), back, out hit, bumperDistanceCheck) && hit.transform != target) 
        {
            wantedPosition.x = hit.point.x;
            wantedPosition.z = hit.point.z;
            wantedPosition.y = Mathf.Lerp(hit.point.y + bumperCameraHeight, wantedPosition.y, Time.deltaTime * damping);
        }

        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

        Vector3 lookPosition = target.TransformPoint(targetLookAtOffset);

        if (smoothRotation)
        {
            Quaternion wantedRotation = Quaternion.LookRotation(lookPosition - transform.position, target.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
        }
        else
            transform.rotation = Quaternion.LookRotation(lookPosition - transform.position, target.up);
    }
}