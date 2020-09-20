using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAnimatorControllerScript : MonoBehaviour
{
    public AudioSource shoosound;
    public AudioClip audioclip;
    public Animator myanimator;
    public GameObject light;
    public CharacterMovement charactermovement;
    bool firewait;
    // Start is called before the first frame update
    void Start()
    {
        light.SetActive(false);
        firewait = false;
    }

    // Update is called once per frame
    void Update()
    {
        //myanimator.SetBool("Fire", false);
        myanimator.SetBool("BlockFire", firewait);
        
        if (charactermovement.currentNormalizedSpeed > 0.1)
        {
            myanimator.SetBool("Run", true);
        }
        else
        {
            myanimator.SetBool("Run", false);
        }
        if (Input.GetButton("Dash"))
        {
            myanimator.SetBool("Sprint", true);
        }
        else
        {
            myanimator.SetBool("Sprint", false);
        }
        if (Input.GetButtonDown("Fire1") && !firewait)
        {
            light.SetActive(true);
            shoosound.PlayOneShot(audioclip);
            StartCoroutine(StopLight());
            myanimator.SetBool("Fire", true);
            firewait = true;
            StartCoroutine(StopFiring());
        }

    }
    IEnumerator StopLight()
    {
        yield return new WaitForSeconds(0.25f);
        myanimator.SetBool("Fire", false);
        light.SetActive(false);
    }

    IEnumerator StopFiring()
    {
        yield return new WaitForSeconds(1f);
        firewait = false;
    }
}
