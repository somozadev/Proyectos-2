using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachine1 : MonoBehaviour
{
    Rigidbody rb;

    public int tiempoEntreNuevoPunto  = 20;
    public Transform[] points;
    [SerializeField]
    private int destPoint = 0;
    [SerializeField]
    private NavMeshAgent agent;
     
    public enum States { patrol, pursuit, pause, attack, notice}
    public States state = States.patrol;
    public float stoppingDistance = 0.5f;
    public float searchRange = 7.5f;
    public float lookRange = 2.0f;
    public Transform player;
    public Vector3 target;
    RaycastHit hit;
    GameObject objectInCollisionWithRaycast;
    
    public int ext; 
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false; 
        player = GameObject.FindWithTag("Player").transform;
        InvokeRepeating("SetTarget", 0, tiempoEntreNuevoPunto); 
    }
    void GotoNextPoint()
    {
        agent.enabled = true;
        if (points.Length == 0)
            return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
        
       
    }
    void SetTarget()
    {
        if (state == States.pursuit  )
        {
            return;
        }
        
        GotoNextPoint();

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, searchRange);
        Gizmos.color = Color.red; 
        Gizmos.DrawWireSphere(drawAgentDestination, 1f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, lookRange);
    }
        

    Vector3 drawAgentDestination;
    void Update()
    {
        drawAgentDestination = agent.destination;
        

        if (state == States.pursuit)
        {
            
            agent.destination = player.position;
            
            if (Vector3.Distance(agent.destination, transform.position) > searchRange)//si player esta fuera de rango 
            {
                
                agent.destination = points[destPoint].position;
                state = States.patrol;
                return;
            }
            if (Vector3.Distance(agent.destination, transform.position) < lookRange)
            {
                agent.velocity = Vector3.zero;
            }
            agent.velocity.Normalize();
        }
        else if (state == States.patrol)
        {

            if (Vector3.Distance(agent.transform.position, GameObject.FindWithTag("Player").transform.position) <= searchRange )
            {
                state = States.pursuit;
                return;
            }



            
            agent.destination = points[destPoint].position;
            if (Vector3.Distance(agent.destination, transform.position) <=1f)
            {
                agent.velocity = Vector3.zero;
                Debug.Log("AA");
                //agent.transform.position = agent.destination;
            }
            agent.velocity.Normalize();
        }
        foreach (Transform point in points)
        {
            if (agent.destination == point.transform.position)
            {
                agent.enabled = false; 
            }
        }
        
    }
}
