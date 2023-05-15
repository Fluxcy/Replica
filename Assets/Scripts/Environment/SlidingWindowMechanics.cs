using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingWindowMechanics : MonoBehaviour
{
    public Camera playerCam;

    public GameObject leftWindow;
    public GameObject rightWindow;

    public Animator leftWindowAnimator;
    public Animator rightWindowAnimator;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);

                if (hit.collider.gameObject == leftWindow)
                {
                    leftWindowController();
                }
                else if (hit.collider.gameObject == rightWindow)
                {
                    rightWindowController();
                }
            }
        }
    }

    private void leftWindowController()
    {

        if (leftWindowAnimator.GetBool("isOpen"))
        {
            Debug.Log("Closing left");
            leftWindowAnimator.SetBool("isOpen", false);
        }
        else if (rightWindowAnimator == null || !rightWindowAnimator.GetBool("isOpen"))
        {
            Debug.Log("Opening left");
            leftWindowAnimator.SetBool("isOpen", true);
        }
    }

    private void rightWindowController()
    {
        if (rightWindowAnimator.GetBool("isOpen"))
        {
            Debug.Log("Closing right");
            rightWindowAnimator.SetBool("isOpen", false);
        }
        else if (leftWindowAnimator == null || !leftWindowAnimator.GetBool("isOpen"))
        {
            Debug.Log("Opening right");
            rightWindowAnimator.SetBool("isOpen", true);
        }
    }
}
