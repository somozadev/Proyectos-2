using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleScript : StateMachineBehaviour 
{
   
    public Enemy1ScriptableObject myScriptableObj;
    private Transform playerPos;
    public float rangeDetection;
    private float waitTime;
    public float startWaitTime = 9f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        Quaternion rotation = Quaternion.LookRotation(Vector3.zero);
        rangeDetection = myScriptableObj.rangeDetection;
        playerPos = GameObject.FindWithTag("Player").transform;
    }

   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(playerPos.transform.position, animator.transform.position) <= rangeDetection)
        {
            
            animator.SetBool("IsFollowing", true);
            animator.SetBool("IsPatrolling", false);
            animator.SetBool("IsIdle", false);
        }
        else
        {
            if (waitTime >= 0)
            {
                waitTime -= Time.deltaTime;
                
        myScriptableObj.direccionAgente = Vector3.forward;
            }
            else
            {
                waitTime = startWaitTime;
                animator.SetBool("IsFollowing", false);
                animator.SetBool("IsPatrolling", true);
                animator.SetBool("IsIdle", false);
            }

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
