using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMoney : MonoBehaviour
{
  
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, 100) * Time.fixedDeltaTime);
    }
}
