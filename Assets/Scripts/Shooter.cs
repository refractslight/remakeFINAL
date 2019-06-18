using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


namespace Valve.VR.InteractionSystem
{
    public class Shooter : MonoBehaviour
    {

        public GameObject gun;
        float gunOffset = 0.1f;
        [SerializeField]
        float shootForce = 5f;
        public GameObject projectile;
        public AudioSource gunAudio;
        public AudioClip[] pew;
        public SteamVR_Action_Boolean isShooting;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                shootProjectile();
            }
            
        }

        public void shootProjectile()
        {
            GameObject bullet = GameObject.Instantiate(projectile, transform.position + (transform.forward * gunOffset), new Quaternion());
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * shootForce;
            gunAudio.PlayOneShot(pew[Random.Range(0, pew.Length)]);
        }
    }
}
