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
            StartThruster();
        }
        else
        {
            StopThruster();
        }
    }

    void StartThruster()
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
    void StopThruster()
    {
        audioSourcePlayer.Stop();
        mainThrustParticles.Stop();
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            TurnLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            TurnRight();
        }
        else
        {
            StopTurnParticles();
        }
    }

    void TurnLeft()
    {
        ApplyRotation(Vector3.forward);
        if (!leftTurnThrustParticles.isPlaying)
        {
            leftTurnThrustParticles.Play();
        }
    }
    void TurnRight()
    {
        ApplyRotation(Vector3.back);
        if (!rightTurnThrustParticles.isPlaying)
        {
            rightTurnThrustParticles.Play();
        }
    }
    void StopTurnParticles()
    {
        leftTurnThrustParticles.Stop();
        rightTurnThrustParticles.Stop();
    }

    void ApplyRotation(Vector3 direction)
    {
        rigidbodyPlayer.freezeRotation = true;
        transform.Rotate(direction * rotationThrust * Time.deltaTime);
        rigidbodyPlayer.freezeRotation = false;
    }
}
