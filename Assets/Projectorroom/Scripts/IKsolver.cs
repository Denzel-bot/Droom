using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKsolver : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 currentPosition;
    void Start()
    {
        currentPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = currentPosition;
    }
}
