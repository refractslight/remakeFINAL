using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeys : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey(KeyCode.W)){
           transform.Rotate(1, 0, 0);
       }

        if (Input.GetKey(KeyCode.S)){
            transform.Rotate(-1, 0, 0);
        }

        if (Input.GetKey(KeyCode.A)){
            transform.Rotate(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.D)){
            transform.Rotate(0, 1, 0);
        }
    }

}
