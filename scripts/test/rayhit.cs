using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayhit : MonoBehaviour
{
    Ray rr;
    RaycastHit rhh;
    Vector3 vvvv,vkkk,vjj,vvv4;
    Rigidbody rbb2;
    // Start is called before the first frame update
    void Start()
    {
        vvv4 = new Vector3(0, 10, 0);
        vjj = new Vector3(0, 100, 0);
        rbb2 = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out rhh)){
            Debug.Log("ok");
        }
        vkkk = this.transform.position;
        vvvv = new Vector3(vkkk.x, vkkk.y-5, vkkk.z );
  

        rr = new Ray(vkkk,this.transform.TransformDirection(Vector3.down));
//Debug.DrawLine(vkkk, vvvv);
        Debug.DrawLine(rr.origin, rhh.point);
        if ( Physics.Raycast(rr, out rhh, 10))
        {
            Debug.DrawLine(rr.origin, rhh.point);
           Debug.Log(rhh.collider);
            Debug.Log(rhh.normal);
            Debug.Log(rhh.textureCoord);    
        }

        Collider cce = Physics.OverlapSphere(vkkk, 5)[0];
        Debug.Log(cce);

    }
}
