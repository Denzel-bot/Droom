using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInsert : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Pickup").GetComponent<PickSys>().holdtape == true|| GameObject.Find("Pickup").GetComponent<PickSys>().holdS == true)
       {
           GetComponentInChildren<Insert>().picked = true;
            GetComponentInChildren<Insert>().pickedS = true;

        }
        if (GameObject.Find("Pickup").GetComponent<PickSys>().holdtape == true && GameObject.Find("Pickup").GetComponent<PickSys>().holdS == false )
        {
            GetComponentInChildren<Insert>().picked = true;
            GetComponentInChildren<Insert>().pickedS = false ;
        }
    }
    }

