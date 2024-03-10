using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class Planet : MonoBehaviour
{
    GameObject canvas;
    GameObject textBox;
    GameObject planetInfo;
    Text planetInfoText;

    JSONParser jsonParser;

    string planetName;

    float speedRot;
    Vector3 rotation;
    float size;
    string info;

    Vector3 minScale = new Vector3(0, 0, 0);
    Vector3 maxScale;
    float t;
    float scalingSpeed = 1f;
    float scalingDuration = 1f;

    void Awake()
    {
        jsonParser = new JSONParser("planets");
    }
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");

        textBox = canvas.transform.GetChild(0).gameObject;
        planetInfo = textBox.transform.GetChild(0).GetChild(0).gameObject;

        planetInfoText = planetInfo.GetComponent<Text>();

        planetName = transform.name;

        speedRot = jsonParser.GetTextItem(planetName).Rotation;
        rotation = new Vector3(0, speedRot, 0);

        size = jsonParser.GetTextItem(planetName).Size;
        maxScale = new Vector3(size, size, size);

        info = jsonParser.GetTextItem(planetName).Info;        

        Animation();        
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas.GetComponent<SceneManagerScript>().timer == true)
        {
            transform.Rotate(rotation * Time.deltaTime);
        }
           
    }

    IEnumerator GrowAnim(Vector3 minScale, Vector3 maxScale, float time)
    {
        t = 0f;
        float rate = (1f / time) * scalingSpeed;
        while (t < 1f)
        {
            t += Time.deltaTime * rate;
            //Debug.Log(t);
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

    private void OnMouseDown()
    {
        textBox.SetActive(true);
        planetInfoText.text = info;
    }

}
