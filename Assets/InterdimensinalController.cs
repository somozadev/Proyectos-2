using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterdimensinalController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Dimensional1;
    public GameObject Dimensional2;
    public Animator myanimator;

    public bool Interdimensionaliced;
    void Start()
    {
        Interdimensionaliced = false;
        Dimensional2.SetActive(false);
        Dimensional1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("F") && !Interdimensionaliced)
        {
            myanimator.SetBool("Interdimensional", true);
            StartCoroutine(InterdimensionalJump());
        }
        if (Input.GetButton("F") && Interdimensionaliced)
        {
            myanimator.SetBool("Interdimensional", false);
            StartCoroutine(InterdimensionalReturn());
        }
    }

    IEnumerator InterdimensionalJump()
    {
        yield return new WaitForSeconds(2.16f);
        Interdimensionaliced = true;
        Dimensional1.SetActive(false);
        Dimensional2.SetActive(true);
    }

    IEnumerator InterdimensionalReturn()
    {
        yield return new WaitForSeconds(0.3f);
        Interdimensionaliced = false;
        Dimensional1.SetActive(true);
        Dimensional2.SetActive(false);
    }
}
