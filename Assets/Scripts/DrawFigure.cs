using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class DrawFigure : MonoBehaviour
{
    [DllImport("OCVWrapper", EntryPoint = "detectFace", CallingConvention = CallingConvention.StdCall)]
    public static extern void detectFace(long length, int width, int height, byte[] data, out float tlx, out float tly, out float brx, out float bry);
    [DllImport("OCVWrapper", EntryPoint = "loadClassifier", CallingConvention = CallingConvention.StdCall)]
    public static extern void loadClassifier();


    new private Renderer renderer;
    
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Texture2D t = new Texture2D(renderer.material.mainTexture.width, renderer.material.mainTexture.height, TextureFormat.RGB24, false);
        t.SetPixels((renderer.material.mainTexture as WebCamTexture).GetPixels());
        t.Apply();
        byte[] bytes = t.GetRawTextureData();
        float tlx = 0, tly = 0, brx = 0, bry = 0;
        detectFace(bytes.Length, t.width, t.height, bytes, out tlx, out tly, out brx, out bry);
        Debug.Log("FaceCoords:(" + tlx + ", " + tly + ", " + brx + ", " + bry + ",) ");
        renderer.sharedMaterial.SetFloat("CX", 1 - (tlx + brx / 2) / t.width);
        renderer.sharedMaterial.SetFloat("CY", (tly + bry / 2) / t.height);
        renderer.sharedMaterial.SetFloat("R", bry / (2 * t.height));
    }
}