using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour
{
    public Texture[] LSDtex;
    private int black;
    public float type;
    void Start()
    {
        black = Random.Range(1, 10);
        if (black > 3)
        {
            GetComponent<MeshRenderer>().materials[0].mainTexture = LSDtex[GameObject.Find("toaster2").GetComponent<GenerateTape>().randomtextureIndex];
            type = 1;
            

        }
        if (black < 3 || black == 3)
        {
            GetComponent<MeshRenderer>().materials[1].mainTexture = LSDtex[GameObject.Find("toaster2").GetComponent<GenerateTape>().randomtextureIndex];
            type = 2;

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
