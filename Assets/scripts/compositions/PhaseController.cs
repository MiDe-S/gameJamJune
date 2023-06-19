using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseController : MonoBehaviour
{
    int phase_shift = 50;
    bool phase_shifted = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<AISimpleWalk>().enabled = false;
        gameObject.GetComponent<AICharge>().enabled = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if (!phase_shifted) {
            if (gameObject.GetComponent<Health>().getHealth() < phase_shift) {
                Debug.Log("Phase2");
                // phase 1
                phase_shifted = true;
                gameObject.GetComponent<AISimpleWalk>().enabled = true;
                gameObject.GetComponent<AICharge>().enabled = false;
            }
        }
    }
}
