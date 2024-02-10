using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject prefab;
    
    GameObject planet;
    GameObject jsonParser;
    JSONParser jsonParserScript;

    string planetName;
    float distance;
    float speedTrans;
    Vector3 offset;
    Vector3 rotation;

    void Awake()
    {
        //PlanetItem planetItem = jsonparser.GetTextItem(planetName);
        //jsonParser = new JSONParser("planets");
        jsonParser = GameObject.Find("JSONParser");
        jsonParserScript = jsonParser.GetComponent<JSONParser>();

    }
    // Start is called before the first frame update
    void Start()
    {
        planetName = prefab.transform.name;

        distance = jsonParserScript.GetTextItem(planetName).Distance;
        speedTrans = jsonParserScript.GetTextItem(planetName).Translation;
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
