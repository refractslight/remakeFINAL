using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickController : MonoBehaviour
{

    // public GameObject brickPrefab;
    public Rigidbody rb;
    public int explosiveRings = 5;
    public GameObject explosiveBrick;

    public GameObject brickParticles;
    bool hitBrick = false;
    public bool testHit;
    public bool explosive = false;
    public AudioClip[] brickDeath;
    public AudioClip[] explosiveDeath;
    public GameObject[] randomBricks;
    public int numExplosiveBricks;
    public int index;
    
    // Start is called before the first frame update
    void Start()
    {
        randomizeExplosive();
    }


    public GameObject randomizeExplosive()
    {
        rb = GetComponent<Rigidbody>();

        numExplosiveBricks = Random.Range(3, 5);
        for(int x = 0; x < numExplosiveBricks; x++){
        randomBricks = GameObject.FindGameObjectsWithTag("Brick");
        index = Random.Range(0, numExplosiveBricks);
          }

          return randomBricks[index];

    }

    void OnCollisionEnter(Collision col)
    {
        if (gameObject.CompareTag("Brick"))
        {
            if (explosive)
            {
                explosiveHit();
            }
            else
            {
                uponBrickHit();
            }
        }

    }

    void explosiveHit()
    {
        Debug.Log("boom");
    }

    void uponBrickHit()
    {
        AudioSource.PlayClipAtPoint(brickDeath[Random.Range(0, brickDeath.Length)], transform.position);
        Destroy(GameObject.Instantiate(brickParticles, transform.position, Quaternion.identity), 1f);
        Destroy(gameObject);

    }
    // Update is called once per frame
    void Update()
    {
        if (testHit == true)
        {
            if (gameObject.CompareTag("Explosive"))
            {
                explosiveHit();
                testHit = false;
            }
            else
            {
                uponBrickHit();
                testHit = false;
            }

        }
    }
}
