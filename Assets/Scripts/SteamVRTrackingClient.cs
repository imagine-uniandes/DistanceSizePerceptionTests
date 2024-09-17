using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using Newtonsoft.Json;

public class SteamVRTrackingClient : MonoBehaviour {
    public string url;
    public float Delay;
    public TrackingInfo Data;
    protected float m_Delay;
    
    WebSocket client;
	// Use this for initialization
	void Start () {
        Data = new TrackingInfo();

        client = new WebSocket(url);
        client.Connect();        

        client.OnOpen += Client_OnOpen;
        client.OnMessage += Client_OnMessage;
    }

    private void Client_OnOpen(object sender, System.EventArgs e)
    {
        Debug.Log("Connection established");
    }
    
    private void Client_OnMessage(object sender, MessageEventArgs e)
    {
        Data = JsonConvert.DeserializeObject<TrackingInfo>(e.Data);

        if(m_Delay > Delay && (Data.optionUp || Data.triggerUp))
            m_Delay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (client.IsAlive)
        {
            client.SendAsync("GetData", null);
            m_Delay += Time.deltaTime;
        }
    }
}
