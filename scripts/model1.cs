using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class model1 : MonoBehaviour
{
    public Text TxtCurrentTime;
    DateTime t00;
    float t6, t7;
    Time t0;
    GameObject g1, g2, g3,g4, g5;
    public Ray ray1;
    public RaycastHit RaycastHit1;
    // Start is called before the first frame update
    void Start()
    {
       // Stopwatch sw1 = new Stopwatch(); 
        t00 = DateTime.Now.ToLocalTime();
        ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
        t6= Time.time;
        

    }
    private void Awake()
    {
        if(Physics.Raycast(ray1,out RaycastHit1, 100)){
            Debug.DrawLine(ray1.origin, RaycastHit1.point);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            t7 = Time.time;
            Debug.Log(t7 - t6);
        }
        //  Debug.Log(System.DateTime.Now.Second);
        TxtCurrentTime.text = t00.ToString("yyyy-MM-dd HH:mm:ss");
    }
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 v99 = collision.GetContact(0).normal;
        float angle = Vector3.Angle(v99, this.transform.position);//暂时找不到合适的向量
    }
    private void LateUpdate()
    {
         
    }
    private void readdatas()
    {

    
    }
    private float caculatehurt(float a,float b,float c)
    {

        return 0;
    }
    public void detect()
    {

    }
}
