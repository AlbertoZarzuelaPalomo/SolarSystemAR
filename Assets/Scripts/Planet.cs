using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Planet : MonoBehaviour
{
    GameObject jsonParser;
    JSONParser jsonParserScript;

    string planetName;

    float speedRot;
    Vector3 rotation;
    float size;
    Vector3 minScale = new Vector3(0, 0, 0);
    Vector3 maxScale = new Vector3(5, 5, 5);
    float t;
    float scalingSpeed = 1f;
    float scalingDuration = 1f;

    void Awake()
    {
        jsonParser = GameObject.Find("JSONParser");
        jsonParserScript = jsonParser.GetComponent<JSONParser>();

    }
    // Start is called before the first frame update
    void Start()
    {
        planetName = transform.name;

        speedRot = jsonParserScript.GetTextItem(planetName).Rotation;
        rotation = new Vector3(0, speedRot, 0);

        size = jsonParserScript.GetTextItem(planetName).Size;
        maxScale = new Vector3(size, size, size);
        Animation();        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);   
    }

    IEnumerator GrowAnim(Vector3 minScale, Vector3 maxScale, float time)
    {
        t = 0f;
        float rate = (1f / time) * scalingSpeed;
        while (t < 1f)
        {
            t += Time.deltaTime * rate;
            Debug.Log(t);
            transform.localScale = Vector3.Lerp(minScale, maxScale, t);
            yield return null;
        }
    }

    public void Animation()
    {
        StartCoroutine(GrowAnim(minScale, maxScale, scalingDuration));

        if (t < 1f)
        {
            StopCoroutine(GrowAnim(minScale, maxScale, scalingDuration));
        }
    }

}
