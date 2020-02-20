﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody _rigidBody;    
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
       
        
    }
    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidBody.mass = .040F;
            _rigidBody.AddRelativeForce(Vector3.up);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.forward);
        }
    }
}