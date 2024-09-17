using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class TrackingInfo
{
    [JsonProperty("tracker0")]
    public Dictionary<string, float> tracker0 = CreateDictionary(Vector3.zero, Quaternion.identity);

    [JsonProperty("tracker1")]
    public Dictionary<string, float> tracker1 = CreateDictionary(Vector3.zero, Quaternion.identity);

    [JsonProperty("leftController")]
    public Dictionary<string, float> leftController = CreateDictionary(Vector3.zero, Quaternion.identity);

    [JsonProperty("rightController")]
    public Dictionary<string, float> rightController = CreateDictionary(Vector3.zero, Quaternion.identity);

    [JsonProperty("omniMove")]
    public Dictionary<string, float> omniMove = CreateDictionary(Vector3.zero, Quaternion.identity);

    [JsonProperty("omniForward")]
    public float omniForward = 0;

    [JsonProperty("triggerUp")]
    public bool triggerUp;
    [JsonProperty("optionUp")]
    public bool optionUp;
    [JsonProperty("horizontal")]
    public float horizontal;
    [JsonProperty("vertical")]
    public float vertical;
    [JsonProperty("rhanded")]
    public bool rhanded;

    public static Dictionary<string, float> CreateDictionary(Vector3 pos, Quaternion rot)
    {
        return new Dictionary<string, float>() { { "x", pos.x }, { "y", pos.y }, { "z", pos.z }, { "i", rot.x }, { "j", rot.y }, { "k", rot.z }, { "w", rot.w } };
    }
}

public enum EViveTracker
{
    LeftController,
    RightController,
    Tracker0,
    Tracker1
}