using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Limit : MonoBehaviour
{
     
    public int target = 60;

    void Awake()
    {
        Application.targetFrameRate = target;
    }

    void Update()
    {
        if (Application.targetFrameRate != target)
        {
            Application.targetFrameRate = target;
        }
    }
}
