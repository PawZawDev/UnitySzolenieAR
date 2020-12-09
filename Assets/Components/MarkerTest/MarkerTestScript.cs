using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// MarkerTestScript is a marker with a test
public class MarkerTestScript : MarkerScript, MarkerScriptInterface
{
    private Button proceedButton; // button to proceed the test
    private Toggle aToggle;       // answer a toggle
    private Toggle bToggle;       // answer b toggle
    private Toggle cToggle;       // answer c toggle
    private Toggle dToggle;       // answer d toggle
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
        proceedButton = markerCanvasObject.transform.Find("ProceedButton").GetComponent<Button>();
        proceedButton.onClick.AddListener(delegate { StartCoroutine("OnProceedButtonClick"); }); // added delegate listener to perform an action on button click

        // recieve the correct answers
        aToggle = markerCanvasObject.transform.Find("AToggle").GetComponent<Toggle>();
        bToggle = markerCanvasObject.transform.Find("BToggle").GetComponent<Toggle>();
        cToggle = markerCanvasObject.transform.Find("CToggle").GetComponent<Toggle>();
        dToggle = markerCanvasObject.transform.Find("DToggle").GetComponent<Toggle>();
    }  

    // What happens when the proceed button is clicked
    public IEnumerator OnProceedButtonClick()   
    {

        if(a == aToggle.isOn && b == bToggle.isOn && c == cToggle.isOn && d == dToggle.isOn) // answers are correct
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
}
