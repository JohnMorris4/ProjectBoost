using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody _rigidBody;
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] private float mainThrust = 125f;
    private AudioSource _myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly" : 
                print("OK");
                break;
            
            case "Fuel":
                print("Getting fuel");
                break;
            default:
                print("You are dead");
                break;
        }
    }

    private void Thrust()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            // _rigidBody.mass = .040F;
            
            _rigidBody.AddRelativeForce(Vector3.up * mainThrust);
            if (!_myAudioSource.isPlaying)
            {
                _myAudioSource.Play();
            }
        }
        else if (!Input.GetKey(KeyCode.Space))
        {
            _myAudioSource.Stop();
        }
    }

    private void Rotate()
    {
        
        _rigidBody.freezeRotation = true;
        
        float rotationSpeed = rcsThrust * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.A))
        {
           
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }

        _rigidBody.freezeRotation = false;
    }
}