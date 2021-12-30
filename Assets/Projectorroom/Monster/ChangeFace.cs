using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFace : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture cry;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Pickup").GetComponent<PickSys>().eat == true)
        {
            GetComponent<SkinnedMeshRenderer>().materials[4].mainTexture = cry;
        }


    }
}
