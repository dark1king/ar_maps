using Mapbox.Unity.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTap : MonoBehaviour
{
    public GameObject setPosition;

    public Camera MainCamera;

    public Camera ArCamera;

    private Coroutine timer;

    public TouchCamera touchScript;

    void Update()
    {
        
        if (timer != null) return;
        if (Input.touchCount == 0)
        {
            StopAllCoroutines();
            timer = null;
        }
        else
        {
            if (Input.touchCount > 1) return;
            timer = StartCoroutine(Timer());
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1.5f);
        if (Input.touchCount > 0 && Input.touchCount < 2 && !touchScript.Isscrolling)
        {

            Ray ray = (MainCamera.gameObject.activeSelf) ? MainCamera.ScreenPointToRay(Input.GetTouch(0).position) : ArCamera.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10000.0f))
            {
                setPosition.transform.position = hit.point;
                //print("drum1hit!");
                GameObject.FindObjectOfType<AbstractMap>().UpdateMAP();
            }
        }
        timer = null;
    }
}
