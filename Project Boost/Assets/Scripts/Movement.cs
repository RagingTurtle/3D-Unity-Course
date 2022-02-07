using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidbodyPlayer;
    AudioSource audioSourceRocket;
    [SerializeField] float mainThrust = 100;
    [SerializeField] float rotationThrust = 100;
    void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
        audioSourceRocket = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbodyPlayer.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!audioSourceRocket.isPlaying){
                audioSourceRocket.Play();
            }
        }
        else{
            audioSourceRocket.Stop();
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(Vector3.back);
        }
    }

    private void ApplyRotation(Vector3 direction)
    {
        rigidbodyPlayer.freezeRotation = true;
        transform.Rotate(direction * rotationThrust * Time.deltaTime);
        rigidbodyPlayer.freezeRotation = false;

    }
}
