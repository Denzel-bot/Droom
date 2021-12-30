using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisBegining : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("disthi", 32);
    }
    void disthi()
    {
        this.gameObject.SetActive(false);
    }
}
