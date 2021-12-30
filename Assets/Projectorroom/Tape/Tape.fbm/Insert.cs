using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insert : MonoBehaviour
{
    // Start is called before the first frame update
    public bool picked;
    public bool pickedS;
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
        if(picked==true&&GameObject.Find("Set").GetComponent<Set>().reset ==true)
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
       if(insert)
        { Put.SetBool("Put", true); }
        if (GameObject.Find("Pickup").GetComponent<PickSys>().isGrabing == false && insert == false)
        {
            picked = false;
        }
        if (project)
        {
            if (pickedS == false)
            {
                if (GetComponent<ChangeTexture>().type == 1)
                { GameObject.Find("monster1").GetComponent<SkinnedMeshRenderer>().materials[0].mainTexture = GetComponent<MeshRenderer>().materials[0].mainTexture; }
                if (GetComponent<ChangeTexture>().type == 2)
                { GameObject.Find("monster1").GetComponent<SkinnedMeshRenderer>().materials[0].mainTexture = GetComponent<MeshRenderer>().materials[1].mainTexture; }
                GameObject.Find("Monster").GetComponent<Monster>().effe = true;
            }
            if (pickedS == true)
            {
               
                 GameObject.Find("monster1").GetComponent<SkinnedMeshRenderer>().materials[0].mainTexture = GetComponent<MeshRenderer>().materials[1].mainTexture;
                GameObject.Find("Monster").GetComponent<Monster>().effe = true;
                GameObject.Find("Monster").GetComponent<Monster>().Final= true;
            }
        }
        if(effect==true)
        {
            
        }

    }
            }

