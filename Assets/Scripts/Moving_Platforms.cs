﻿
using UnityEngine;

public class Moving_Platforms : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector3(10f,0f,0f)*Time.deltaTime);

        if (transform.position.z <= -20)
        {
            Destroy(gameObject);
           
        }
    }
}
