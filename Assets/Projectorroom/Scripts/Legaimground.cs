using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legaimground : MonoBehaviour
{

    int layerMask; 
    GameObject raycastOrigin; 
    void Start()
    {
        layerMask = LayerMask.GetMask("Ground"); 
        raycastOrigin = transform.parent.gameObject;
    }


    void Update()
    {
        RaycastHit hit; //simple raycast downwards
        if (Physics.Raycast(raycastOrigin.transform.position, -transform.up, out hit, Mathf.Infinity, layerMask))
        {
            transform.position = hit.point + new Vector3(0f, 0.3f, 0f); //move the cube to the ground
        }

    }
}
