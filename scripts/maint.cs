using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maint : MonoBehaviour
{
    GameObject mainrole,enmy,uiy;
    roletran role;
    Vector3 v1, v2, v3, v4, v5;
    Quaternion q1, q2, q3, q4;
    static UnityEngine.Object o1;

    
    // Start is called before the first frame update
    void Start()
    {
        v4 = new Vector3(1.5f, 0, 1.5f); 
        mainrole = GameObject.Find("Man_11");
        StartCoroutine("loopi");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {       
     
        }
    }
    public void attcak(int h)
    {
     
        //mainrole.SendMessage("hurt",1);
    }
  public  IEnumerator loopi()
    {
        for (int i=100;i>0;i--) {
            int x = Random.Range(0, 20);
            
            int z = Random.Range(0, 20);
            Vector3 vv = new Vector3(x, 0, z);
            GameObject.Instantiate(Resources.Load("girl", typeof(GameObject)), vv,Quaternion.identity);
            yield return new WaitForSeconds(1000f);
        }
    }
}
