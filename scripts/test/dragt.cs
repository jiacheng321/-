using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class dragt :  MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField]
    GameObject parcel;
    public Vector2 v2;
    public Image imm;
    static GameObject zc;
    static public Vector3 screenc,b;
    static Vector2 vff,vb;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("start drag");
       //this.transform.SetParent(zc.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Canvas ccs = parcel.GetComponent<Canvas>();

        imm.rectTransform.position = vff;
        Debug.Log(" draging");

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject go = eventData.pointerCurrentRaycast.gameObject;//获取鼠标落下gameobject
        Debug.Log(go);
        if (go.CompareTag("indeedp"))
        {
            this.transform.SetParent(go.transform.parent);
        }
        this.transform.position = b;
        Debug.Log("end draging");
    }

    // Start is called before the first frame update
    void Start()
    {
       
        imm = this.GetComponent<Image>();
        screenc = new Vector3(0, 2, 4);
        b = new Vector3(10, 0, 4);
        zc = GameObject.Find("package1");

    }

    // Update is called once per frame
    void Update()
    {
        vb.x = Random.Range(0, 200);
        vb.y=  Random.Range(0, 200);
        Canvas ccs = parcel.GetComponent<Canvas>();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(ccs.transform as RectTransform, Input.mousePosition, Camera.current, out Vector2 llll1);
        vff = llll1;
        vff.x += 300;
        vff.y += 200;
            
    }
}
