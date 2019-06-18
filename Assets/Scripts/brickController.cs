using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickController : MonoBehaviour
{

   // public GameObject brickPrefab;
    public GameObject brickParticles;
    public bool hitBrick = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnCollisionEnter(Collision col){
        if(gameObject.CompareTag("Brick")){
            hitBrick = true;
            uponBrickHit(hitBrick);
        }
    }

    void uponBrickHit(bool isBrick){
        if(isBrick == true){
            Destroy(GameObject.Instantiate(brickParticles, transform.position, Quaternion.identity), 1f);
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
