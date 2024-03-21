using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    //[SerializeField] private float runSpeed;
    //[SerializeField] private float walkSpeed;
    //[SerializeField] private float jumpForce;
    [SerializeField] CharacterController controller;
    [SerializeField] private LayerMask groundMask;
   // private Rigidbody rb;
    private Vector2 movement = Vector2.zero;
    public float timer;

    float turnSmoothTime = 0.1f;
    float smoothTurnVelocity;
    public Transform cam;
    private Animator animator;
    private string currentAnimation = "";
    //public bool grounded = false;

   


    // Start is called before the first frame update
    void Start()
    {
       // rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //movementSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(movement.x, 0f, movement.y).normalized;

        if(direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothTurnVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * movementSpeed * Time.deltaTime);
            
        }

      //  if(grounded && Input.GetKeyDown(KeyCode.Space))
       // {
            //rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
       // }
     
        CheckAnimation();
    }

    private void FixedUpdate()
    {

        Ray groundCheckRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(groundCheckRay,out RaycastHit info, 4f))
        {
            transform.position = info.point;
            Debug.Log(info.point);
        }
        
    }
    private void CheckAnimation()
    {

        if(timer > 20)
        {
            ChangeAnimation("Idle Timeout");
            timer = timer + Time.deltaTime;
            if (timer > 27)
            {
                timer = 0;
            }
        }
        else if (movement.y == 1 || movement.y == -1 || movement.x == 1 || movement.x == -1)
        {
            timer = 0;
            ChangeAnimation("Run");
        }
        else
        {
            ChangeAnimation("Idle");
            timer = timer + Time.deltaTime;
        }     
    }

    private void ChangeAnimation(string animation, float crossfade = 0.2f)
    {
        if (currentAnimation != animation)
        {
            currentAnimation = animation;
            animator.CrossFade(animation, crossfade);
        }
    }
}
