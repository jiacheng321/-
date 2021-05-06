using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class y1 : MonoBehaviour
{
    Vector2 playerInput;
    Vector3 vl,newposition;//相对位移
    float speedspa;
    [SerializeField]
    Rect allowedArea = new Rect(-5f, -5f, 10f, 10f);
    // Start is called before the first frame update
    void Start()
    {
        newposition = new Vector3(0, 0, 0);
}

    // Update is called once per frame
    void Update()
    {

            playerInput.x = Input.GetAxis("Horizontal");
            playerInput.y = Input.GetAxis("Vertical");
            speedspa += 0.5f * Time.deltaTime;
            playerInput = Vector2.ClampMagnitude(playerInput, 1.0f);
            vl.x = playerInput.x;
            vl.z = playerInput.y;
            transform.localPosition = newposition + vl * Mathf.Clamp(speedspa, 0, 100);
            newposition = transform.position;

    }
}
