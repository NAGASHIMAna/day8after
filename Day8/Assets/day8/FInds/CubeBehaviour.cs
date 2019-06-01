using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    public float rotSpeed = 2.0f;
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.AddTorque(Vector3.left * rotSpeed);
    }


    // Update is called once per frame
    void Update()
    {

    }


    public void ChangeColor()
    {
        Color newColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        GetComponent<Renderer>().material.color = newColor;


    }




}
