using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class pubfuctuin : MonoBehaviour
{
    [SerializeReference]
    GameObject hj;
 
    Image ik;
    Sprite ses;
    //List<Sprite> packe = new List<Sprite>(10);
    // Start is called before the first frame update
    void Start()
    {
        ik = hj.GetComponent<Image>();

        UnityEngine.Object o1 = Resources.Load("SpellBookPreface_02", typeof(Sprite));
        ses = Instantiate(o1) as Sprite;

    }
    //测试
    // Update is called once per frame
    void Update()
    {

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
    public void attack3()
    {
        Collider[] ce = Physics.OverlapSphere(this.transform.position, 4.0f);
        foreach (var va in ce)
        {
            float angle = Vector3.Angle(this.transform.TransformDirection(Vector3.forward), va.transform.position);
            if (angle < 50.0f && va.gameObject.CompareTag(" player"))
            {
                va.gameObject.SendMessage("behurt", 10);
            }
        }
    }
    public void open()
    {
        GameObject tempt = GameObject.Find("Image45");
        tempt.GetComponent<CanvasGroup>().alpha = 1;
        tempt.GetComponent<CanvasGroup>().interactable = true;
        tempt.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public GameObject GetOverUI(GameObject canvas)
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;
        GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(pointerEventData, results);
        if (results.Count != 0)
        {
            return results[0].gameObject;
        }

        return null;
    }
}
