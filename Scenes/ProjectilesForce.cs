using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesForce : MonoBehaviour
{
    public GameObject projectile;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Advance();
        //projectile.posittion = new Vector3(Vector3.forward * 2 * Time.deltaTime);
    }


    void Advance()
    {
        /* Vector3 shootDirection = projectile.transform.position;
         shootDirection = transform.TransformDirection(Vector3.forward * 2.5f );

         *//*Vector3 advance = new Vector3(0,0,0);*//*
         projectile.transform.position = shootDirection;*/

        rb.velocity = transform.TransformDirection(transform.forward * 3.0f);
    }
}
