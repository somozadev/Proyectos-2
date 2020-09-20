using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ShaderScript : MonoBehaviour
{  
    [SerializeField]
    public float radius;
 
    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalVector("_Position", transform.position);
        Shader.SetGlobalFloat("_Radius", radius);
    }
}