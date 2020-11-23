using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarkerSoundScript : MarkerScript
{
    private AudioSource audioSource;
    private float timeBeforeContinue;
    private Button continueButton;


    private new void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
        continueButton = markerCanvasObject.transform.Find("ContinueButton").GetComponent<Button>();
        continueButton.gameObject.SetActive(false);
        continueButton.onClick.AddListener(delegate { StartCoroutine("OnContinueButtonClick"); });
    }

    protected override void OnMarkerEnter()
    {
        timeBeforeContinue = audioSource.clip.length;
        audioSource.Play();
        StartCoroutine("CountTimeToContinue");
    }

    protected override void OnMarkerExit()
    {
        audioSource.Stop();
        StopCoroutine("CountTimeToContinue");
    }

    protected IEnumerator CountTimeToContinue()
    {
        yield return new WaitForSeconds(timeBeforeContinue);
        continueButton.gameObject.SetActive(true);
    }

    public IEnumerator OnContinueButtonClick()
    {
        continueButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        OnMarkerEnd();
    }
}
