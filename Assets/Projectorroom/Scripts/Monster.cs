using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyStates { PATROL, CHASE, EAT, PROJECT }
[RequireComponent(typeof(NavMeshAgent))]

public class Monster : MonoBehaviour
{
    public NavMeshAgent agent;
    public EnemyStates enemyStates;
    public GameObject player;
    public GameObject potrolPoint;
    public GameObject timeline;
    public float sightRadius;
    public bool chase = false;
    public float range;
    public bool eat = false;
    public Vector3 waypoint;
    public AudioSource wrongfood;
    public GameObject effect;
    public GameObject rukou;
    public bool effe;
    public Transform projectPoint;
    public GameObject AimPoint;
    public Transform Screen;
    public GameObject ProjectLight;
    public GameObject portal;
    public bool test;
    public Transform MonsterP;
    public GameObject FacetoScreen;
    public Transform playerr;
    public bool Final;
    public AudioSource Step;
    public GameObject Project;
    public GameObject Video;
    public GameObject FinalTime;
    public bool isMoving;
    public Animator animator;
   

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        chase = false;
    }
    void Start()
    {
        GetnewWaypont();
    }
    void Update()
    { 
        if (effe == false)
        {
            if (GameObject.Find("Pickup").GetComponent<PickSys>().isGrabing == true || GameObject.Find("Pickup").GetComponent<PickSys>().Insert == true || GameObject.Find("Pickup").GetComponent<PickSys>().holdOthers == true|| GameObject.Find("Pickup").GetComponent<PickSys>().holdright == true || GameObject.Find("Pickup").GetComponent<PickSys>().holdS == true)
            {

                chase = true;

            }
            SwichStates();
            if (GameObject.Find("Pickup").GetComponent<PickSys>().isGrabing == false && GameObject.Find("Pickup").GetComponent<PickSys>().Insert == false)
            {
                chase = false;


            }
        }
    if(GameObject.Find("Set").GetComponent<Set>().reset ==true)
        {
            effe = false;
        }
        if (effe == true && Final == false)
        {
            agent.speed = 15;
            agent.angularSpeed = 70;
            effect.SetActive(true);
            agent.destination = projectPoint.position;
            AimPoint.transform.SetParent(Screen);
            AimPoint.transform.localPosition = Vector3.zero;
            AimPoint.transform.localRotation = Quaternion.Euler(Vector3.zero);
            AimPoint.transform.localScale = Vector3.one;
            if (MonsterP.position.x == projectPoint.position.x && MonsterP.position.z == projectPoint.position.z)
            {
                ProjectLight.SetActive(true);
                portal.SetActive(true);
                test = true;
                FacetoScreen.SetActive(true);
                Project.SetActive(true);
                animator.SetBool("Project", true);
            }


        }
        if (effe == true&&Final==true)
        {
            agent.speed = 15;
            agent.angularSpeed = 70;
            effect.SetActive(true);
            agent.destination = projectPoint.position;
            AimPoint.transform.SetParent(Screen);
            AimPoint.transform.localPosition = Vector3.zero;
            AimPoint.transform.localRotation = Quaternion.Euler(Vector3.zero);
            AimPoint.transform.localScale = Vector3.one;
            if (MonsterP.position.x == projectPoint.position.x && MonsterP.position.z == projectPoint.position.z)
            {
                ProjectLight.SetActive(true);
                test = true;
                FacetoScreen.SetActive(true);
                Project.SetActive(true);
                animator.SetBool("Project", true);
                Video.SetActive(true);
                FinalTime.SetActive(true);
            }


        }
        if (effe == false)
        {

            ProjectLight.SetActive(false);
            portal.SetActive(false);
            Project.SetActive(false);
            test = true;
            FacetoScreen.SetActive(false);
            AimPoint.transform.SetParent(playerr);
            AimPoint.transform.localPosition = Vector3.zero;
            AimPoint.transform.localRotation = Quaternion.Euler(Vector3.zero);
            AimPoint.transform.localScale = Vector3.one;
            animator.SetBool("Project", false);
          
        }
     
    


    }
    void SwichStates()
    { 
            if (chase == true)
            {
                agent.speed =60;
                agent.angularSpeed = 440;
                if (!FoundPlayer())
                {
                    agent.destination = player.transform.position;
                }
                if (FoundPlayer())
                {
                    agent.destination = agent.transform.position;
                }
            }
            if (chase == false)
            {
                agent.speed = 15;
                agent.angularSpeed = 120;
                if (transform.position.x == waypoint.x && transform.position.z == waypoint.z)
                {
                    GetnewWaypont();
                }
                else
                {
                    agent.destination = waypoint;
                }
            
         
        }

    }
    bool FoundPlayer()
    {
        var colliders = Physics.OverlapSphere(transform.position,sightRadius);
        foreach(var target in colliders)
        {
            if(target.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;

    }
    void GetnewWaypont()
    {
        float randomX = Random.Range(-range, range);
        float randomZ = Random.Range(-range, range);
        Vector3 randomPoint = new Vector3(potrolPoint.transform.position.x + randomX, transform.position.y,potrolPoint.transform.position.z + randomZ);
        NavMeshHit hit;
        waypoint = NavMesh.SamplePosition(randomPoint, out hit, range, 1) ? hit.position : transform.position;
        
    }
    private void OnDrawGizmosSelected()
    {
        
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(potrolPoint. transform.position, range);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, sightRadius);
        
    }
}
