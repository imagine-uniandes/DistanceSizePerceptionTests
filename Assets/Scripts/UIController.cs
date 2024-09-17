using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public float Offset;

	// Use this for initialization
	void Start () {
        this.GetComponentInChildren<Image>().enabled = false;
        this.GetComponentInChildren<Text>().enabled = false;

        //this.transform.position = Camera.main.transform.position + this.transform.forward * Offset;
        //this.transform.parent = Camera.main.transform;        
		
    }
	
	// Update is called once per frame
	void Update () {
        //this.transform.position = Camera.main.transform.position + Camera.main.transform.forward * Offset;
    }

    public void ShowMessage(string text)
    {
        this.StartCoroutine(ShowMessageCoroutine(text));
    }

    private IEnumerator ShowMessageCoroutine(string text)
    {
        this.GetComponentInChildren<Image>().enabled = true;
        this.GetComponentInChildren<Text>().enabled = true;
        this.GetComponentInChildren<Text>().text = text;

        yield return new WaitForSeconds(2.0f);

        this.GetComponentInChildren<Image>().enabled = false;
        this.GetComponentInChildren<Text>().enabled = false;

    }
}

