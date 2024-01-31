using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject prefab;
    GameObject planet;
    float distance;
    float speedTrans;
    Vector3 offset;
    Vector3 rotation; 

    // Start is called before the first frame update
    void Start()
    {
        distance = 15f;
        speedTrans = 10f;
        offset = new Vector3(distance, 0, 0);
        rotation = new Vector3(0, speedTrans, 0);
        planet = Instantiate(prefab, transform.position + offset, Quaternion.identity);
        planet.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
