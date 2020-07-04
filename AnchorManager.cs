using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using System;
using UnityEngine.XR.ARSubsystems;

public class AnchorManager : MonoBehaviour
{
    public GameObject anchoredPrefab;
    public GameObject unanchoredPrefab;
    Vector3 lastAnchoredPosition;
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Session.CreateAnchor(transform.position, transform.rotation);
        }
    }
}
