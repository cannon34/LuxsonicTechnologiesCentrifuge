using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentrifugeRotor : MonoBehaviour
{
    public GameObject InitialTestTubeA; // 
    public GameObject InitialTestTubeB; // 
    public GameObject FinalTestTubeA; // 
    public GameObject FinalTestTubeB; //

    public GameObject prefab0; // empty rotor
    public GameObject prefab1; // rotor with test tube Initial A
    public GameObject prefab2; // rotor with test tube Initial B
    public GameObject prefab3; // rotor with test tube Initial A and Initial B
    public GameObject prefab4; // rotor with test tube Final A
    public GameObject prefab5; // rotor with test tube Final B
    public GameObject prefab6; // rotor with test tube Final A and Final B

    private GameObject prefab; // holds the prefab to be instantiated
    private int prefabIndex;   // index to track the current loaded prefab

    // Start is called before the first frame update
    void Start()
    {
        prefab = prefab0; // load initial prefab
        prefabIndex = 0;

        Instantiate(prefab, transform.position, transform.rotation * Quaternion.Euler(-90, 0, 0)); // instantiate initial prefab
    }

    // Update is called once per frame
    void Update()
    {
        // adding test tube A to rotor
        if ((transform.position - GameObject.Find("TestTubeInitialA").transform.position).sqrMagnitude < .05)
        {
            print("AAAAAAAAAAAAAAA");
            GameObject.Destroy(GameObject.Find("TestTubeInitialA"));
            if (prefabIndex == 0) // if rotor is empty
            {
                GameObject.Destroy(prefab);
                prefab = prefab1; // load prefab with initialA
                prefabIndex = 1; // updated index to approriate value
                Instantiate(prefab, transform.position, transform.rotation * Quaternion.Euler(-90, 0, 0));
            }
            else if (prefabIndex == 2) // if rotor contains test tube Initial B
            {
                GameObject.Destroy(prefab);
                prefab = prefab3; // load prefab with initialA and InitialB
                prefabIndex = 3; // updated index to approriate value
                Instantiate(prefab, transform.position, transform.rotation * Quaternion.Euler(-90, 0, 0));
            }
        }
        // adding test tube B to rotor
        if ((transform.position - GameObject.Find("TestTubeInitialB").transform.position).sqrMagnitude < .05)
        {
            print("BBBBBBBBBBBBBBB");
            GameObject.Destroy(GameObject.Find("TestTubeInitialB"));
            if (prefabIndex == 0) // if rotor is empty
            {
                GameObject.Destroy(prefab);
                prefab = prefab2; // load prefab with initialB
                prefabIndex = 2; // updated index to approriate value
                Instantiate(prefab, transform.position, transform.rotation * Quaternion.Euler(-90, 0, 0));
            }
            else if (prefabIndex == 1) // if rotor contains test tube Initial B
            {
                GameObject.Destroy(prefab);
                prefab = prefab3; // load prefab with initialA and InitialB
                prefabIndex = 3; // updated index to approriate value
                Instantiate(prefab, transform.position, transform.rotation * Quaternion.Euler(-90, 0, 0));
            }
        }
/*
        if (SlidingButton.buttonPressed == true)
        {
            SlidingButton.buttonPressed = false;
            if (prefabIndex == 0) // if rotor is empty
            {
                // play error sound
            }
            if (prefabIndex == 1) // if rotor contains test tube Initial A
            {
                GameObject.Destroy(prefab);
                prefab = prefab4; // load prefab with initialA
                prefabIndex = 4; // updated index to approriate value
                //Instantiate(prefab, transform.position, transform.rotation * Quaternion.Euler(-90, 0, 0));
            }
            else if (prefabIndex == 2) // if rotor contains test tube Initial B
            {
                GameObject.Destroy(prefab);
                prefab = prefab5; // load prefab with initialA and InitialB
                prefabIndex = 5; // updated index to approriate value
                //Instantiate(prefab, transform.position, transform.rotation * Quaternion.Euler(-90, 0, 0));
            }
            else if (prefabIndex == 3) // if rotor contains test tube Initial B
            {
                GameObject.Destroy(prefab);
                prefab = prefab6; // load prefab with initialA and InitialB
                prefabIndex = 6; // updated index to approriate value
                //Instantiate(prefab, transform.position, transform.rotation * Quaternion.Euler(-90, 0, 0));
            }
        }*/
    }
}
