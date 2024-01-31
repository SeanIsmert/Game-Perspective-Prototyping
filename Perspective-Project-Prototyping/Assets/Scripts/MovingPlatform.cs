using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float _speed;
    
    private float _previousWaypoint;
    private float _nextWaypoint;
    private float _targetWaypoint;
    private float _targetWaypointIndex;
    private float _waypointPath;
    private float _getNextWaypoint;
    private float _getWaypoint;
    private float _timeToWaypoint;
    private float _elapsedTime;
    void Start()
    {
        TargetNextWaypoint();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        _elapsedTime += Time.deltaTime;

        float elapsedPercentage = _elapsedTime / _timeToWaypoint;
        elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
        transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, elapsedPercentage);

        //transform.rotation Quarternion.Lerp(_previousWaypoint.rotation, _targetWapoint.rotation);
        if (elapsedPercentage >= 1)
        {
            TargetNextWaypoint();
        }

    }

    private void TargetNextWaypoint()
    {
        _previousWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
        _targetWaypointIndex = _waypointPath.GetNextWaypoint(_targetWaypointIndex);
        _targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);

        _elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position);
        _timeToWaypoint = distanceToWaypoint / _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        { 
            other.transform.SetParent(transform);
        }
    }
}
