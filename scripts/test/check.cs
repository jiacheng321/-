using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class check : MonoBehaviour
{

    Canvas gg;

    // Start is called before the first frame update
    void Start()
    {
        gg = GameObject.Find("inuiui").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(1))
        {
            Debug.Log(GetOverUI(GameObject.Find("inuiui")));
            Debug.Log(Input.mousePosition);
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
