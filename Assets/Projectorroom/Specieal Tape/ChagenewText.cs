using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChagenewText : MonoBehaviour
{
    // Start is called before the first frame update
    public bool picked;
    public Animator Put;
    public RaycastHit hit;
    public bool insert;
    public Transform rukou;
    public Vector3 scale;
    public bool project;
    public bool effect;
    void Start()
    {
        picked = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (picked == true && GameObject.Find("Set").GetComponent<Set>().reset == true)
        {
            GameObject.Find("Monster").GetComponent<Monster>().effe = false;
            GameObject.Find("Pickup").GetComponent<PickSys>().Insert = false;
            Destroy(this.gameObject);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                print(hit.collider.gameObject);

                if (picked)
                {
                    rukou = GameObject.Find("Insert").GetComponent<Transform>();
                    if (hit.collider.CompareTag("Insert"))
                    {

                        insert = true;
                        transform.SetParent(rukou);
                        transform.localPosition = Vector3.zero;
                        transform.localRotation = Quaternion.Euler(Vector3.zero);
                        transform.localScale = scale;
                    }
                }
            }
        }
        if (insert)
        { Put.SetBool("Put", true); }
        if (GameObject.Find("Pickup").GetComponent<PickSys>().isGrabing == false && insert == false)
        {
            picked = false;
        }
        if (project)
        {
        
            { GameObject.Find("monster1").GetComponent<SkinnedMeshRenderer>().materials[0].mainTexture = GetComponent<MeshRenderer>().materials[1].mainTexture; }
          
        }
        if (effect == true)
        {

        }

    }
}


