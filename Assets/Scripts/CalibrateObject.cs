using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrateObject : TaskBase {

    public Transform Table;
    public GameObject[] Objects; 
    public Transform Tracker1;
    public float ScaleFactor;
    private int step = 0;

    protected int m_ObjectIndex = 0;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < Objects.Length; i++)
            Objects[i].SetActive(false);
    }

    public override void Begin()
    {
        Table.gameObject.SetActive(true);

        for(int i=0; i < Objects.Length; i++)
            Objects[i].SetActive(false);

        Objects[m_ObjectIndex].SetActive(true);

        UI.ShowMessage("Calibrate object");

        m_IsEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsEnabled)
        {
            if (Tracker1.gameObject.activeSelf)
                Objects[m_ObjectIndex].transform.position = Tracker1.position + Vector3.up * 0.01f;

            if (step == 1 && VRInput.GetAnyAxis().y != 0)
                Objects[m_ObjectIndex].transform.localScale = Objects[m_ObjectIndex].transform.localScale + Vector3.one * VRInput.GetAnyAxis().y * ScaleFactor * Time.deltaTime;

            if (VRInput.GetUp(VRInputButton.Trigger))
            {
                if (step == 0)
                {
                    UI.ShowMessage("Scale the object until both have the same size. Do not rise the Headset!");
                    step++;
                }
                else
                {
                    m_IsEnabled = false;
                    OnTaskFinished();
                }
            }
        }
    }
}
