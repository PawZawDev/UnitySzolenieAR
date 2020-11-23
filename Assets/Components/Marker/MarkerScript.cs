using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MarkerScript : MonoBehaviour
{
    public GameObject markerCanvasObject;
    public string MarkerObjectName;
    public List<GameObject> childrenList;

    protected virtual void OnMarkerEnter()
    {

    }

    protected virtual void OnMarkerExit()
    {

    }

    // Start is called before the first frame update
    protected void Start()
    {
        markerCanvasObject.transform.Find("MarkerObjectName").GetComponent<Text>().text = MarkerObjectName;
        markerCanvasObject.SetActive(false);
        markerCanvasObject.transform.localScale = new Vector3(-markerCanvasObject.transform.localScale.x, markerCanvasObject.transform.localScale.y, markerCanvasObject.transform.localScale.z);
    }

    // Update is called once per frame
    protected void Update()
    {
        markerCanvasObject.transform.LookAt(Camera.main.transform);
    }


    protected void OnTriggerEnter(Collider other)
    {
        markerCanvasObject.SetActive(true);
        OnMarkerEnter();
    }

    protected void OnTriggerExit(Collider other)
    {
        markerCanvasObject.SetActive(false);
        OnMarkerExit();
    }

    protected void OnMarkerEnd()
    {
        foreach(GameObject go in childrenList)
        {
            go.SetActive(true);
        }
        this.gameObject.SetActive(false);
    }
}
