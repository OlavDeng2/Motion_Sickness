using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerCoasterController : MonoBehaviour
{
    //Path to follow
    public PathCreation.PathCreator path;
    public SpeedVsDistance points;

    private int currentPoint = 0;
    private float distanceOfCurrentPoint;
    private float distanceOfNextPoint;
    private float distanceBetweenPoints;
    private float speedOfCurrentPoint;
    private float speedOfNextPoint;
    private float acceleration;



    private bool hasStarted = false;
    private float currentSpeed = 4;
    private float distanceTraveled = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        distanceTraveled += currentSpeed * Time.deltaTime;
        transform.position = path.path.GetPointAtDistance(distanceTraveled);
        transform.rotation = path.path.GetRotationAtDistance(distanceTraveled);

        //move to the next point when passing a point
        if (points.distance.Length >= currentPoint+1)
        {
            if (distanceTraveled > points.distance[currentPoint + 1])
            {
                currentPoint += 1;
                SetSpeed();
            }
        }

        currentSpeed += acceleration;

    }

    private void SetSpeed()
    {
        //If there is no future point, keep constant speed
        if (points.distance.Length >= currentPoint + 1)
        {
            //current point is last point that was passed
            //Need to accellerate to next point
            //Accelleration is based on the distance between the points and the target speed of the next point.
            //(v2-v1)/d to get the acceleration. Add that to the speed for every deltaT
            acceleration = (points.speed[currentPoint + 1] - points.speed[currentPoint]) / (points.distance[currentPoint + 1] - points.distance[currentPoint]);
        }

        else
        {
            acceleration = 0;
        }

    }
}
