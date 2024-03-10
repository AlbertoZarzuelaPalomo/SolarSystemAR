using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject prefab;
    
    GameObject planet;
  
    JSONParser jsonParser;

    GameObject canvas;

    string planetName;
    float distance;
    float speedTrans;
    Vector3 offset;
    Vector3 rotation;

    void Awake()
    {        
        jsonParser = new JSONParser("planets");
        canvas = GameObject.FindGameObjectWithTag("Canvas");        

    }
    // Start is called before the first frame update
    void Start()
    {
        planetName = prefab.transform.name;

        distance = jsonParser.GetTextItem(planetName).Distance;
        speedTrans = jsonParser.GetTextItem(planetName).Translation;
        offset = new Vector3(distance, 0, 0);
        rotation = new Vector3(0, speedTrans, 0);
        planet = Instantiate(prefab, transform.position + offset, transform.rotation);
        planet.name = prefab.name;
        planet.transform.parent = this.transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (canvas.GetComponent<SceneManagerScript>().timer == true)
        {
            transform.Rotate(rotation * Time.deltaTime);
        }
        
    }
}
