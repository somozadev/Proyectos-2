using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingGizmos : MonoBehaviour
{


    public Enemy1ScriptableObject myScriptableObj;
    public Vector3 direccionEnemigo;
    public float proximRange; //es igual en patrol, pursuit, attack
    public float searchRange; //es igual en patrol, pursuit, attack
    public float rangeDetection; //del idle

    private void Awake()
    {
        

        proximRange = myScriptableObj.proximRange;
        searchRange = myScriptableObj.searchRange;


       
        rangeDetection = myScriptableObj.rangeDetection;

        direccionEnemigo = myScriptableObj.direccionAgente;

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.gameObject.transform.position , proximRange);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, searchRange);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, rangeDetection);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(direccionEnemigo, 1.5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direccionEnemigo = myScriptableObj.direccionAgente;
    }
}
