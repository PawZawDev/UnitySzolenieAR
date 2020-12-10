using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// MarkerContinueScript is a marker with some information and the continue button
public class MarkerContinueScript : MarkerScript, MarkerScriptInterface
{
    
    public float timeBeforeContinue; // time before the continue button is avilable
    private Button continueButton;   // the continue button
    public string endingText;        // text after the button is clicked

    // Start is called before the first frame update
    private new void Start()
    {
        base.Start();
        continueButton = markerCanvasObject.transform.Find("ContinueButton").GetComponent<Button>();
        continueButton.gameObject.SetActive(false);
        continueButton.onClick.AddListener(delegate { StartCoroutine("OnContinueButtonClick"); });
    }

    // What happens when the user does not see the marker, starts the coroutine counting the time
    protected override void OnMarkerEnter()
    {
        StartCoroutine("CountTimeToContinue");
    }

    // What happens when the user does not see the marker, stops the coroutine counting the time
    protected override void OnMarkerExit()
    {
        StopCoroutine("CountTimeToContinue");
    }

    // Coroutine which counts the time to continue so the user has to read the text before they click the button
    protected IEnumerator CountTimeToContinue()
    {
        yield return new WaitForSeconds(timeBeforeContinue);
        continueButton.gameObject.SetActive(true);
        markerCanvasObject.transform.Find("MarkerText").GetComponent<Text>().text = endingText;
    }

    // Coroutine which handles the button click
    public IEnumerator OnContinueButtonClick()
    {
        continueButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        OnMarkerEnd();
    }

    public void ContinueButton()
    {
        StartCoroutine("OnContinueButtonClick");
    }
}
