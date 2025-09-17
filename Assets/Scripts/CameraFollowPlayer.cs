using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    GameObject player;
    Transform target;
    CinemachineVirtualCamera vCam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }

        
        vCam = GetComponent<CinemachineVirtualCamera>();

        if (target != null)
        {
            vCam.Follow = target;
        }
        else
        {
            return;
        }
        
        
    }
}
