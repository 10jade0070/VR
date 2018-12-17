using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Transform[] points = GetComponentsInChildren<Transform>();
        int next = 1;
        Vector3 cPos = points[next].position;
        Vector3 nPos;
        for (int i = 2; i < points.Length; i++)
        {
            nPos = points[i].position;
            Gizmos.DrawLine(cPos, nPos);
            cPos = nPos;
        }
    }
}
