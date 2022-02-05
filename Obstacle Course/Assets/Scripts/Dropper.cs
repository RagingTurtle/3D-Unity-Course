using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] float waitTime = 3f;
    MeshRenderer renderer;
    Rigidbody rigidbody;
    private void Start() {
        renderer = GetComponent<MeshRenderer>();
        rigidbody = GetComponent<Rigidbody>();
        renderer.enabled = false;
    }
    private void Update()
    {
        if (Time.time >= waitTime)
        {
            renderer.enabled = true;
            rigidbody.useGravity = true;
        }
    }
}
