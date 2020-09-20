using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolScript : StateMachineBehaviour
{
    private Transform playerPos;
    public NavMeshAgent agent;
    public Transform[] points;
    private int destPoint;
    private float waitTime;
    public float startWaitTime;
    public Enemy1ScriptableObject myScriptableObj;
    
    public float speed;
    public float proximityRange; 
    public float searchRange;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        proximityRange = myScriptableObj.proximRange;
        searchRange = myScriptableObj.searchRange;

        points = myScriptableObj.points;

        playerPos = GameObject.FindWithTag("Player").transform;
        waitTime = startWaitTime;
        destPoint = Random.Range(0, points.Length);

        if (myScriptableObj.agent)
        {
            agent = GameObject.FindWithTag("Enemy1").GetComponent<NavMeshAgent>();
        }
        else
        {
            agent = GameObject.FindWithTag("Enemy2").GetComponent<NavMeshAgent>();
        }
        
    }


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {

        if (Vector3.Distance(agent.transform.position, playerPos.position) <= searchRange)
        {
            animator.SetBool("IsFollowing", true);
            animator.SetBool("IsPatrolling", false);
            animator.SetBool("IsIdle", false);
            return;
        }

        agent.destination = points[destPoint].position;
        myScriptableObj.direccionAgente = agent.destination;
        if (Vector3.Distance(agent.transform.position, points[destPoint].position) < proximityRange)
        {
            if (waitTime >=0)
            {
                waitTime -= Time.deltaTime;
                //Debug.Log("waitTime: " + waitTime);
               
            }
            else
            {
                destPoint = Random.Range(0, points.Length);
                waitTime = startWaitTime;
                agent.destination = points[destPoint].position;
                myScriptableObj.direccionAgente = agent.destination;
            }
        }
        //Debug.LogWarning("points[destPoint] : " + points[destPoint]);
        //Debug.Log("waitTime: " + waitTime);
        if (Vector3.Distance(agent.destination, animator.transform.position) <= 1f)
        {
            agent.velocity = Vector3.zero;
        }
        agent.velocity.Normalize();

    }
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
