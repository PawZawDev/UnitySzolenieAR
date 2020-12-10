using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    public GameObject audioMarker, testMarker, continueMarker;
    private MarkerScriptInterface parentMarker;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            var spawnedAudioMarker = Instantiate(audioMarker, transform.position + new Vector3(0, 0, 3), Quaternion.identity);
            spawnedAudioMarker.SetActive(true);
            if (parentMarker != null)
            {
                spawnedAudioMarker.SetActive(false);
                parentMarker.AddNextMarker(spawnedAudioMarker);
            }
            parentMarker = spawnedAudioMarker.GetComponent<MarkerScriptInterface>();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            var spawnedTestMarker = Instantiate(testMarker, transform.position + new Vector3(0, 0, 3), Quaternion.identity);
            spawnedTestMarker.SetActive(true);
            if (parentMarker != null)
            {
                spawnedTestMarker.SetActive(false);
                parentMarker.AddNextMarker(spawnedTestMarker);
            }
            parentMarker = spawnedTestMarker.GetComponent<MarkerScriptInterface>();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            var spawnedContinuesMarker = Instantiate(continueMarker, transform.position + new Vector3(0, 0, 3), Quaternion.identity);
            spawnedContinuesMarker.SetActive(true);
            if (parentMarker != null)
            {
                spawnedContinuesMarker.SetActive(false);
                parentMarker.AddNextMarker(spawnedContinuesMarker);
            }
            parentMarker = spawnedContinuesMarker.GetComponent<MarkerScriptInterface>();
        }
    }
}
