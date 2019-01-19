using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlidingButton : MonoBehaviour
{
    public static bool buttonPressed;

    public Transform pointA;
    public Transform pointB;

    int state = 0;
    int prevState = 0;
    // Start is called before the first frame update
    void Start()
    {
        buttonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ClosestPointOnLine(transform.position);

        if (transform.position == pointA.position)
            state = 1;
        else
            state = 0;

        if (state == 1 && prevState == 0)
        {
            buttonPressed = false;
            print("ReleaseButton");
        }
        else if (state == 0 && prevState == 1)
        {
            buttonPressed = true;
            print("PressButton");
        }
        
        prevState = state;
    }
    
    
    Vector3 ClosestPointOnLine(Vector3 point)
    {
        Vector3 va = pointA.position;
        Vector3 vb = pointB.position;

        Vector3 vVector1 = point - va;

        Vector3 vVector2 = (vb - va).normalized;

        float t = Vector3.Dot(vVector2, vVector1);

        if (t <= 0)
            return va;

        Vector3 vVector3 = vVector2 * t;

        Vector3 vClosestPoint = va + vVector3;

        return vClosestPoint;
    }

}
