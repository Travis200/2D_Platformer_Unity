using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

/// <summary>
/// This class is used to for a flying enemy to be able to follow the player with the help of the Pathfinding library.
/// </summary>
public class FlyingPathfindingAI : MonoBehaviour
{
    // Declare all fields that appear in the inspector
    [SerializeField] private Transform defaultEnemyPos;
    [SerializeField] private Transform target;
    [SerializeField] private Transform gridCenter;
    [SerializeField] private Seeker seeker;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform enemyTransform;
    // Declare all variables that appear in the inspector
    public float enemySpeed = 350f;
    public float nextWaypointDistance = 3f;
    private int currentWaypoint = 0;

    private Path path;

    // Start is called before the first frame update
    void Start()
    {

        seeker.StartPath(rb.position, defaultEnemyPos.position, OnPathComplete);

        // Updates the path to follow the player every 0.25 seconds.
        InvokeRepeating("UpdatePath", 0f, 0.25f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }

        else if (currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }


        // The direction to travel is calculated by subtracting the sprites current position from the current waypoint and then
        // normalized so the length is 1.
        Vector2 directionToTravel = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        // Movement force is calculated by multiplier the directionToTravel and enemy speed.
        Vector2 movementForce = directionToTravel * enemySpeed * Time.deltaTime;
        // Calculate distance to next waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);


        // Apply the movent force to the sprite
        rb.AddForce(movementForce);

        // Checks if we have reached the current waypoint
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        // Flip the sprite if the direction of the force is opposite to the direction the sprite is currently travelling
        Vector3 enemyTransformLocal = enemyTransform.localScale;
        if ((movementForce.x > 0 && enemyTransformLocal.x > 0f) || (movementForce.x < 0 && enemyTransformLocal.x < 0f))
        {
            enemyTransformLocal.x *= -1f;
            enemyTransform.localScale = enemyTransformLocal;
        }

    }


    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    /// <summary>
    /// Updates the path from the enemey to the player.
    /// </summary>
    private void UpdatePath()
    {
        // Chases the player if they are inside the A* grid
        if (Math.Abs(target.position.x - gridCenter.position.x) < 17.5)
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
        // Returns to default position
        else
        {
            seeker.StartPath(rb.position, defaultEnemyPos.position, OnPathComplete);
        }
    }

}