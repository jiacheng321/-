using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cimb : MonoBehaviour
{
    //[SerializeField, Range(90, 180)]
    //float maxClimbAngle = 140f;
    //float minGroundDotProduct, minStairsDotProduct, minClimbDotProduct;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnValidate()
    {
        //minGroundDotProduct = Mathf.Cos(maxGroundAngle * Mathf.Deg2Rad);
       // minStairsDotProduct = Mathf.Cos(maxStairsAngle * Mathf.Deg2Rad);
       // minClimbDotProduct = Mathf.Cos(maxClimbAngle * Mathf.Deg2Rad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
