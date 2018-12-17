using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 1.0f;
    public float damping = 3.0f;
    private Transform tr;
    private Transform[] points;
    private int nextIdx = 1;
    enum STATE { MOVE, STOP }
    private STATE state;
   
    void Start()
    {
        tr = GetComponent<Transform>();
        points = GameObject.Find("Waypoints").GetComponentsInChildren<Transform>();
        state = STATE.MOVE;
     }

    private void Update()
    {
        if (state == STATE.MOVE)
        {
            Vector3 direction = points[nextIdx].position - tr.position;
            Quaternion rot = Quaternion.LookRotation(direction);
            tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);
            tr.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WAY_POINT"))
        {
            if (nextIdx + 1 >= points.Length)
            {
                state = STATE.STOP;
            }
            else
            {
                ++nextIdx;
            }
        }
    }

}
