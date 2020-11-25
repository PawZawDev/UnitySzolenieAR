using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using UnityEngine;
using System;

public class PhysicalCameraStreamer : MonoBehaviour
{
    public Texture2D tex;
    public GameObject ResultView;
    new public Renderer renderer;

    private WebCamTexture webcamTexture;
    // Start is called before the first frame update
    void Start()
    {

        webcamTexture = new WebCamTexture();
        renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webcamTexture;

    }

    public void Play() => webcamTexture.Play();
    public void Pause() => webcamTexture.Pause();
    public void Stop() => webcamTexture.Stop();

    private void Update()
    {
        if (webcamTexture.isPlaying)
        {

        }
    }
}