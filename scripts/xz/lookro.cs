using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sd : MonoBehaviour
{
    public GameObject a, b, c;
    public Transform A, B, C;
    Quaternion q = Quaternion.identity;
    // Use this for initialization
    void Start()
    {

        A = a.GetComponent<Transform>();
        B = b.GetComponent<Transform>();
        C = c.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        q.SetLookRotation(A.position, B.position);
        C.rotation = q;
        Debug.DrawLine(Vector3.zero, A.position, Color.red);
        Debug.DrawLine(Vector3.zero, B.position, Color.green);
        Debug.DrawLine(C.position, C.TransformPoint(Vector3.right * 1.5f), Color.black);
        Debug.DrawLine(C.position, C.TransformPoint(Vector3.forward * 1.5f), Color.yellow);

        Debug.Log("C.right与A的夹角: " + Vector3.Angle(C.right, A.position));
        Debug.Log("C.right与B的夹角: " + Vector3.Angle(C.right, B.position));
        Debug.Log("C.up与B的夹角: " + Vector3.Angle(C.up, B.position));
    }
}