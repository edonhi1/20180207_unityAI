﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective : Sense {
    public int fieldOfVeiw = 45;
    public int viewDistance = 100;

    private Transform playerTrans;
    private Vector3 rayDirection;

    protected override void Initialize()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected override void UpdateSense()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= detectionRate)
            DetectAspect();
    }

    void DetectAspect()
    {
        RaycastHit hit;
        rayDirection = playerTrans.position - transform.position;
        if ((Vector3.Angle(rayDirection, transform.forward)) < fieldOfVeiw)
        {
            if(Physics.Raycast(transform.position,rayDirection,out hit, viewDistance))
            {
                Aspect aspect = hit.collider.GetComponent<Aspect>();
                if (aspect != null)
                {
                    if (aspect.aspectName == aspectName)
                    {
                        print("Enemy Detected");
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (playerTrans == null)
            return;
        Debug.DrawLine(transform.position, playerTrans.position, Color.red);
        Vector3 frontRayPoint = transform.position + (transform.forward * viewDistance);
        Vector3 leftRayPoint = frontRayPoint;
        leftRayPoint.x += fieldOfVeiw * 0.5f;
        Vector3 rightRayPoint = frontRayPoint;
        rightRayPoint.x -= fieldOfVeiw * 0.5f;
        Debug.DrawLine(transform.position, frontRayPoint, Color.green);
        Debug.DrawLine(transform.position, leftRayPoint, Color.green);
        Debug.DrawLine(transform.position, rightRayPoint, Color.green);
    }
}
