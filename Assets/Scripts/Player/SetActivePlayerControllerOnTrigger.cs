using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActivePlayerControllerOnTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().enabled = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().enabled = false;
        }
    }
}
