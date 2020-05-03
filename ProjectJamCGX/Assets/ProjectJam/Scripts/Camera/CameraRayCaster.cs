using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRayCaster : MonoBehaviour
{

    private float maxRayDepth = 1000f;
    public Layer[] layerPriorities = { Layer.Waypoint, Layer.Walkable };

    //main camera
    private Camera viewCamera;

    private GraphicRaycaster Raycaster;

    //to get the information from the hit
    private RaycastHit _hit;
    public RaycastHit Hit
    {
        get { return _hit; }
        set { this._hit = value; }
    }

    //to get which layer the ray cast has hit
    private Layer _LayerHit;
    public Layer LayerHit
    {
        get { return _LayerHit; }
        set { this._LayerHit = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        viewCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //look for and return priority layer hit
        foreach (Layer layer in layerPriorities)
        {
            var hit = RaycastForLayer(layer);

            if (hit.HasValue)
            {
                _hit = hit.Value;
                _LayerHit = layer;

                //myCursor.CursorUpdate((int)_LayerHit);
                return;
            }
        }

        //if not will return background hit
        _hit.distance = maxRayDepth;
        _LayerHit = Layer.RaycastEnd;
    }

    //the ? will permit to return a null
    private RaycastHit? RaycastForLayer(Layer layer)
    {
        int layerMask = 1 << (int)layer;

        //use has out
        RaycastHit hit;
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(viewCamera.transform.position, ray.direction, Color.blue);

        bool hasHit = Physics.Raycast(ray, out hit, maxRayDepth, layerMask);
        Debug.DrawLine(viewCamera.transform.position, hit.point, Color.green);


        if (hasHit)
        {

            return hit;

        }
        return null;

    }
}

public enum Layer
{
    Default,
    TransparentFX,
    IgnoreRaycast,
    Layer3,
    Water,
    UI,
    Layer6,
    Layer7,
    Waypoint,
    Walkable,
    RaycastEnd = -1
}
