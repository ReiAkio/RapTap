using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : StateMachineBehaviour
{
    [SerializeField] private int nLoops;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("nLoops", nLoops);
    }
}
