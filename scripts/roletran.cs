using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class roletran : MonoBehaviour
{
    private int b;
    int defend;
    bool normal;
    public roletran()
    {
        this.B = 100;
        this.Defend = 5;
    }
    static Vector3 V1, V2, V3, V4, v5,ver;
    [SerializeField]
    GameObject er;
    [SerializeField]
    public static int floa;

    static float dx, dy, personspeed, st;
    bool isground;
    Animator personam;
    Rigidbody personrb;
    Collider personcc;
    Slider sl;
    public ArrayList ArrayList1 = new ArrayList();
    public egirl eee;
    static Queue myQ;
    static UnityEngine.Object o1;
    Time tt, tt1;
    public int B { get => b; set => b = value; }
    public int Defend { get => defend; set => defend = value; }
    public bool Normal { get => normal; set => normal = value; }
    private void Awake()
    {
        personam = this.GetComponent<Animator>();
        personrb = this.GetComponent<Rigidbody>();
        personcc = this.GetComponent<Collider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        addanimation("hp_straight_right_A");
        floa = 2;
        V4 = new Vector3(0, 0, 0);
        v5 = new Vector3(0, 0, 0);
        //sl = GameObject.Find("Slider1").GetComponent<Slider>();
        Defend = 5;
        isground = true;
        Normal = true;
        personspeed = 4.0f;
   
        myQ = new Queue();
        for (int i = 0; i < 30; i++)
        {
            myQ.Enqueue(Resources.Load("bullet", typeof(GameObject)));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collison");
        if (isground1(0.5f))
        {
            Debug.Log("collison2");
            roletran.floa = 2;
            personam.SetInteger("j", 0);
        }
    }
    private void OnCollisionStay(Collision collision)
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (this.B > 0 && Normal)
        {
            if ((Input.GetKeyDown(KeyCode.Space)) && floa > 0)
            {
                personrb.AddForce(Vector3.up * 200.0f);
                roletran.floa -= 1;
                personam.Play("Jmp_Base_A");
                StartCoroutine("jumpp");
            }
            attack1();            
            move();
            skill1();
        }
    }
    private void LateUpdate()
    {
        transform.Translate(v5 * Time.deltaTime * personspeed);
    }
    void move()
    {
        //if (v5.x==0&&v5.y==0&&v5.z==0)
        if (v5.magnitude == 0)
        {
            personam.SetInteger("run", 15);
        }
        foward();
        left();
        right();
        back();
    }
    void skill1()
    {
        if (Input.GetMouseButton(0))
        {
       
            personam.Play("mixamo_com");
        }
        if (Input.GetMouseButton(1))
        {
            personam.Play("hp_straight_right_A");
        }
    }
    void attack1()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {

            if (personam.GetCurrentAnimatorStateInfo(0).IsName("hp_straight_right_A") && personam.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5)
            {
                personam.Play("bk_rh_right_A");
                attack3();
                // am.SetInteger("lianji", 2);
            }
            else if (personam.GetCurrentAnimatorStateInfo(0).IsName("bk_rh_right_A") && personam.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5)
            {
                personam.Play("hp_upper_right_A");
                attack3();
                // am.SetInteger("lianji", 3);
            }
            else
            {
                // am.Play("hp_straight_right_A");
                personam.SetTrigger("k");
                attack3();
            }
        }
    }
    public void attack3()
    {        
        Collider[] ce = Physics.OverlapSphere(this.transform.position, 0.5f);
        foreach (var va in ce)
        {
            float angle = Vector3.Angle(this.transform.forward, va.transform.position - transform.position);
            if (angle < 60.0f&&va.gameObject.tag=="enmy")
            {
                Vector3 vv = new Vector3(transform.position.x + 0.1f, transform.position.y + 1.5f, transform.position.z + 1);
                GameObject.Instantiate(Resources.Load("能量盾", typeof(GameObject)), vv, Quaternion.identity);
                va.gameObject.SendMessage("behurt", 10);
            }
        }
    }
    public void behurt(int s)
    {
        this.Defend -= 1;
        this.B -= s;
        if (Defend <= 0)
        {
            personam.SetInteger("disable", 1);
            this.Normal = false;
           // StartCoroutine("Cure");
            if (Defend < -100)
            {
                personam.Play("knockdown_A");
            }
        }
        
        Debug.Log(this.B);

    }
    public string getcurrent()
    {
        AnimatorClipInfo[] infos = gameObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0);
        return infos[0].clip.name;
    }
    public bool isground1(float height)
    {
        Ray re = new Ray(this.transform.position, this.transform.TransformDirection(Vector3.down));
        RaycastHit rh;
        if (Physics.Raycast(re, out rh, height))//0.1检测是否在地上，0.5检测是否跳跃落地动画，-0.2检车头顶是否有碰撞体
        {
            return true;
        }
        else return false;
    }
    public void foward()
    {
        if (Input.GetKeyDown(KeyCode.W) && isground && Normal)
        {      
            personam.SetInteger("run", 10);
            v5 += Vector3.forward;
        }
        else if (Input.GetKeyUp(KeyCode.W) && isground && Normal)
        {
            v5 -= Vector3.forward;
        }
    }
    public void back()
    {
        if (Input.GetKeyDown(KeyCode.S) && isground && Normal)
        {
            personam.SetInteger("run", 2);
            v5 += Vector3.back;
        }
        else if (Input.GetKeyUp(KeyCode.S) && isground && Normal)
        {
            v5 -= Vector3.back;
        }
    }
    public void left()
    {
        if (Input.GetKeyDown(KeyCode.A) && isground && Normal)
        {
            personam.SetInteger("run", 10);
            v5 += Vector3.left;
        }
        else if (Input.GetKeyUp(KeyCode.A) && isground && Normal)
        {
            v5 -= Vector3.left;
        }
    }
    public void right()
    {
        if (Input.GetKeyDown(KeyCode.D) && isground && Normal)
        {
            personam.SetInteger("run", 10);
            v5 += Vector3.right;
        }
        else if (Input.GetKeyUp(KeyCode.D) && isground && Normal)
        {
            v5 -= Vector3.right;
        }
    }
    public IEnumerator jumpp()
    {                 
        while (!isground1(0.3f))
        {
            yield return null;
        }
        personam.SetInteger("jump", 2);
        yield return null;
    }
    public IEnumerator Cure()
    {
        yield return new  WaitForSeconds(2);
        this.Normal = true;
        yield return null;
    }
    public void addanimation(string clip)
    {
        AnimationClip[] clips = personam.runtimeAnimatorController.animationClips;
        for (int i = 0; i < clips.Length; i++)
        {
            if (string.Equals(clips[i].name, clip))
            {
                AnimationEvent events = new AnimationEvent();
                events.functionName = "attack3";
                events.time = 0.05f;
                clips[i].AddEvent(events);
                break;
            }
        }
        personam.Rebind();
    }
}



