using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamVRInputRemote : VRInputBase {

    public SteamVRTrackingClient TrackingClient;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override bool GetUp(VRInputButton Button)
    {
        switch(Button)
        {
            case VRInputButton.Trigger:
                return TrackingClient.Data.triggerUp;
            case VRInputButton.Cancel:
                return TrackingClient.Data.optionUp;
        }

        return false;
    }

    public override Vector2 GetAnyAxis()
    {
        return new Vector2(TrackingClient.Data.horizontal, TrackingClient.Data.vertical);
    }
}
