using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanics : MonoBehaviour
{
    public float smooth = 2.0f;
    public float doorOpenAngle = 90.0f;

    private bool open;
    private bool enter;
    private Vector3 defaultRot;
    private Vector3 openRot;
    private Transform meshTransform;

    private void Start()
    {
        defaultRot = transform.eulerAngles;
        openRot = new Vector3(defaultRot.x, defaultRot.y + doorOpenAngle, defaultRot.z);
        meshTransform = transform.Find("Mesh");
    }

    private void Update()
    {
        if (open)
        {
            meshTransform.rotation = Quaternion.Slerp(meshTransform.rotation, Quaternion.Euler(openRot), Time.deltaTime * smooth);
        }
        else
        {
            meshTransform.rotation = Quaternion.Slerp(meshTransform.rotation, Quaternion.Euler(defaultRot), Time.deltaTime * smooth);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (enter)
            {
                open = !open;
            }
        }
    }

    private void OnGUI()
    {
        if (enter)
        {
            if(open)
                GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 30), "LEFT CLICK TO CLOSE");
            else
                GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 30), "LEFT CLICK TO OPEN");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enter = false;
        }
    }
}