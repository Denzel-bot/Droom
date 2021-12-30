using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCharacterControllerMovement: MonoBehaviour
{
    private CharacterController characterController;
    
    private Vector3 movementDirection;
    private Transform characterTransform;
    private bool isCrouched;
    private float originHeight;
    public float CrouchHeight = 1f;

    public float SprintingSpeed;
    public float WalkSpeed;

    public float SprintingSpeedWhenCrouched;
    public float WalkSpeedWhenCrouched;

    public float Gravity=9.8f;
    public float JumpHeight;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterTransform= GetComponent<Transform>();
        originHeight = characterController.height;
        //characterTransform=transform;替
    }

    private void Update()
    {
        float tmp_CurrentSpeed = WalkSpeed;
        if (characterController.isGrounded)
        {
            var tmp_Horizontal = Input.GetAxis("Horizontal");
            var tmp_Vertical = Input.GetAxis("Vertical");
            movementDirection =
            characterTransform.TransformDirection(new Vector3(tmp_Horizontal, 0, tmp_Vertical));
            //characterController.SimpleMove(tmp_MovementDirection * Time.deltaTime * MovementSpeed);该函数受重力影响过大

            if (Input.GetButtonDown("Jump"))
            {
                movementDirection.y = JumpHeight;
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                var tmp_CurrentHeight = isCrouched ? originHeight : CrouchHeight;
                StartCoroutine(DoCrouch(tmp_CurrentHeight));
                isCrouched = !isCrouched;
            }
            /*if (Input.GetKey(KeyCode.LeftShift))
            {
                tmp_CurrentSpeed = SprintingSpeed;
            }
            else
            {
                tmp_CurrentSpeed = WalkSpeed;
            }下方是优化代码——简洁明了*/
            if (isCrouched)
            {
                tmp_CurrentSpeed = Input.GetKey(KeyCode.LeftShift) ? SprintingSpeedWhenCrouched : WalkSpeedWhenCrouched;
            }
            else
            {
                tmp_CurrentSpeed = Input.GetKey(KeyCode.LeftShift) ? SprintingSpeed : WalkSpeed;
            }
        }
        movementDirection.y -= Gravity * Time.deltaTime;
        characterController.Move(tmp_CurrentSpeed * Time.deltaTime * movementDirection);
    }

    private IEnumerator DoCrouch(float _target)
    {
        float tem_CurrentHeight = 0;
        while (Mathf.Abs(characterController.height - _target) > 0.1f)
        {
            yield return null;
            characterController.height = Mathf.SmoothDamp(characterController.height, _target, ref tem_CurrentHeight, Time.deltaTime * 5);
        }
    }
}
