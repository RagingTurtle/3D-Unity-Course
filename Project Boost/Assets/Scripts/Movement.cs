using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidbodyPlayer;
    AudioSource audioSourcePlayer;

    [SerializeField] ParticleSystem mainThrustParticles;
    [SerializeField] ParticleSystem leftTurnThrustParticles;
    [SerializeField] ParticleSystem rightTurnThrustParticles;

    [SerializeField] AudioClip thrustAudio;
    [SerializeField] float audioVolume = .5f;
    [SerializeField] float mainThrust = 100;
    [SerializeField] float rotationThrust = 100;
    void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
        audioSourcePlayer = GetComponent<AudioSource>();
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
            if (!audioSourcePlayer.isPlaying)
            {
                audioSourcePlayer.PlayOneShot(thrustAudio, audioVolume);
            }
            if (!mainThrustParticles.isPlaying)
            {
                mainThrustParticles.Play();
            }
        }
        else
        {
            audioSourcePlayer.Stop();
            mainThrustParticles.Stop();
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(Vector3.forward);
            if (!leftTurnThrustParticles.isPlaying)
            {
                leftTurnThrustParticles.Play();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(Vector3.back); 
            if (!rightTurnThrustParticles.isPlaying)
            {
                rightTurnThrustParticles.Play();
            }
        }
        else {
            leftTurnThrustParticles.Stop();
            rightTurnThrustParticles.Stop();
        }
    }

    private void ApplyRotation(Vector3 direction)
    {
        rigidbodyPlayer.freezeRotation = true;
        transform.Rotate(direction * rotationThrust * Time.deltaTime);
        rigidbodyPlayer.freezeRotation = false;

    }
}
