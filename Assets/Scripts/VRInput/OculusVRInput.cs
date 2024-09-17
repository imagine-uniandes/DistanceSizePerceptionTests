using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusVRInput : VRInputBase {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override bool Get(VRInputButton button)
    {
        switch(button)
        {
            case VRInputButton.One:
                return OVRInput.Get(OVRInput.Button.One);
            case VRInputButton.Two:
                return OVRInput.Get(OVRInput.Button.Two);
            case VRInputButton.Trigger:
                return OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger);
            default:
                return false;
        }
    }

    public override bool GetDown(VRInputButton button)
    {
        switch (button)
        {
            case VRInputButton.One:
                return OVRInput.GetDown(OVRInput.Button.One);
            case VRInputButton.Two:
                return OVRInput.GetDown(OVRInput.Button.Two);
            case VRInputButton.Trigger:
                return OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger);
            default:
                return false;
        }
    }

    public override bool GetUp(VRInputButton button)
    {
        switch (button)
        {
            case VRInputButton.One:
                return OVRInput.GetUp(OVRInput.Button.One);
            case VRInputButton.Two:
                return OVRInput.GetUp(OVRInput.Button.Two);
            case VRInputButton.Trigger:
                return OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger);
            default:
                return false;
        }
    }

    public override Vector2 GetAnyAxis()
    {
        return OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick) + OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
    }
}
