using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{

    public GameObject projectile;
    int currentHealth;
    public int maxHealth;
    float timeWithoutBounce = 0;
    bool isDead;
    public GameObject ballParticles;
    public AudioClip[] deathNoiseBall;
    Rigidbody rb;
    public float maxLifeWithoutBounce = 2f;

    public float minKillSpeed = .5f;
    // Start is called before the first frame update
    void Start()
    {
        // This works for now to generate ball's health, but idk how fun it is.
        maxHealth = Random.Range(2, 10);
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
    }

    // If what we hit is a brick, reset the current health to max health. 
    //else subtract one from health until dead
    void uponBrickHit(bool isBrick){
        timeWithoutBounce = 0;

        if(isBrick)
        {
            currentHealth = maxHealth;
        }
        else {
            currentHealth -= 1;
            if(currentHealth <=0) {
                onDeath();
                Debug.Log("not brick");
            }
        }
        Debug.Log(currentHealth);

        
    }
    // Update is called once per frame
    void Update()
    {

        /*if(rb.velocity.sqrMagnitude < minKillSpeed){
            onDeath();
        }*/
       if(isDead){
            onDeath();
       }
    // i feel like something is wrong here
    // supposed to be where if the ball hasn't bounced in timeWithoutBounce's value, die
        timeWithoutBounce += Time.deltaTime;
        if(timeWithoutBounce > maxLifeWithoutBounce){
            onDeath();
            }
        }

    // Is it a brick that we hit???
    void OnCollisionEnter(Collision collision) {
        bool isBrick = false;
     if(collision.gameObject.CompareTag("Brick")) {
         isBrick = true;
     }   
        uponBrickHit(isBrick);
    }

    // RIP Brick
    void onDeath(){
        makeParticles();
        playDeathNoise();
        Destroy(gameObject);
    }

    //pretty explody bits
    void makeParticles(){
        Destroy (GameObject.Instantiate(ballParticles, transform.position, Quaternion.identity), 1f);
        //Debug.Log("made particles");
    }
    // noise
    void playDeathNoise() {
        AudioSource.PlayClipAtPoint(deathNoiseBall[Random.Range(0, deathNoiseBall.Length)], transform.position);
    }

}

