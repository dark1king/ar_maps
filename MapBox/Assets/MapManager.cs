using Mapbox.Unity.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject MainCamera;

    public GameObject ArCamera;

    public AbstractMap Map;

    public GameObject CanvasForArCamera;

    public GameObject CanvasForMainCamera;

    bool isArOn = false;

    public void ChangeMapView()
    {
        if (isArOn)
        {
            //Map.Initialize()
            //ArCamera.GetComponent<Vuforia.VuforiaBehaviour>().
            CanvasForArCamera.SetActive(false);
            ArCamera.SetActive(false);
            CanvasForMainCamera.SetActive(true);
            MainCamera.SetActive(true);
            Map.Options.extentOptions.extentType = MapExtentType.CameraBounds;
            Map.ResetMap();

           
            isArOn = false;
        }
        else
        {
            CanvasForMainCamera.SetActive(false);
            MainCamera.SetActive(false);
            CanvasForArCamera.SetActive(true);
            ArCamera.SetActive(true);
            Map.Options.extentOptions.extentType = MapExtentType.RangeAroundTransform;
            Map.ResetMap();

            
            isArOn = true;
        }

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
