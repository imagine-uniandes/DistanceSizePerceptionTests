using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TestController : MonoBehaviour
{
    public VRInputBase VRInput;
    public PlayerController Player;
    public UIController UI;

    private int m_Option = 0;

    // Use this for initialization
    void Start()
    {
#if UNITY_STANDALONE
        if (XRDevice.GetNativePtr() != IntPtr.Zero)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                this.GetComponentsInChildren<TaskBase>()[i].Setup(UI, Player, VRInput);
                this.GetComponentsInChildren<TaskBase>()[i].OnTaskFinished += OnTaskFinished;
            }
        }
#endif
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE
        if (XRDevice.GetNativePtr() != IntPtr.Zero)
        {
            switch (m_Option)
            {
                case 0:
                    if (!this.GetComponentInChildren<CalibrateTable>().IsEnabled)
                        this.GetComponentInChildren<CalibrateTable>().Begin();
                    break;
                case 1:
                    if (!this.GetComponentInChildren<CalibrateObject>().IsEnabled)
                        this.GetComponentInChildren<CalibrateObject>().Begin();
                    break;
                case 2:
                    if (!this.GetComponentInChildren<SizeConstancyTest>().IsEnabled)
                        this.GetComponentInChildren<SizeConstancyTest>().Begin();
                    break;
            }
        }
#endif
    }

    void OnTaskFinished()
    {
        m_Option++;
        Debug.Log(m_Option);
    }
}
