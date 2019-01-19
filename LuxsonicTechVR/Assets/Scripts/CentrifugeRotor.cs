// Filename: CentrifugeRotor.cs
// Author: Eric Cannon

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentrifugeRotor : MonoBehaviour
{
    public GameObject lidLatch;
    public GameObject baseLatch;

    public GameObject InitialTestTubeA; 
    public GameObject InitialTestTubeB; 
    public GameObject FinalTestTubeA; 
    public GameObject FinalTestTubeB;
    
    public GameObject prefab0; // empty rotor
    public GameObject prefab1; // rotor with test tube Initial A
    public GameObject prefab2; // rotor with test tube Initial B
    public GameObject prefab3; // rotor with test tube Initial A and Initial B
    
    private int prefabIndex;   // index to track the current loaded prefab

    public AudioClip spinPeriod; // sound clip for spin period of centrifuge
    public AudioClip error; // sound clip played if button is pressed when centrifuge is empty
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        prefabIndex = 0;
        prefab0.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // adding test tube A to rotor
        if (InitialTestTubeA != null)
        {
            if ((transform.position - InitialTestTubeA.transform.position).sqrMagnitude < .05)
            {
                GameObject.Destroy(InitialTestTubeA);
                if (prefabIndex == 0) // if rotor is empty
                {
                    prefabIndex = 1; // updated index to approriate value
                    prefab1.SetActive(true); // activate appropriate prefab
                    prefab0.SetActive(false);// deactivate appropriate prefab
                }
                else if (prefabIndex == 2) // if rotor contains test tube Initial B
                {
                    prefabIndex = 3; // updated index to approriate value
                    prefab3.SetActive(true); // activate appropriate prefab
                    prefab2.SetActive(false);// deactivate appropriate prefab
                }
            }
        }
        // adding test tube B to rotor
        if (InitialTestTubeB != null)
        {
            if ((transform.position - InitialTestTubeB.transform.position).sqrMagnitude < .05)
            {
                GameObject.Destroy(InitialTestTubeB);
                if (prefabIndex == 0) // if rotor is empty
                {
                    prefabIndex = 2; // updated index to approriate value
                    prefab2.SetActive(true); // activate appropriate prefab
                    prefab0.SetActive(false);// deactivate appropriate prefab
                }
                else if (prefabIndex == 1) // if rotor contains test tube Initial B
                {
                    prefabIndex = 3; // updated index to approriate value
                    prefab3.SetActive(true); // activate appropriate prefab
                    prefab1.SetActive(false);// deactivate appropriate prefab
                }
            }
        }

        if (SlidingButton.buttonPressed == true)
        {
            SlidingButton.buttonPressed = false;
            if (prefabIndex == 0 || ((lidLatch.transform.position - baseLatch.transform.position).sqrMagnitude > .001)) // if rotor is empty or lid is open
            {
                source.PlayOneShot(error, 1.0f);
            }
            else if (prefabIndex == 1) // if rotor contains test tube Initial A
            {
                source.PlayOneShot(spinPeriod, 1.0f);
                prefabIndex = 0; // updated index to approriate value
                prefab0.SetActive(true); // activate appropriate prefab
                FinalTestTubeA.SetActive(true); // activate Final Test Tube A prefab
                prefab1.SetActive(false); // deactivate appropriate prefab
            }
            else if (prefabIndex == 2) // if rotor contains test tube Initial B
            {
                source.PlayOneShot(spinPeriod, 1.0f);
                prefabIndex = 0; // updated index to approriate value
                prefab0.SetActive(true); // activate appropriate prefab
                FinalTestTubeB.SetActive(true); // activate Final Test Tube B prefab
                prefab2.SetActive(false); // deactivate appropriate prefab
            }
            else if (prefabIndex == 3) // if rotor contains test tube Initial B
            {
                source.PlayOneShot(spinPeriod, 1.0f);
                prefabIndex = 0; // updated index to approriate value
                prefab0.SetActive(true); // activate appropriate prefab
                FinalTestTubeA.SetActive(true); // activate Final Test Tube A prefab
                FinalTestTubeB.SetActive(true); // activate Final Test Tube B prefab
                prefab3.SetActive(false); // deactivate appropriate prefab
            }
        }
    }
}
