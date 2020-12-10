using Microsoft.MixedReality.Toolkit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// MarkerTestScript is a marker with a test
public class MarkerTestScript : MarkerScript, MarkerScriptInterface
{
    private Button proceedButton; // button to proceed the test
    private Interactable aToggle;       // answer a toggle
    private Interactable bToggle;       // answer b toggle
    private Interactable cToggle;       // answer c toggle
    private Interactable dToggle;       // answer d toggle
    private string endingText = "good answer, you can go ahead!";         // text displayed when the answer is correct
    private string wrongEndingText = "wrong answer, you can't go ahead!"; // text displayed when the answer is wrong

    // fields where the correct answer is set
    public bool a;
    public bool b;
    public bool c;
    public bool d;

    private Func<IEnumerator> onProceedButtonAction; // action handling proceed button click

    // Start is called before the first frame update
    private new void Start()
    {
        //onProceedButtonAction = OnProceedButtonClick;

        base.Start();
        proceedButton = markerCanvasObject.transform.Find("PressableButtonUnityUI").GetComponent<Button>();
        proceedButton.onClick.AddListener(delegate { StartCoroutine("OnProceedButtonClick"); }); // added delegate listener to perform an action on button click

        // recieve the correct answers

        aToggle = markerCanvasObject.transform.Find("AToggleMRTK").GetComponent<Interactable>();
        bToggle = markerCanvasObject.transform.Find("BToggleMRTK").GetComponent<Interactable>();
        cToggle = markerCanvasObject.transform.Find("CToggleMRTK").GetComponent<Interactable>();
        dToggle = markerCanvasObject.transform.Find("DToggleMRTK").GetComponent<Interactable>();
    }  

    // What happens when the proceed button is clicked
    public IEnumerator OnProceedButtonClick()   
    {

        if(a == aToggle.IsToggled && b == bToggle.IsToggled && c == cToggle.IsToggled && d == dToggle.IsToggled) // answers are correct
        {
            markerCanvasObject.transform.Find("MarkerText").GetComponent<Text>().text = endingText;
            yield return new WaitForSeconds(2);
            proceedButton.gameObject.SetActive(false);
            OnMarkerEnd();
        }
        else // answers are not correct
        {
            string questionText = markerCanvasObject.transform.Find("MarkerText").GetComponent<Text>().text;
            markerCanvasObject.transform.Find("MarkerText").GetComponent<Text>().text = wrongEndingText;
            yield return new WaitForSeconds(2);
            markerCanvasObject.transform.Find("MarkerText").GetComponent<Text>().text = questionText;
        }
        
        
    }

    public void ProceedButton()
    {
        StartCoroutine("OnProceedButtonClick");
    }
}
