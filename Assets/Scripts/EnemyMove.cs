using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] [Range(1f, 10f)] float speed = 1f;
    [SerializeField] [Range(0.1f, 2f)] float rotationSpeed = 1f;

    enum ZombieTypes { BrainLess, Stalker, Observer }

    [SerializeField] ZombieTypes zombieTypes;

    [SerializeField] Transform playerTransform;


    void Update()
    {
        switch (zombieTypes)
        {
            case ZombieTypes.BrainLess:
                MoveForward(); break;
            case ZombieTypes.Stalker:
                ChasePlayer(); break;
            case ZombieTypes.Observer:
                LookPlayer(); break;
        }
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void ChasePlayer()
    {
        LookPlayer();
        Vector3 direction = (playerTransform.position - transform.position);
        if (direction.magnitude > 1f)
        {
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }


    /*    
    private void RotateAroundPlayer()
    {
        LookPlayer();
        transform.RotateAround(playerTransform.position, Vector3.up, 5f * Time.deltaTime);


    }
    */

    private void LookPlayer()
    {
        Vector3 lookPos = playerTransform.position - transform.position;
        lookPos.y = 0f;
        Quaternion newRotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, rotationSpeed);
    }
}
