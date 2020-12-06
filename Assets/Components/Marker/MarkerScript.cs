using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// MarkerScript- abstract class to be a base for different markers
public abstract class MarkerScript : MonoBehaviour
{
    protected GameObject markerCanvasObject; // Canvas object responsible for the text and buttons above the marker
    public string MarkerObjectName;          // The name of the marker
    public List<GameObject> childrenList;    // List of next markers to be spawned

    // What happens when the user sees the marker
    protected virtual void OnMarkerEnter()
    {

    }

    // What happens when the user does not see the marker
    protected virtual void OnMarkerExit()
    {

    }

    // Start is called before the first frame update
    protected void Start()
    {
        // get the name, set canvas off, set the transform of the canvas object
        markerCanvasObject.transform.Find("MarkerObjectName").GetComponent<Text>().text = MarkerObjectName;
        markerCanvasObject.SetActive(false);
        markerCanvasObject.transform.localScale = new Vector3(-markerCanvasObject.transform.localScale.x, markerCanvasObject.transform.localScale.y, markerCanvasObject.transform.localScale.z);
    }

    // Update is called once per frame
    protected void Update()
    {
        // adjust the canvas transform
        markerCanvasObject.transform.LookAt(Camera.main.transform);
    }

    // What happens when there is a collision ( user sees the marker)
    protected void OnTriggerEnter(Collider other)
    {
        markerCanvasObject.SetActive(true);
        OnMarkerEnter();
    }

    // What happens when there is an exit from collision ( user does not see the marker)
    protected void OnTriggerExit(Collider other)
    {
        markerCanvasObject.SetActive(false);
        OnMarkerExit();
    }

    // What happens when the marker is about to end its life
    protected void OnMarkerEnd()
    {
        foreach(GameObject go in childrenList)
        {
            go.SetActive(true);
        }
        this.gameObject.SetActive(false);
    }
}
