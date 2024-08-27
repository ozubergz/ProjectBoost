using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 100.0f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {   
            // Vector3.up shorthand for writing (0, 1, 0)
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            // Vector3.forward shorthand for (0, 0, 1)
            ApplyRotation(Vector3.forward);
        } else if(Input.GetKey(KeyCode.D))
        {
            // Vector3.forward shorthand for (0, 0, -1)
            // Equivallent is also -Vector.forward
            ApplyRotation(Vector3.back);
        }
    }

    void ApplyRotation(Vector3 direction) {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(direction * rotationThrust * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so that the physics takeover
    }
}
