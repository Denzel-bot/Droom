using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set : MonoBehaviour
{
    // Start is called before the first frame update
    public bool reset;
    public bool use;
    private int time=3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
       if(other.tag=="Player")
        if (use)
        {
            reset = true;
            GameObject.Find("Pickup").GetComponent<PickSys>().Insert = false;
            
            GameObject.Find("Monster").GetComponent<Monster>().effe = false;
            Invoke("stopuse", time);

        }
    }
  public  void stopuse()
    {
        use = false;
        reset = false;
    }
}
