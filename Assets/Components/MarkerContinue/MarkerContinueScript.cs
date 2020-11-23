using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarkerContinueScript : MarkerScript
{
    
    public float timeBeforeContinue;
    private Button continueButton;
    public string endingText;

    private new void Start()
    {
        base.Start();
        continueButton = markerCanvasObject.transform.Find("ContinueButton").GetComponent<Button>();
        continueButton.gameObject.SetActive(false);
        continueButton.onClick.AddListener(delegate { StartCoroutine("OnContinueButtonClick"); });

    }

    protected override void OnMarkerEnter()
    {
        StartCoroutine("CountTimeToContinue");
    }

    protected override void OnMarkerExit()
    {
        StopCoroutine("CountTimeToContinue");
    }

    protected IEnumerator CountTimeToContinue()
    {
        yield return new WaitForSeconds(timeBeforeContinue);
        continueButton.gameObject.SetActive(true);
        markerCanvasObject.transform.Find("MarkerText").GetComponent<Text>().text = endingText;
    }

    public IEnumerator OnContinueButtonClick()
    {
        continueButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        OnMarkerEnd();
    }
}
