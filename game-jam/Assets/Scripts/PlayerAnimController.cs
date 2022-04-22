using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D _rigidbody2d;

    [SerializeField] string idleAnim;
    [SerializeField] string runAnim;
    private Dictionary<eAnimName,string> animations = new Dictionary<eAnimName,string>();
    private void Awake()
    {
        animations = new Dictionary<eAnimName, string>()
        {
            {eAnimName.IDLE, idleAnim},
            {eAnimName.RUN, runAnim},
        };
    }


    public void PlayAnim(eAnimName name)
    {
        animator.Play(animations[name]);
    }


    private void Update()
    {
        if(_rigidbody2d.velocity.magnitude > 0)
        {
            PlayAnim(eAnimName.RUN);
        }
        else
        {
            PlayAnim(eAnimName.IDLE);    
        }
    }
}

public enum eAnimName
{
    IDLE,
    RUN,
}
