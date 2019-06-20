using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//bless this mess
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


    void randomizeExplosive()
    {
        generateBricks generate = GetComponent<generateBricks>();
        rb = GetComponent<Rigidbody>();

        numExplosiveBricks = Mathf.RoundToInt((generate.columns * generate.rows)*.25f);
        for(int x = 0; x < numExplosiveBricks; x++){
        randomBricks = GameObject.FindGameObjectsWithTag("Brick");
        index = Random.Range(0, numExplosiveBricks);
            }

          makeExplosive(randomBricks[index]);

    }


    void makeExplosive(GameObject brickie)
    {
        brickie.gameObject.tag="Explosive";
        Debug.Log("explosive Bricks Made");
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
        float explosiveRadius = .5f * Random.Range(.09f, 1.5f);
        float explosionTime = 0.2f * Random.Range(1f, 1.1f);
        float timeInBetweenExplosions = explosionTime / (float)explosiveRings;
        float explosiveRadiusStep = explosiveRadius / (float)explosiveRings;
        for(int x = 0; x < explosiveRings; x++){
            Collider[] thingsWeHit = Physics.OverlapSphere(transform.position, explosiveRadiusStep);
            for(int i = 0; i < thingsWeHit.Length; i++){
                GameObject objToDestroy = thingsWeHit[i].attachedRigidbody.gameObject;
                uponBrickHit();
                brickDeathNoise();
                }
            }


        Debug.Log("boom");
    }

    void uponBrickHit()
    {
        brickDeathNoise();
        Destroy(GameObject.Instantiate(brickParticles, transform.position, Quaternion.identity), 1f);
        Destroy(gameObject);

    }

    void brickDeathNoise(){
        AudioSource.PlayClipAtPoint(brickDeath[Random.Range(0, brickDeath.Length)], transform.position);
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
                //testHit = false;
            }

        }
    }
}
