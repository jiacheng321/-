using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animat : MonoBehaviour
{
    int q;
    int skill;
    [SerializeField]
    int id;
    static Animator am;
    AnimatorStateInfo ai;
    public int Q { get => q; set => q = value; }
    public int Skill { get => skill; set => skill = value; }
    ObjectPool opp;
    // Start is called before the first frame update
    private void Awake()
    {
        am = this.GetComponent<Animator>();
        opp = new ObjectPool();
    }
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
     
        change();
        //if (Input.GetKeyDown(KeyCode.K))
       // {
       // }
    }
    void change()
    {
        if (Input.GetKeyDown(KeyCode.J) )
        {
   
             if (am.GetCurrentAnimatorStateInfo(0).IsName("hp_straight_right_A")&& am.GetCurrentAnimatorStateInfo(0).normalizedTime>0.7)
            {
                am.Play("bk_rh_right_A");
                attack3();
                // am.SetInteger("lianji", 2);
            }
            else if (am.GetCurrentAnimatorStateInfo(0).IsName("bk_rh_right_A") && am.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7)
            {
                am.Play("hp_upper_right_A");
                attack3();
                // am.SetInteger("lianji", 3);
            }
            else 
            {
                // am.Play("hp_straight_right_A");
                am.SetTrigger("k");
                attack3();

            }
        }
      
    }
    public void attack3()
    {
        Collider[] ce = Physics.OverlapSphere(this.transform.position, 0.5f);
        foreach (var va in ce)
        {           
            float angle = Vector3.Angle(this.transform.forward, va.transform.position-transform.position);
            if (angle < 60.0f )
            {
                Vector3 vv = new Vector3(transform.position.x+0.1f, transform.position.y+1.5f, transform.position.z+1);
                GameObject.Instantiate(Resources.Load("能量盾", typeof(GameObject)), vv, Quaternion.identity);
                va.gameObject.SendMessage("behurt", 10);      
            }          
        }
    }
}