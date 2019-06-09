using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public GameObject gun;
    float gunOffset = 0.1f;
    float shootForce = 5f;
    public GameObject projectile;
    public AudioSource gunAudio;
    public AudioClip[] pew;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            shootProjectile();
        }
    }

    void shootProjectile() {
        GameObject bullet = this.projectile;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        Instantiate(bullet, gun.transform.position + (transform.forward * gunOffset), transform.rotation);
        rb.velocity = transform.forward * shootForce;
    }
}
