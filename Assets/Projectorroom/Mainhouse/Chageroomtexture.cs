using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chageroomtexture : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshRenderer>().materials[1].mainTexture= GameObject.Find("monster1").GetComponent<SkinnedMeshRenderer>().materials[0].mainTexture ;
    }
}
