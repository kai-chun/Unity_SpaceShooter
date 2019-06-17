using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	public float tumble;
	private Rigidbody rBody;

    void Start()
    {
		rBody = GetComponent<Rigidbody>();
		rBody.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
