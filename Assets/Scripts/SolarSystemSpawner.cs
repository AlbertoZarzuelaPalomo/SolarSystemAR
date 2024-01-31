using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SolarSystemSpawner : DefaultObserverEventHandler
{
    public GameObject solarSystemPrefab;

    GameObject solarSystem;

    protected override void OnTrackingFound()
    {
        Debug.Log("Target Found");

        // Instantiate the model prefab only if it hasn't been instantiated yet
        if (solarSystem == null)
            InstantiatePrefab();

        base.OnTrackingFound();
    }

    void InstantiatePrefab()
    {
        if (solarSystemPrefab != null)
        {
            Debug.Log("Target found, adding content");
            solarSystem = Instantiate(solarSystemPrefab, mObserverBehaviour.transform);
            //mMyModelObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            solarSystem.SetActive(true);
        }
    }
}
