using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to control moving platforms.
/// </summary>
public class Platform : MonoBehaviour
{
    [SerializeField] private Transform pos1;
    [SerializeField] private Transform pos2;
    private Vector3 nextPos;
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = pos1.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    /// <summary>
    /// Draws a Gizmos on of the path that the platform will travel.
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

}
