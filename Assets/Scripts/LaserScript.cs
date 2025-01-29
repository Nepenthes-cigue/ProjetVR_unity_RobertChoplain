using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    const uint NO_COLLISION_DISTANCE = 5000;

    public LineRenderer lineRenderer;
    void Start()
    {
    }

    void Update()
    {
        /* Reset starting point */
        lineRenderer.SetPosition(0, transform.position);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit) && hit.collider)
        {
            /* If we hit something, set end point to what we hit */
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            /* Else there's nothing in front - set end point very far away */
            lineRenderer.SetPosition(1, transform.position + transform.forward * NO_COLLISION_DISTANCE);
        }
    }
}