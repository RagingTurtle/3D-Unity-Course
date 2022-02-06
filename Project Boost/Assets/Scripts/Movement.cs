using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidbodyPlayer;
    [SerializeField] float mainThrust = 100;
    [SerializeField] float rotationThrust = 100;
    void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
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
        transform.Rotate(direction * rotationThrust * Time.deltaTime);
    }
}
