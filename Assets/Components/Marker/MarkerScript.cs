using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarkerScript : MonoBehaviour
{
    public GameObject markerCanvasObject;
    public Button yesButton;
    public Text questionText;

    public void OnYesButtonClick()
    {
        questionText.text = "ahh yes bulbulator indeed is a tool to bulbulate";
    }

    //void onLook()
    //{
    //    markerCanvasObject.SetActive(true);
    //}
    
    //void noLook()
    //{
    //    markerCanvasObject.SetActive(false);
    //}
    
    // Start is called before the first frame update
    void Start()
    {
        markerCanvasObject.SetActive(false);
        markerCanvasObject.transform.localScale = new Vector3(-markerCanvasObject.transform.localScale.x, markerCanvasObject.transform.localScale.y, markerCanvasObject.transform.localScale.z);
        yesButton.onClick.AddListener(OnYesButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        markerCanvasObject.transform.LookAt(Camera.main.transform);
    }


    private void OnTriggerEnter(Collider other)
    {
        markerCanvasObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        markerCanvasObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        markerCanvasObject.SetActive(true);
    }

    private void OnCollisionExit(Collision collision)
    {
        markerCanvasObject.SetActive(false);
    }


}
