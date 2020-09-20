using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PursuitScript : StateMachineBehaviour
{
    public Enemy1ScriptableObject myScriptableObj;
    private NavMeshAgent agent;
    private Transform playerPos;
    public float speed;
    public float searchRange;
    public float proximityRange;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        proximityRange = myScriptableObj.proximRange;
        searchRange = myScriptableObj.searchRange;
        playerPos = GameObject.FindWithTag("Player").transform;
        if (myScriptableObj.agent)
        {
            agent = GameObject.FindWithTag("Enemy1").GetComponent<NavMeshAgent>();
        }
        else
        {
            agent = GameObject.FindWithTag("Enemy2").GetComponent<NavMeshAgent>();
        }
    }

   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.transform.position = Vector3.MoveTowards(animator.transform.position, playerPos.position, speed * Time.deltaTime);
        agent.destination = playerPos.position;
        myScriptableObj.direccionAgente = agent.destination;
        if (Vector3.Distance(animator.transform.position, playerPos.position) > searchRange) //paso a patrol
        {
            
            animator.SetBool("IsAttacking", false);
            animator.SetBool("IsFollowing", false);
            animator.SetBool("IsPatrolling", true);
            animator.SetBool("IsIdle", false);
            return;
        }
        if (Vector3.Distance(animator.transform.position, playerPos.position) < proximityRange) //paso a attack
        {
            agent.velocity = Vector3.zero;
            agent.velocity.Normalize();

            animator.SetBool("IsAttacking", true);
            animator.SetBool("IsFollowing", false);
            animator.SetBool("IsPatrolling", false);
            animator.SetBool("IsIdle", false);

        }
    }

   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

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
