using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    GameObject player;
    Transform target;
    CinemachineVirtualCamera vCam;

    Coroutine myCoroutine;
    float lerpedValue;
    float duration = 3;
    

    

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

    public void CameraZoomOut()
    {
        
        myCoroutine = StartCoroutine(Lerp(60,80));
             
    }

    public void CameraShake()
    {
        
        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 3;
        StartCoroutine(StopCameraShake(2));
        
    }

    private IEnumerator StopCameraShake(float time)
    {
        yield return new WaitForSeconds(time);
        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
    }

    IEnumerator Lerp(float start, float end)
    {
        float timeElasped = 0;

        while(timeElasped < duration)
        {
            float t = timeElasped/duration;
            vCam.m_Lens.FieldOfView = Mathf.Lerp(start,end,t);
            timeElasped += Time.deltaTime;
            yield return null;
        }

        vCam.m_Lens.FieldOfView = end;
    }

}
