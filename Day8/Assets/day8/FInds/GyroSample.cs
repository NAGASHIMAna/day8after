using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroSample : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion gyro = Input.gyro.attitude;
        transform.rotation = Quaternion.Euler(90, 0, 0) * (new Quaternion(-gyro.x, -gyro.y, gyro.z, gyro.w));

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 10, Color.red);//debug用にシーンビューでRayを可視化しています


        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);//当たった対象のgameObjectはこれで取得できる

            if (hit.collider.name == "Cube")
            {
                Renderer r = hit.collider.gameObject.GetComponent<Renderer>();
                r.material.color = Color.green;
                //Rigidbody rb = hit.collider.gameObject.AddComponent<Rigidbody>();
            }

        }
    }
}
