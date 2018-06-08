using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPostiton : MonoBehaviour
{


    public Transform track;
    private Transform cachedTransform;
    private Vector3 cachedPosition;

    void Start()
    {
        cachedTransform = GetComponent<Transform>();
        transform.rotation = track.rotation;
        if (track)
        {
            cachedPosition = new Vector3(track.position.x, cachedPosition.y, track.position.z);
        }
    }

    void Update()
    {
        if (track && cachedPosition != new Vector3(track.position.x, cachedPosition.y, track.position.z))
        {
            cachedPosition = new Vector3(track.position.x, cachedPosition.y, track.position.z);
            transform.position = cachedPosition;
        }
    }
}
