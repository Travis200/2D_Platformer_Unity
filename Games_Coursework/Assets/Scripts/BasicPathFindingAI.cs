using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// This is my basic pathfinding script where enemies will chase you on a flat platform.
/// </summary>
public class BasicPathFindingAI : MonoBehaviour
{

    public Transform transformPlayer;
    public Transform transformEnemy;
    public float enemyMoventSpeed = 1.5f;


    // Update is called once per frame
    void Update()   
    {

        // Check the distance between the player and enemy is short enough to start chasing
        if (Math.Abs(transformPlayer.position.x - transformEnemy.position.x) < 100)
        {
            if (transformPlayer.position.x < transformEnemy.position.x)
            {

                // Enemy move left
                transformEnemy.position += new Vector3(-1f, 0f, 0f) * Time.deltaTime * enemyMoventSpeed;

            }
            else if (transformPlayer.position.x > transformEnemy.position.x)
                // Enemy move right
                transformEnemy.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * enemyMoventSpeed;
        }
    }
}
