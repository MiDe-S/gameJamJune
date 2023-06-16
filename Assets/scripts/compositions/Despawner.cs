using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public float active_time = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        active_time -= 60 * Time.deltaTime;
        if (active_time <= 0) {
            Destroy(gameObject);
        }   
    }
}
