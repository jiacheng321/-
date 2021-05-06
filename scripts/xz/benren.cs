﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class benren : MonoBehaviour
{
    public Transform A, B;
    Quaternion rotations = Quaternion.identity;
    Vector3 eulerAngle = Vector3.zero;
    float speed = 10.0f;
    float tSpeed = 0.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tSpeed += speed * Time.deltaTime;
        //第一种方式：将Quaternion实例对象赋值给transform的rotation
        rotations.eulerAngles = new Vector3(0.0f, tSpeed, 0.0f);
        A.rotation = rotations;
        //第二种方式：将三位向量代表的欧拉角直接赋值给transform的eulerAngle
        B.eulerAngles = new Vector3(0.0f, tSpeed, 0.0f);
    }
}