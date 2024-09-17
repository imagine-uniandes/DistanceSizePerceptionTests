using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeConstancyTest : TaskBase {

    public Transform ReferenceTable;
    public Transform RefObject1;
    public Transform RefObject2;
    public Transform CloneObject1;
    public Transform CloneObject2;

    public int NumTrials;
    public float ScaleFactor;

    protected int m_ObjectIndex;
    protected int m_Trials = 0;
    protected Transform m_Object;
    protected Transform m_Reference;
    protected int m_PointIndex = 1;
    protected List<string> info;

    // Use this for initialization
    void Start()
    {

    }

    public override void Begin()
    {
        m_IsEnabled = true;
        m_Trials = 0;
        m_PointIndex = 1;
        info = new List<string>();

        ReferenceTable.gameObject.SetActive(true);
        m_Reference = RefObject1;

        m_Reference.gameObject.SetActive(true);
        Vector3 PointPos = ReferenceTable.Find("Points").GetChild(0).position;
        m_Reference.position = PointPos + Vector3.up * 0.015f;

        m_Object = CloneObject1; // GameObject.Instantiate(m_Reference, this.transform.position, m_Reference.rotation);
        m_Object.gameObject.SetActive(true);

        //m_Object.localScale = Vector3.one * ((m_Trials % 2 == 0) ? 2.0f : 0.25f);
        m_Object.localScale = m_Reference.localScale * ((m_Trials % 2 == 0) ? 2.0f : 0.25f);

        PointPos = ReferenceTable.Find("Points").GetChild(1).position;
        m_Object.position = PointPos + Vector3.up * 0.015f;

        UI.ShowMessage(string.Format("Set the size of the object according to the distance: {0}/{1}", m_Trials, NumTrials));
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_IsEnabled)
            return;

        if (m_Trials < NumTrials)
        {
            Vector3 PointPos = ReferenceTable.Find("Points").GetChild(m_PointIndex).position;

            if (VRInput.GetAnyAxis().y != 0)
            {
                m_Object.localScale = m_Object.localScale + Vector3.one * VRInput.GetAnyAxis().y * ScaleFactor * Time.deltaTime;
                m_Object.position = PointPos + Vector3.up * 0.015f;
            }

            if (VRInput.GetUp(VRInputButton.Trigger))
            {
                Vector3 delta = m_Object.localScale - m_Reference.localScale;
                info.Add(string.Format("{0},{1:0.00},{2:0.00},{3:0.00}", m_Trials, delta.x, delta.y, delta.z));

                m_Trials++;

                int steps = NumTrials / (ReferenceTable.Find("Points").childCount - 1);
                if (m_Trials % steps == 0)
                    m_PointIndex++;

                if (m_PointIndex < ReferenceTable.Find("Points").childCount)
                    PointPos = ReferenceTable.Find("Points").GetChild(m_PointIndex).position;

                //m_Object.localScale = Vector3.one * ((m_Trials % 2 == 0) ? 2.0f : 0.25f);
                m_Object.localScale = m_Reference.localScale * ((m_Trials % 2 == 0) ? 2.0f : 0.25f);
                m_Object.position = PointPos + Vector3.up * 0.015f;

                UI.ShowMessage(string.Format("Set the size of the object according to the distance: {0}/{1}", m_Trials, NumTrials));
            }
        }
        else
        {
            if (info.Count > 0)
            {
                string date = string.Format("{0:yy-MM-dd_hh_mm}", System.DateTime.Now);
                System.IO.File.WriteAllLines(Application.dataPath + "/sc1_" + date + ".csv", info.ToArray());
                UI.ShowMessage(string.Format("Thank you!", m_Trials, NumTrials));
                info.Clear();
            }
        }
    }
}
