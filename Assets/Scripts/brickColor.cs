using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickColor : MonoBehaviour
{

    public Material brickMat;
    public Gradient brickGradient;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void colorBlocks(){
        brick paintedBrick = new brick();
        Material paintedMat = paintedBrick.GetComponentInChildren<Renderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
