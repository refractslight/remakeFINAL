using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour
{

    public GameObject gun;
    GameObject ControllerRight;
    public GameObject offset;
    //public float gunSpawnDistance = .25f;
    //Shooter shooterScript;
    
    // Start is called before the first frame update
    void Start()
    {
        //shooterScript = GetComponent<Shooter>();
        gun = Object.Instantiate(gun, offset.transform.position, offset.transform.rotation);
        gun.transform.SetParent(ControllerRight.transform);
        updatePosition();
    }

    void updatePosition() {
        gun.transform.position = offset.transform.position;
        gun.transform.forward = offset.transform.forward;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        updatePosition();
    }
}
