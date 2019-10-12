using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerCoasterController : MonoBehaviour
{
    //Path to follow
    public PathCreation.PathCreator path;
    private bool hasStarted = false;
    private float currentSpeed = 1;
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

    }
}
