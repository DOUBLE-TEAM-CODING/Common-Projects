using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float runspeed;
    public bool UpdateSword = true;
    public float sensivity;
    public Animator animator;
    public GameObject SwordInHand;
    public GameObject SwordInSheath;
    public Rigidbody rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ---- W
        ButtonW();
        // ---- S
        ButtonS();
        // ---- A
        ButtonA();
        // ---- D
        ButtonD();
        // ---- SPACE
        ButtonSpace();
        // ---- MOUSE
        MouseButton();
        // ---- X
        ButtonX();
    }

    public void AnimEndWithdrawindSword()
    {
        SwordInHand.SetActive(true);
        SwordInSheath.SetActive(false);
        UpdateSword = false;

    }
    public void AnimEndWithdrawindSword2()
    {
        SwordInHand.SetActive(false);
        SwordInSheath.SetActive(true);
        UpdateSword = true;
    }

    public void ButtonW()
    {
        // ---- W

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Walk", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("Running", true);
                transform.localPosition += transform.forward * runspeed * Time.deltaTime;
                animator.SetBool("Walk", false);
            }
            else
            {
                transform.localPosition += transform.forward * speed * Time.deltaTime;
                animator.SetBool("Running", false);
            }
        }
        // ---- SHIFT

        if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Running", false);
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Running", false);
        }
        if (!Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Walk", false);
        }
    }

    public void ButtonS()
    {
        // ---- S

        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += -transform.forward * speed * Time.deltaTime;
            animator.SetBool("WalkBack", true);
        }
        if (!Input.GetKey(KeyCode.S))
        {
            animator.SetBool("WalkBack", false);
        }
    }


    public void ButtonA()
    {
        // ---- A

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(0, -sensivity * Time.deltaTime, 0);
        }
    }


    public void ButtonD()
    {
        // ---- D

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(0, sensivity * Time.deltaTime, 0);
        }
    }


    public void ButtonX()
    {
        // ---- X

        if (Input.GetKey(KeyCode.X))
        {
            if (UpdateSword == true)
            {
                animator.SetBool("WithdrawindSword", true);
            }
            if (UpdateSword == false)
            {
                animator.SetBool("WithdrawindSword2", true);
            }

        }
        if (!Input.GetKey(KeyCode.X))
        {
            animator.SetBool("WithdrawindSword", false);
            animator.SetBool("WithdrawindSword2", false);
        }
    }


    public void MouseButton()
    {
        // ---- MOUSE

        if (Input.GetMouseButton(0))
        {
            if (UpdateSword == false)
            {
                animator.SetBool("SwordAttack", true);
            }

        }
        if (!Input.GetMouseButton(0))
        {
            animator.SetBool("SwordAttack", false);
        }
    }


    public void ButtonSpace()
    {
        // ---- SPACE

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Running", false);
            animator.SetBool("Walk", false);
            animator.SetBool("WalkBack", false);
            animator.SetBool("Jump", true);
        }
        if (!Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Jump", false);
        }
    }
}