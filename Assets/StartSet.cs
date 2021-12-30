using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Set;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Set").GetComponent<Set>().use = true;
    }
}
