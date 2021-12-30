using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direct : MonoBehaviour
{
    // Start is called before the first frame update
    public RaycastHit hit3;
    public TextMesh direct;
    public bool a;
    public bool b;
    public bool c;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit3))
        {
            print(hit3.collider.gameObject);
            if (hit3.collider.CompareTag("Mouth"))
            {
                direct.text = "FEED";
                a = true;
            }
         
            if (hit3.collider.CompareTag("Insert") )
            {

                direct.text = "INSERT";
                b = true;
            }
            if (hit3.collider.CompareTag("toaster"))
            {

                direct.text = "toast :)";
                c = true;
            }
            if(!hit3.collider.CompareTag("Mouth")&&! hit3.collider.CompareTag("Insert")&& !hit3.collider.CompareTag("toaster"))
            {
                direct.text = "";
            }
        }
    }
}
