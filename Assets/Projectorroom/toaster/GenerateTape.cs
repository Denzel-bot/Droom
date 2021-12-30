using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTape : MonoBehaviour
{
    public GameObject Tape;
    private float shortThrowForce;
    public float longThrowForce = 250f;
    Transform projectilesContainer; //generated in Start()
    public GameObject spwaner;
    public GameObject effect;
    public Transform direc;
    public Texture[] LSDtex;
    public Animator ani;
    public AudioSource Bake;
 
 public int randomtextureIndex;

    public RaycastHit hit;



    private void Start()
    {
        projectilesContainer = new GameObject("projectiles").transform;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                print(hit.collider.gameObject);
                if (hit.collider.CompareTag("toaster"))
                {
                    ani.SetTrigger("Bake");
                     if (Bake.isPlaying == false)
                    {
                        Bake.Play();
                    }
                    Instantiate(effect, spwaner.transform.position, Quaternion.identity);
                    shortThrowForce = Random.Range(1f, 1.5f);
                
                    ThrowProjectile(Tape);
                }
            }
        }

        void ThrowProjectile(GameObject prefab)

        {
            randomtextureIndex = Random.Range(0, LSDtex.Length);

            GameObject projectile = Instantiate(
            prefab, spwaner.transform

        );

            projectile.GetComponent<Rigidbody>().AddForce(
                 direc.position * shortThrowForce,
                ForceMode.Impulse
            );

        
         



        }
    }
}

