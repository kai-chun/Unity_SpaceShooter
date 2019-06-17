﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	private Rigidbody rBody;
    public float speed;
    public float tilt;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

	private AudioSource audio;
    private float nextFire;

    void Start () {
		rBody = GetComponent<Rigidbody>();
        speed = 10;
        tilt = 4;
		audio = GetComponent<AudioSource>();
	}

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audio.Play();
        }
    }

    void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rBody.velocity = movement * speed;

        rBody.position = new Vector3
        (
            Mathf.Clamp(rBody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rBody.position.z, boundary.zMin, boundary.zMax)
        );

        rBody.rotation = Quaternion.Euler(0.0f, 0.0f, rBody.velocity.x * -tilt);
    }
}
