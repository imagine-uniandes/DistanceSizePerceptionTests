using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour {
    public Transform HeadTracker;

	// Use this for initialization
	void Awake () {
        transform.Find("SteamVRCameraRig").gameObject.SetActive(false);
        transform.Find("OVRCameraRig").gameObject.SetActive(false);

#if UNITY_ANDROID
        transform.Find("OVRCameraRig").gameObject.SetActive(true);
#else
       transform.Find("SteamVRCameraRig").gameObject.SetActive(true);

#endif
    }

    // Update is called once per frame
    void Update () {
		
	}
}
