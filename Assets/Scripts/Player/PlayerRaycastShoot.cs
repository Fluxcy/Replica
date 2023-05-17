using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycastShoot : MonoBehaviour
{
    [SerializeField] private float rayLength = 5f;

    private Camera playerCam;

    void Start()
    {
        playerCam = this.GetComponent<Camera>();    
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, rayLength))
            {
                Debug.Log(hit.collider.gameObject.name);

                Collider target = hit.collider;


                if (target.gameObject.tag == "Switch")
                {
                    target.GetComponent<SwitchMechanics>().toggle();
                }
                else if(target.gameObject.tag == "Door")
                {
                    target.GetComponent<DoorMechanics>().open();
                }
            }
        }
    }
}
