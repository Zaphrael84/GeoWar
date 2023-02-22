using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiFollow : MonoBehaviour
{

    private NavMeshAgent agent;

    public GameObject Player;
    public float speed;
    private Vector3 _transformPosition;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        agent.SetDestination(Player.transform.position);
        _transformPosition = new Vector3();
        _transformPosition = transform.position + Player.transform.position;
    }

}
