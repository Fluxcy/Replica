using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanics : MonoBehaviour
{
    public float openSpeed = 2.0f;
    public float doorOpenAngle = 90.0f;

    private bool opened;

    private Vector3 closedRotation;
    private Vector3 openRotation;
    private Transform meshTransform;

    private void Start()
    {
        opened = false;
        closedRotation = transform.eulerAngles;
        openRotation = new Vector3(closedRotation.x, closedRotation.y + doorOpenAngle, closedRotation.z);
        meshTransform = transform.Find("Mesh");
    }

    private void Update()
    {
        if (opened)
        {
            meshTransform.rotation = Quaternion.Slerp(meshTransform.rotation, Quaternion.Euler(openRotation), Time.deltaTime * openSpeed);
        }
        else
        {
            meshTransform.rotation = Quaternion.Slerp(meshTransform.rotation, Quaternion.Euler(closedRotation), Time.deltaTime * openSpeed);
        }
    }

    public void open()
    {
        opened = !opened;
    }
}