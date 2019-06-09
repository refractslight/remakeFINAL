using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{

    public GameObject projectile;
    int currentHealth;
    public int maxHealth;
    float timeWithoutBounce = 2f;
    bool isDead;
    public GameObject ballParticles;
    public AudioClip[] deathNoiseBall;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //maxHealth = Random.Range(2, 10);
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
    }
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
            }
        }
        Debug.Log(currentHealth);

        
    }
    // Update is called once per frame
    void Update()
    {
        if(isDead){
            onDeath();
        }
        timeWithoutBounce += Time.deltaTime;
        if(timeWithoutBounce > maxLifeWithoutBounce){
            onDeath();
            }
        }

    void OnCollisionEnter(Collision collision) {
        bool isBrick = false;
     if(collision.gameObject.CompareTag("Brick")) {
         isBrick = true;
     }   
        uponBrickHit(isBrick);
    }

    void onDeath(){
        makeParticles();
        playDeathNoise();
        Destroy(gameObject);
    }

    void makeParticles(){
        Destroy (GameObject.Instantiate(ballParticles, transform.position, Quaternion.identity), 1f);
        //Debug.Log("made particles");
    }

    void playDeathNoise() {
        AudioSource.PlayClipAtPoint(deathNoiseBall[Random.Range(0, deathNoiseBall.Length)], transform.position);
    }

}

