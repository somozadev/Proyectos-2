using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoorDetection : MonoBehaviour
{
    public Animator myanimator;

    void Start()
    {
        myanimator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            myanimator.SetBool("PlayerIn", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            myanimator.SetBool("PlayerIn", false);
        }
    }
}
