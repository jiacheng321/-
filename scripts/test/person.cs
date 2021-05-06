using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class person : MonoBehaviour
{
    Animator at;
    // Start is called before the first frame update
    void Start()
    {
        at = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //int id = at.GetLayerIndex("st");
        //AnimatorTransitionInfo aaa = at.GetAnimatorTransitionInfo(55);
        AnimatorStateInfo aaaa = at.GetCurrentAnimatorStateInfo(6666);
        AnimatorStateInfo aaaaaw = at.GetNextAnimatorStateInfo(7777);


        if (Input.GetKey(KeyCode.L))
        {
            at.Play("LoWall_LBoost_All");
        }
        if (Input.GetKey(KeyCode.P))
        {
            at.SetInteger("ann", 5);
        }
    }
}
