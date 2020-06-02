using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    public float jumpForce; // сила прыжка

    public int maxJumps;// кол-во прыжков

    [SerializeField] private int jumpsCount;// кол-во доступных прыжков

    public Transform groundCheck;// находится ли на земле
    public LayerMask whatIsGround;// что мы считаем за землю
    public float checkRadius;//радиус проверки
    private bool isGrounded;// тру - на земле, фолс - нет

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsCount = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);// находится ли на земле?
        if (isGrounded)//если нет большн прыжков и преземлен, то снова может прыгать
        {
            jumpsCount = maxJumps;
        }
    }

    public void Jump()
    {
        if (jumpsCount > 0) 
        {
            jumpsCount --;
            rb.velocity = Vector2.up * jumpForce;
        }

    }
}
