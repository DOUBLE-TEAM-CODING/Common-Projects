using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float runspeed;
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

        // ---- MOUSE

        if (Input.GetMouseButton(0))
        {
            animator.SetBool("SwordAttack", true);
        }
        if (!Input.GetMouseButton(0))
        {
            animator.SetBool("SwordAttack", false);
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

        // ---- X

        if (Input.GetKey(KeyCode.X))
        {
            animator.SetBool("WithdrawindSword", true);
            if (IsAnimationPlaying("WithdrawindSword") == true)
            {
                SwordInHand.SetActive(true);
                SwordInSheath.SetActive(false);
            }
            
        }
        if (!Input.GetKey(KeyCode.X))
        {
            animator.SetBool("WithdrawindSword", false);
        }

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

        // ---- D

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(0, sensivity * Time.deltaTime, 0);
        }

        // ---- A

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(0, -sensivity * Time.deltaTime, 0);
        }

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

    private void FixedUpdate()
    {
        
    }
    public bool IsAnimationPlaying(string animationName)
    {
        // берем информацию о состоянии
        var animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        // смотрим, есть ли в нем имя какой-то анимации, то возвращаем true
        if (animatorStateInfo.IsName(animationName))
            return true;

        return false;
    }
}
