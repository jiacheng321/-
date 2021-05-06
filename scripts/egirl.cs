using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class egirl : MonoBehaviour
{
    [SerializeField]
    GameObject erz;
    private int b;
    public egirl()
    {
        this.B = 100;
    }       
    object bl,blue;
    Quaternion q;
    static int bbleed,jiangzhi;
    static bool  isalive;
    Animator a;
    static Vector3 old,newt;
    GameObject mainrole;
    public static bool normal;

    public int B { get => b; set => b = value; }
    public void changeeee(ref int bbbb ,int qq)
    {
        bbbb -= qq;
    }
    // Start is called before the first frame update
    private void Awake()
    {
        a = this.GetComponent<Animator>();
    }
    void Start()
    {
        bbleed = 100;
        jiangzhi = 3;
        bl = bbleed;        
        mainrole = GameObject.Find("Man_111");
   
        normal = true;
        Vector3 old = transform.position;
        addanimation("hp_straight_right_A");
    }
    // Update is called once per frame
    void Update()
    {
       // Vector3 vg= new Vector3(0, Vector3.Angle(this.transform.forward, mainrole.transform.position - transform.position), 0);
        //q.eulerAngles = vg;
        //this.transform.rotation = q;     
        this.transform.LookAt(mainrole.transform);
        if (bbleed > 0&&jiangzhi >0)
        {

            if (Vector3.Distance(this.transform.position, mainrole.transform.position) > 1)
            {      
                this.transform.position = Vector3.MoveTowards(this.transform.position, mainrole.transform.position-new Vector3(0,mainrole.transform.position.y,0), 3* Time.deltaTime);
                a.SetInteger("run", 10);
                newt = this.transform.position;
            }
            else if(Vector3.Distance(this.transform.position, mainrole.transform.position) <1)
            {
                a.SetInteger("run", 15);
                a.SetTrigger("k");
   
            }
        }
        else
        {
            a.SetInteger("ann", 10);
        }
    }
    public void attack3()
    {
        Collider[] ce = Physics.OverlapSphere(this.transform.position, 1f);
        foreach (var va in ce)
        {
            float angle = Vector3.Angle(this.transform.forward, va.transform.position - transform.position);
            if (angle < 60.0f && va.gameObject.tag == "main")
            {
                Vector3 vv = new Vector3(transform.position.x + 0.1f, transform.position.y + 1.5f, transform.position.z + 1);
               // GameObject.Instantiate(Resources.Load("能量盾", typeof(GameObject)), vv, Quaternion.identity);
                va.gameObject.SendMessage("behurt", 10);
            }
        }
    }
    public void behurt(int q)
    {
        this.B -= q;
      
        Debug.Log(this.B);
    }
    public void addanimation(string clip)
    {
        AnimationClip[] clips = a.runtimeAnimatorController.animationClips;
        for(int i = 0; i < clips.Length; i++)
        {
            if (string.Equals(clips[i].name, clip))
            {
                AnimationEvent events = new AnimationEvent();
                events.functionName = "attack3";
                events.time = 0.02f;               
                clips[i].AddEvent(events);
                break;
            }
        }
        a.Rebind();
    }
    public void enent0()
    {

    }
    private void OnDestroy()
    {
        
    }
}
