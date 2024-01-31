using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Planet : MonoBehaviour
{
    float speedRot;

    Vector3 rotation;
    Vector3 minScale = new Vector3(0, 0, 0);
    Vector3 maxScale = new Vector3(5, 5, 5);
    float t;
    float scalingSpeed = 1f;
    float scalingDuration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        speedRot = 40f;
        rotation = new Vector3(0, speedRot, 0);
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
