using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAgent : MonoBehaviour
{

    // Use this for initialization

    public GameObject target;

    void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(target.transform.position);

    }

    // Update is called once per frame
    void Update()
    {

    }
}


