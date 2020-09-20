using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AttackScript : StateMachineBehaviour
{
    
    public Enemy1ScriptableObject myScriptableObj;
    public PlayerScriptable PlayerScriptable; 
    private NavMeshAgent agent;
    private Transform playerPos;
    private GameObject player; 
    public float searchRange = 7.5f;
    public float proximityRange = 1.0f;
    public float attackTime =2.6f;

    // Start is called before the first frame update
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        playerPos = GameObject.FindWithTag("Player").transform;
        player = GameObject.FindWithTag("Player");
        if (myScriptableObj.agent)
        {
            agent = GameObject.FindWithTag("Enemy1").GetComponent<NavMeshAgent>();
            //attackTime = 2.6f;
        }
        else
        {
            agent = GameObject.FindWithTag("Enemy2").GetComponent<NavMeshAgent>();
            //attackTime = 4f;
        }
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    if(attackTime <= 0 && myScriptableObj.agent)
    {
        PlayerScriptable.hp -=25;
        attackTime = 2.6f;
    }
    else if (attackTime <= 0 && !myScriptableObj.agent)
    {
        PlayerScriptable.hp -=50;
        attackTime = 3.6f;
    }
    else
    {
        attackTime -= Time.deltaTime;
    }
        
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
