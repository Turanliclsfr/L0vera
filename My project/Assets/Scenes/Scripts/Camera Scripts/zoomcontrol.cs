using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomcontrol : MonoBehaviour
{

    public float ZoomChange;
    public float SmootChange;
    public float minZoom, maxZoom;

    
    private Camera cam;



    // Start is called before the first frame update
    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mouseScrollDelta.y > 0)
        {
            cam.orthographicSize -= ZoomChange * Time.deltaTime * SmootChange;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            cam.orthographicSize += ZoomChange * Time.deltaTime * SmootChange;
        }
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);

        
    }
}
