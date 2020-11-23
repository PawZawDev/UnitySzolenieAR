using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarkerTestScript : MarkerScript
{
    public float timeBeforeContinue;
    private Button proceedButton;
    private Toggle aToggle;
    private Toggle bToggle;
    private Toggle cToggle;
    private Toggle dToggle;
    private string endingText = "good answer, you can go ahead";

    public bool a;
    public bool b;
    public bool c;
    public bool d;

    private new void Start()
    {
        base.Start();
        proceedButton = markerCanvasObject.transform.Find("ProceedButton").GetComponent<Button>();
        //proceedButton.gameObject.SetActive(false);
        proceedButton.onClick.AddListener(delegate { StartCoroutine("OnProceedButtonClick"); });
        aToggle = markerCanvasObject.transform.Find("AToggle").GetComponent<Toggle>();
        bToggle = markerCanvasObject.transform.Find("BToggle").GetComponent<Toggle>();
        cToggle = markerCanvasObject.transform.Find("CToggle").GetComponent<Toggle>();
        dToggle = markerCanvasObject.transform.Find("DToggle").GetComponent<Toggle>();
    }

    //protected override void OnMarkerEnter()
    //{
    //    StartCoroutine("CountTimeToContinue");
    //}

    //protected override void OnMarkerExit()
    //{
    //    StopCoroutine("CountTimeToContinue");
    //}

    //protected IEnumerator CountTimeToContinue()
    //{
    //    yield return new WaitForSeconds(timeBeforeContinue);
    //    proceedButton.gameObject.SetActive(true);
    //    markerCanvasObject.transform.Find("MarkerText").GetComponent<Text>().text = endingText;
    //}

    public IEnumerator OnProceedButtonClick()   
    {

        if(a == aToggle.isOn && b == bToggle.isOn && c == cToggle.isOn && d == dToggle.isOn)
        {
            markerCanvasObject.transform.Find("MarkerText").GetComponent<Text>().text = endingText;
            yield return new WaitForSeconds(2);
            proceedButton.gameObject.SetActive(false);
            OnMarkerEnd();
        }
        else
        {
            string questionText = markerCanvasObject.transform.Find("MarkerText").GetComponent<Text>().text;
            markerCanvasObject.transform.Find("MarkerText").GetComponent<Text>().text = "wrong answer, try again!";
            yield return new WaitForSeconds(2);
            markerCanvasObject.transform.Find("MarkerText").GetComponent<Text>().text = questionText;
            //var colors = proceedButton.colors;
            //Color col = colors.normalColor;
            //colors.normalColor = Color.red;
            //proceedButton.colors = colors;
            //yield return new WaitForSeconds(2);
            //colors.normalColor = col;
            //proceedButton.colors = colors;
        }
        
        
    }
}
