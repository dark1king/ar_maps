using Mapbox.Unity.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleTap : MonoBehaviour
{
    public GameObject setPosition;

    public Camera MainCamera;

    public Camera ArCamera;

    private Coroutine timer;

 
    [SerializeField]
    private Image placementImage;

    public void Activate()
    {
        if (this.enabled)
        {
            placementImage.color = Color.black;
            StopAllCoroutines();
            timer = null;
            this.enabled = false;
        }
        else
        {
            placementImage.color = Color.white;
            
            this.enabled = true;
        }
    }
    
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
            timer = StartCoroutine(Timer());
        }
    }




    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1.5f);
        if (Input.touchCount > 0 && Input.touchCount < 2)
        {

            Ray ray = (MainCamera.gameObject.activeSelf) ? MainCamera.ScreenPointToRay(Input.GetTouch(0).position) : ArCamera.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10000000.0f))
            {
               
                setPosition.transform.position = hit.point;
                //print("drum1hit!");
                GameObject.FindObjectOfType<AbstractMap>().UpdateMAP();
            }
        }
        timer = null;
    }
}
