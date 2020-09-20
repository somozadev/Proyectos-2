using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AttackScript : StateMachineBehaviour
{
    public Enemy1ScriptableObject myScriptableObj;
    private NavMeshAgent agent;
    private Transform playerPos;
    public float searchRange = 7.5f;
    public float proximityRange = 1.0f;

    // Start is called before the first frame update
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
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


        //hacer pupa a player si esta en rango de ataque 


        if (Vector3.Distance(animator.transform.position, playerPos.position) > searchRange) //paso a patrol
        {
            animator.SetBool("IsAttacking", false);
            animator.SetBool("IsFollowing", false);
            animator.SetBool("IsPatrolling", true);
            animator.SetBool("IsIdle", false);
            return;
        }
        if (Vector3.Distance(animator.transform.position, playerPos.position) > proximityRange && Vector3.Distance(animator.transform.position, playerPos.position) < searchRange) //paso a pursuite
        {
            agent.destination = playerPos.transform.position;
            myScriptableObj.direccionAgente = agent.destination;
            animator.SetBool("IsAttacking", false);
            animator.SetBool("IsFollowing", true);
            animator.SetBool("IsPatrolling", false);
            animator.SetBool("IsIdle", false);
            return;
        }
        
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
