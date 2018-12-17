using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AutoDoor : MonoBehaviour
{
    public GameObject leftDoor;
    //public GameObject rightDoor;

    private float originalLeftDoorX;
    //private float originalRightDoorX;



    void Start()
    {
        originalLeftDoorX = leftDoor.transform.position.x;
        //originalRightDoorX = rightDoor.transform.position.x;
    }

    void OpenDoor()
    {
        //rightDoor.transform.DOMoveX(originalRightDoorX + 5f,1f);
        leftDoor.transform.DOMoveX(originalLeftDoorX - 7f,1f);
    }

    void CloseDoor()
    {
        //rightDoor.transform.DOMoveX(originalRightDoorX , 1f);
        leftDoor.transform.DOMoveX(originalLeftDoorX , 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CloseDoor();
        }
    }

}
