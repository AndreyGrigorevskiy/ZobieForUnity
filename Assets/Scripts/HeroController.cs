using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{

    public CharacterController controller;
    public Animator animator;
    public float speedMove = 3f;
    public float speedRotate = 180f;
    public float minY = -20F;
    public float maxY = 20F;
    private float currentY;
    private int health = 20;

    public Gun gun;

    private Vector3 moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        currentY = Camera.main.transform.rotation.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isGrounded)
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            float ySpeed = moveSpeed.y;
            float mx = Input.GetAxis("Mouse X");
            float my = Input.GetAxis("Mouse Y");
            if ((vertical != 0) || (horizontal !=0))
            {
                controller.Move(transform.forward * vertical * speedMove * Time.deltaTime);

                controller.Move(transform.right * horizontal * speedMove * Time.deltaTime);
                animator.SetBool("Walk", true);
            }
            else
            {
                animator.SetBool("Walk", false);
            }

            if (mx != 0)
            {
                transform.Rotate(transform.up * mx * speedRotate * Time.deltaTime);
            }
            
            if(my != 0)
            {
                currentY = Mathf.Clamp(currentY - my * speedRotate * Time.deltaTime, minY, maxY);
                Vector3 camRotation = Camera.main.transform.rotation.eulerAngles;
                Camera.main.transform.rotation = Quaternion.Euler(currentY, camRotation.y, camRotation.z);
            }

            if(Input.GetMouseButton(0))
            {
                gun.Shoot();
                animator.SetBool("Shoot", true);
            }
            else
            {
                animator.SetBool("Shoot", false);
            }

        }
        controller.Move(Physics.gravity * Time.deltaTime);
        
    }


    public void Damage()
    {
        if(health<=0)
        {
            GameManager.instance.deadUnit(gameObject);
        }
        else
        {
            health--;
        }
        
    }
}
