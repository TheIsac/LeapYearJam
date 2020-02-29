using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleZoomer : MonoBehaviour
{
    Camera cam;
    float startZoom;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        startZoom = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        float targetZoom = startZoom + (0.8f * Time.timeScale);



        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.unscaledDeltaTime * 1.5f);
    }
}
