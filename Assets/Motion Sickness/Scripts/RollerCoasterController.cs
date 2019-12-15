using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerCoasterController : MonoBehaviour
{
    public GameObject hulaGirl; 

    //Path to follow
    public PathCreation.PathCreator path;
    public SpeedVsDistance points;
    public float distanceToEnd = 2000.0f;
    public Rigidbody rb;

    private int currentPoint = 0;
    private int nextPoint = 1;
    private float acceleration;



    private bool isStopped = false;
    private float currentSpeed = 0;
    private float distanceTraveled = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetAcceleration();
        rb.detectCollisions = false;
        rb.isKinematic = false;
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if distance is at end, stop the cart, let it free fall
        if(distanceTraveled > distanceToEnd)
        {
            isStopped = true;
            //Start falling
            StartFalling();
        }

        if(!isStopped)
        {
            distanceTraveled += currentSpeed * Time.deltaTime;

            transform.position = path.path.GetPointAtDistance(distanceTraveled);
            transform.rotation = path.path.GetRotationAtDistance(distanceTraveled);


            //check if next point exists
            if (nextPoint < points.distance.Length)
            {
                //Set next point as current point if you travel past it
                if (distanceTraveled > points.distance[nextPoint])
                {
                    currentPoint = nextPoint;
                    nextPoint += 1;
                    SetAcceleration();

                }
            }

            else
            {
                acceleration = 0;
                currentSpeed = points.speed[currentPoint];
            }

            if (currentSpeed > points.speed[currentPoint] || currentSpeed < points.speed[currentPoint])
            {
                currentSpeed += acceleration * Time.deltaTime;
            }

            else
            {
                acceleration = 0;
                currentSpeed = points.speed[currentPoint];
            }
        }
    }

    private void StartFalling()
    {
        rb.detectCollisions = true;
        rb.isKinematic = false;
        rb.useGravity = true;  
    }

    private void SetAcceleration()
    {
        if (nextPoint < points.distance.Length)
        {
            float targetSpeed = points.speed[nextPoint];
            float deltaD = points.distance[nextPoint] - points.distance[currentPoint];

            acceleration = ((float)(targetSpeed*targetSpeed) - (float)(currentSpeed*currentSpeed)) / (float)(2*deltaD);
        }

        else
        {
            acceleration = 0;
        }

    }
}
