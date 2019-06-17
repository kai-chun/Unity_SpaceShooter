using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    private Rigidbody rBody;
    public float speed;

    void Start () {
        rBody = GetComponent<Rigidbody>();
        rBody.velocity = this.transform.forward * speed;
    }

}
