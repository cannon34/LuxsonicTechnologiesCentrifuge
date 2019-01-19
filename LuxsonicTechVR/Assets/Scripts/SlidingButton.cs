// Filename: SlidingButton.cs
// Author: Eric Cannon

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlidingButton : MonoBehaviour
{
    public static bool buttonPressed;

    public Transform pointA;
    public Transform pointB;

    // track states for checking button press
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
        transform.position = ClosestPointOnLine(transform.position);// ensure that the button is only moving vertically

        if (transform.position == pointA.position)// if button is at resting position
            state = 1;
        else
            state = 0;

        if (state == 1 && prevState == 0)// button has reached resting position after being pressed
        {
            buttonPressed = false;
        }
        else if (state == 0 && prevState == 1)// button has been pressed
        {
            buttonPressed = true;
        }
        
        prevState = state;
    }

    //
    //  ClosestPointOnLine
    //
    //  Purpose: To keep the button travelling only up and down
    //  Argument(s): 
    //		<1> point: Vector containing the current position
    //  Returns: 
    //		vClosestPoint: Vector containing the corrected position
    //
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
