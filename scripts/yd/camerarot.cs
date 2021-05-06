using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerarot : MonoBehaviour
{
    Quaternion qw,qr,qe;//qw是差向量的旋转矩阵，qr是摄像机本身的旋转四元数,qe是人物旋转的四元数
    Transform target;
    float dx1, dy1,stretch;
    Vector3 Va,vb,vc;//Va是四元数的欧拉角，vb是差向量,VC是目标人物旋转的欧拉角向量
    // Start is called before the first frame update
    void Start()
    {
        qr = this.transform.rotation;
        stretch = 0.7f;
        target = GameObject.Find("Man_111").GetComponent<Transform>();
        vb = new Vector3(1.8f, 1.6f, -7.0f)*stretch;
        qw = Quaternion.identity;
        Va = this.transform.rotation.eulerAngles;
    }
    // Update is called once per frame
    void Update()
    {      
        this.transform.rotation.SetLookRotation(target.position);
        camerar(ref stretch);
        Debug.DrawRay(target.position, this.transform.position);
    }
    private void LateUpdate()
    {
        this.transform.rotation=qr;
        this.transform.position = target.position + qw * vb*stretch;
    }
    void camerar(ref float stretch )
    {
        stretch -= Input.GetAxis("Mouse ScrollWheel");
        dx1 += Input.GetAxis("Mouse X");
        dy1 = Mathf.Clamp(dy1 + Input.GetAxis("Mouse Y"), 0, 20);
        Va.y = dx1;
        Va.x = dy1;
        qw.eulerAngles = Va;
        qr.eulerAngles = Va;
        vc.y = dx1;
        qe.eulerAngles = vc;
        target.transform.rotation = qe;
    }
}
