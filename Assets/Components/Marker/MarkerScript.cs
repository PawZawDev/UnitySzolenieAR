using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarkerScript : MonoBehaviour
{
    public GameObject markerCanvasObject;
    public string MarkerObjectName;
    public Button YesButton;
    public Button NoButton;
    public Button ContinueButton;
    public Text questionText;

    public void OnYesButtonClick()
    {
        questionText.text = "ahh yes bulbulator indeed is a tool to bulbulate";
    }
    public void OnContinueButtonClick()
    {
        ContinueButton.gameObject.SetActive(false);
        YesButton.gameObject.SetActive(true);
        NoButton.gameObject.SetActive(true);
        questionText.text = "Does the bulbator bulbate?";
    }

    // Start is called before the first frame update
    void Start()
    {
        markerCanvasObject.transform.Find("MarkerObjectName").GetComponent<Text>().text = MarkerObjectName;
        markerCanvasObject.SetActive(false);
        markerCanvasObject.transform.localScale = new Vector3(-markerCanvasObject.transform.localScale.x, markerCanvasObject.transform.localScale.y, markerCanvasObject.transform.localScale.z);
        YesButton.onClick.AddListener(OnYesButtonClick);
        ContinueButton.onClick.AddListener(OnContinueButtonClick);
        ContinueButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        markerCanvasObject.transform.LookAt(Camera.main.transform);
    }


    private void OnTriggerEnter(Collider other)
    {
        markerCanvasObject.SetActive(true);
        StartCoroutine("CountTimeToContinue");
    }

    private IEnumerator CountTimeToContinue()
    {
        yield return new WaitForSeconds(10);
        ContinueButton.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        markerCanvasObject.SetActive(false);
        StopCoroutine("CountTimeToContinue");
    }
}
