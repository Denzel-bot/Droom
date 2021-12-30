using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript2 : MonoBehaviour
{
   public bool isPlayAnim = false;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(ray.origin, hit.point);
                //print(hit.collider.gameObject.name);

                //curObject = hit.collider.gameObject;
                if (hit.collider.CompareTag("model"))
                {
                    isPlayAnim = true;
                    print("123");
                }
                // 显示当前选中对象的名称
                //  print(hit.collider.gameObject);
            }

        }
        if (isPlayAnim)
        {
            anim.SetBool("isOpen", true);
            isPlayAnim = false;
        }

    }
}

