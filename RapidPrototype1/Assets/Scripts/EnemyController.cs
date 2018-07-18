﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public float lookRadius = 50.0f;

    Transform target;

    NavMeshAgent agent;
    

    // Use this for initialization
    void Start() {

        //playertoTarget = Random.Range(0, 1);
        var possibleTargets = GameObject.FindGameObjectsWithTag("Player");

        target = possibleTargets[Random.Range(0, 2)].transform;

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                //attack target
                //face target
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5.0f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}