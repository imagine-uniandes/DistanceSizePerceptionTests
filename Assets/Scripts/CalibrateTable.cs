using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrateTable : TaskBase
{
    public Transform Table;
    public Transform Tracker0;
    protected int Step;
    protected bool ready;
    protected int m_Step;

    protected Vector3 m_Pos;

    // Use this for initialization
    void Start()
    {
        Table.gameObject.SetActive(false);
    }

    public override void Begin()
    {
        Table.gameObject.SetActive(true);
        UI.ShowMessage("Calibrate reference table");

        m_IsEnabled = true;
        m_Step = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsEnabled)
        {
            if (VRInput.GetUp(VRInputButton.Trigger))
            {
                Debug.Log(m_Step);
                if (m_Step == 0)
                {
                    Table.position = Tracker0.position + Vector3.down * 0.03f;
                    m_Pos = Tracker0.position;
                }
                else if(m_Step == 1)
                {
                    Table.right = (m_Pos - Tracker0.position).normalized;
                    m_Step = 1;
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
