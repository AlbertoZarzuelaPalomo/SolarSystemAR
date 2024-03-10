using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SolarSystemSpawner : DefaultObserverEventHandler
{   
    public GameObject solarSystem;
    public GameObject scanText;
    public GameObject touchText;

    bool adviceGiven = false;

    protected override void OnTrackingFound()
    {        
        scanText.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(true);

        if (adviceGiven == false)
        {
            StartCoroutine(TouchAdvice());
        }        

        base.OnTrackingFound();
    }

    IEnumerator TouchAdvice()
    {
        adviceGiven = true;

        yield return new WaitForSeconds(3);

        touchText.SetActive(true);

        yield return new WaitForSeconds(4);

        touchText.SetActive(false);

    }
}
