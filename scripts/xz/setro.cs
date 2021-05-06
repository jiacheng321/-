using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setro : MonoBehaviour

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

        q.SetFromToRotation(A.position, B.position);
        C.rotation = q;
        Debug.DrawLine(Vector3.zero, A.position, Color.red);
        Debug.DrawLine(Vector3.zero, B.position, Color.green);
        Debug.DrawLine(C.position, C.position + new Vector3(0.0f, 1.0f, 0.0f), Color.black);
        Debug.DrawLine(C.position, C.TransformPoint(Vector3.up * 1.5f), Color.yellow);
    }
}
