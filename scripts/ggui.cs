using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ggui : MonoBehaviour
{
    [SerializeField]
    GameObject m1, m2, m3, m4,im5, im6, im7,parcel;
    static Transform[] gp;
    Animator am3;
    Image i1, i2, i3;
    public Text t11;
    RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        t11 = GameObject.Find("htt").GetComponent<Text>();    
        am3 = m3.GetComponent<Animator>();
        i2 = im5.GetComponent<Image>();
        i3 = im6.GetComponent<Image>();
        i1 = im7.GetComponent<Image>();
   
    }

    // Update is called once per fram
    void Update()
    {
        if (Input.GetKey(KeyCode.N))
        {
            //t11.text = "jdddsefk";
            //t11.gameObject.GetComponent<Animator>().Play("text1");
            Canvas ccs = parcel.GetComponent<Canvas>();

           RectTransformUtility.ScreenPointToLocalPointInRectangle(ccs.transform as RectTransform, Input.mousePosition, Camera.current, out Vector2 llll1);
    RectTransformUtility.ScreenPointToLocalPointInRectangle(ccs.transform as RectTransform,im5.transform.position, Camera.current, out Vector2 localPoint );
           // Debug.Log(localPoint);
               Debug.Log(llll1);
        }
        
    }
    public void open()
    {
        GameObject tempt = GameObject.Find("Image45");
        tempt.GetComponent<CanvasGroup>().alpha = 1;
        tempt.GetComponent<CanvasGroup>().interactable = true;
        tempt.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public void close()
    {
        GameObject tempt = GameObject.Find("Image45");
    
    
        tempt.GetComponent<CanvasGroup>().alpha = 0;
        tempt.GetComponent<CanvasGroup>().interactable = false;
        tempt.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void am33()
    {
     
        if (!im6.activeSelf)
        {
            im6.SetActive(true);
            im7.SetActive(true);
            im5.SetActive(true);
            am3.Play("hjmation");
        }
        else
        {
            im6.SetActive(false);
            im7.SetActive(false);
            im5.SetActive(false);//需要优化
        }
    }
    public void im3click()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void im1click()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
    public void imclick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
    public void parcell()
    {

    }
    IEnumerator PrintTwo(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            print("Hello World" + Time.time);
        }
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
