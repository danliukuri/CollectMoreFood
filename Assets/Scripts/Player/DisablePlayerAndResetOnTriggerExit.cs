using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayerAndResetOnTriggerExit : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            other.GetComponent<Rigidbody>().Sleep();
        }
    }
}
