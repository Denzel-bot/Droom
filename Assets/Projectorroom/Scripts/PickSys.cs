using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSys : MonoBehaviour
{
    public bool isGrab = false;
    public bool isGrab2 = false;
    public RaycastHit hit;
    public RaycastHit hit2;
    public int randomtextureIndex;
    public bool isGrabing;
    public Transform theDest;
    public Transform theDest2;
    public Animator anim;

    public GameObject Room1, Room2, Room3;
    public int i=2;
    public GameObject Monster;
    public GameObject player;
    public bool isHold;
    public Transform Cam, Player;
    public float dropForwardForce, dropUpwardForce;
    public Vector3 scale;
    public Vector3 scale2;
    public bool isdrop;
    public Animator Put;
    public bool holdtape;
    public bool holdright;
    public bool Insert;
    public GameObject effect;
    public bool holdOthers;
    public GameObject Timeline;
    public bool GTape;
    public bool eat;
    public AudioSource wrongfood;
    public AudioSource rightfood;
    public AudioSource Sert;
    public AudioSource Chi;
    public Transform GenPoint;
    public bool holdS;
    public bool Puke;
    public GameObject Special;
    public GameObject Spawner3;
    public Transform direct3;
    public float shortThrowForce;

    private void Start()
    {
       
    }

    public void Clean()
    {
        
        for (int i = 0; i < GameObject.Find("Destination").transform.childCount; i++)
        {
            Destroy(GameObject.Find("Destination").transform.GetChild(i).gameObject);
        }
        for(int i = 0; i < GameObject.Find("Destination2").transform.childCount; i++)
        {
            Destroy(GameObject.Find("Destination2").transform.GetChild(i).gameObject);
        }
    }
   

    void Update()
    {
        
        Grab();
        Grab2();
      if(Insert==true)
        {
            if (Sert.isPlaying == false)
            {
                Sert.Play();
               
            }
        }
        if (isGrabing)
        {
            if (Input.GetMouseButtonDown(0))
            {
        
                isGrab = false;
                isGrab2 = false;
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit2))
                {
                    print(hit2.collider.gameObject);
                    if (hit2.collider.CompareTag("Mouth") &&holdOthers==true)
                    {
                        eat = true;
                        holdOthers = true;
                        Clean();
                        Timeline.SetActive(true);
                        wrongfood.Play();

                    }
                    if (hit2.collider.CompareTag("Mouth") && holdright== true)
                    {

                        i++;
                        Clean();
                        rightfood.Play();
                        Chi.Play();
                        anim.SetTrigger("Clap");
                      
                 
                        if(i==0||i==1||i==2)
                        {
                            Invoke("holdR", 3);

                        }
                        if (i == 3)
                        {
                            anim.SetTrigger("Puke");
                            Invoke("Gstape", 3);
                            Invoke("holdR", 10);
                            
                        }

                    }
                    if (!hit2.collider.CompareTag("Mouth")&& !hit2.collider.CompareTag("Insert"))
                    {
                        holdOthers = false;
                        holdtape = false;
                        holdright = false;
                        
                        Drop();




                    }
                    if (hit2.collider.CompareTag("Insert") && holdtape == true)
                    {
                        Insert = true;
                        if (i == 0)
                        {
                            Room1.SetActive(true);
                            Room2.SetActive(false);
                            Room3.SetActive(false);
                        }
                        if (i == 1)
                        {
                            Room1.SetActive(false);
                            Room2.SetActive(true);
                            Room3.SetActive(false);
                        }
                        if (i == 2)
                        {
                            Room1.SetActive(false);
                            Room2.SetActive(false);
                            Room3.SetActive(true);
                        }
                       
                    }
                    if (hit2.collider.CompareTag("Insert") && holdS == true)
                    {
                        Insert = true;
                   

                    }
                    isGrabing = false;
                    if (hit.collider.CompareTag("Insert") && holdtape == true)
                    {
                        Insert = true;
                        Invoke("InsertDisable", 4);



                    }
                    if (hit.collider.CompareTag("Insert") && holdS == true)
                    {
                        Insert = true;
                        Invoke("InsertDisable", 4);



                    }

                }






            }
        }
        if (!isGrabing )
        {
            if (Input.GetMouseButtonDown(0))
            {
                isdrop = false;
                Ray ray =Camera.main .ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    print(hit.collider.gameObject);

                  
                    if (hit.collider.CompareTag("Tape"))
                    {
                        isGrab = true;
                        holdtape = true;

                    }
                    if (hit.collider.CompareTag("Special"))
                    {
                        isGrab = true;
                        holdS = true;

                    }
                    if (hit.collider.CompareTag("Others") )
                    {
                        isGrab2 = true;
                        holdOthers = true;


                    }
                    if (hit.collider.CompareTag("Right"))
                    {
                        isGrab2 = true;
                        holdright = true;
                        


                    }
                    if (hit.collider.CompareTag("Insert")&&holdtape==true)
                    {
                        Insert = true;
                        Invoke("InsertDisable", 4);



                    }
                    if (hit.collider.CompareTag("Insert") && holdS == true)
                    {
                        Insert = true;
                        Invoke("InsertDisable", 4);



                    }

                }
            }


           
                //add force
            

                //random color 
                /* if (black >3)
                 {
                     projectile.GetComponent<MeshRenderer>().materials[0].mainTexture = LSDtex[randomtextureIndex];



                 }
                 if (black < 3||black==3)
                 {
                     projectile.GetComponent<MeshRenderer>().materials[1].mainTexture = LSDtex[randomtextureIndex];


                 }*/







            }
        }
    public void Drop()
    {
        
            //Set parent to null
            hit.transform.SetParent(null);

            //Make Rigidbody not kinematic and BoxCollider normal
            hit.rigidbody.isKinematic = false;
            hit.collider.isTrigger = false;

            hit.rigidbody.velocity = player.GetComponent<Rigidbody>().velocity;

            //AddForce
            hit.rigidbody.AddForce(Cam.forward * dropForwardForce, ForceMode.Impulse);
            hit.rigidbody.AddForce(Cam.up * dropUpwardForce, ForceMode.Impulse);
            //Add random rotation
            float random = Random.Range(-1f, 1f);
            hit.rigidbody.AddTorque(new Vector3(random, random, random) * 10);
   
            isGrabing = false;
        

    }

    public void Grab()
    {

        if (isGrab)
        {
            isGrabing = true;

            hit.transform.SetParent(theDest);
            hit.transform.localPosition = Vector3.zero;
            hit.transform.localRotation = Quaternion.Euler(Vector3.zero);
            hit.transform.localScale = scale;

            //Make Rigidbody kinematic and BoxCollider a trigger
            hit.rigidbody.isKinematic = true;
            hit.collider.isTrigger = true;

        }
        


    }
    public void Grab2()
    {

        if (isGrab2)
        {
            isGrabing = true;

            hit.transform.SetParent(theDest2);
            hit.transform.localPosition = Vector3.zero;
            hit.transform.localRotation = Quaternion.Euler(Vector3.zero);
            hit.transform.localScale = scale2;

            hit.rigidbody.isKinematic = true;
            hit.collider.isTrigger = true;

        }
     


    }
    public void holdR()
    {
        holdright = false;
        holdS = false;
    }
    public void InsertDisable()
    {
        Insert = false;

    }
    public void PukeTure()
    {
     Puke = false;

    }
    public void Gstape()
    {
        ThrowProjectile2(Special);
    }
    void ThrowProjectile2(GameObject prefab)

    {

        GameObject projectilel = Instantiate(
        prefab, Spawner3.transform

    );

        projectilel.GetComponent<Rigidbody>().AddForce(
             direct3.position * shortThrowForce,
            ForceMode.Impulse
        );
    }

}




