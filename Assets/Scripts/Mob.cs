using UnityEngine;
using static GlobalVariables;

public class Mob : MonoBehaviour
{
    [SerializeField] MobMovementTypes movementType;
    // If start and end points are equal, repeat the path
    // If different, return the path from end to start
    [SerializeField] GameObject waypoints;
    [SerializeField] float observeTime;

    // For wander movements
    public Vector3 spawnerPosition;
    Vector3 nextWanderPoint;
    [SerializeField] float wanderRadius;

    int currentWaypointIndex = 0;
    [SerializeField] float speed = 50f;

    float time = 0;
    bool moving = false;
    bool looping = false;

    void Start()
    {
        if (movementType == MobMovementTypes.Patrol)
        {
            if (waypoints.transform.childCount > 0)
            {
                currentWaypointIndex = 0;
                // if your coordinates and last coordinates are the same, this mob is looping
                if (transform.position == waypoints.transform.GetChild(waypoints.transform.childCount - 1).position)
                {
                    looping = true;
                }
            }
        } else if (movementType == MobMovementTypes.Wander)
        {
            Vector2 pos = Random.insideUnitCircle;
            nextWanderPoint = new Vector3(pos.x, 0.75f, pos.y).normalized * wanderRadius + spawnerPosition;
        }
    }

    void Update()
    {
        if (moving)
        {
            if (movementType == MobMovementTypes.Patrol)
            {
                FollowPath();
            }
            else if (movementType == MobMovementTypes.Wander)
            {
                WalkRandomly();
            }
        }
        else
        {
            // observing
            if (time > observeTime)
            {
                // observing is over keep moving
                moving = true;
                time = 0;
            }
            else
            {
                time += Time.deltaTime;
            }
        }
    }

    void FollowPath()
    {
        if (currentWaypointIndex < waypoints.transform.childCount)
        {
            if (transform.position != waypoints.transform.GetChild(currentWaypointIndex).position)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    waypoints.transform.GetChild(currentWaypointIndex).position,
                    speed * Time.deltaTime);
            }
            else
            {
                currentWaypointIndex++;
                // reached a waypoint, start observing
                moving = false;
            }
        }
        else
        {
            if (looping)
            {
                currentWaypointIndex = 0;
            }
        }
    }

    void WalkRandomly()
    {
        if (transform.position != nextWanderPoint)
        {
            Debug.Log(nextWanderPoint);
            transform.position = Vector3.MoveTowards(transform.position, nextWanderPoint, speed * Time.deltaTime);
        } else
        {
            moving = false;
            Vector2 pos = Random.insideUnitCircle;
            nextWanderPoint = new Vector3(pos.x, 0.75f, pos.y).normalized * wanderRadius + spawnerPosition;
        }
    }
}

