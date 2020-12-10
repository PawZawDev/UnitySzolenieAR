using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// MarkerSoundScript is a marker with a sound effect and continue button
public class MarkerSoundScript : MarkerScript, MarkerScriptInterface
{
    private AudioSource audioSource;  // object that handles playing the sound
    private float timeBeforeContinue; // time before the continue button appears
    private Button continueButton;    // continue button

    // Start is called before the first frame update
    private new void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
        continueButton = markerCanvasObject.transform.Find("PressableButtonUnityUI").GetComponent<Button>();
        continueButton.gameObject.SetActive(false);
        continueButton.onClick.AddListener(delegate { StartCoroutine("OnContinueButtonClick"); });
    }

    // What happens when the user sees the marker, starts the sound
    protected override void OnMarkerEnter()
    {
        timeBeforeContinue = audioSource.clip.length;
        audioSource.Play();
        StartCoroutine("CountTimeToContinue");
    }

    // What happens when the user does not see the marker, stops the sound
    protected override void OnMarkerExit()
    {
        audioSource.Stop();
        StopCoroutine("CountTimeToContinue");
    }

    // Coroutine which counts the time to continue so the user has hear the sound before they click the button
    protected IEnumerator CountTimeToContinue()
    {
        yield return new WaitForSeconds(timeBeforeContinue);
        continueButton.gameObject.SetActive(true);
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
