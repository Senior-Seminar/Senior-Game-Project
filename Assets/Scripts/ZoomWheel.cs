using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomWheel : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 2;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        { 
            GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 4;
        }
    }
}
