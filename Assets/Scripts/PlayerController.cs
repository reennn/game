using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]

    public int maxHealth;//максимальное кол-во жизней
    public float currentHealth;//текущее здоровье
    public float speed = 10f;//скорость передвижения

    //public HealthBar healthBar;

    public GameObject respawn;


    public Rigidbody2D rb;
    public Animator charAnimator;
    public SpriteRenderer sprite;


    

    private void Awake()
    {// получение компонентов
        rb = GetComponent<Rigidbody2D>();
        charAnimator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            Move();
        }



        //if (!Input.anyKey)
        //{
        //    charAnimator.SetInteger("State", 0);
        //}
    }

    void FixedUpdate()
    {
    

    }

    void Move()
    {//передвижение игрока
        Vector3 tempvector = Vector3.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + tempvector, speed * Time.deltaTime);
        //charAnimator.SetInteger("State", 1);
        //if (!isGrounded)//для анимации прыжка
        //{
        //    //charAnimator.SetInteger("State", 2);//анимация прыжка
        //}
        if (tempvector.x > 0)//для поворота игрока
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }

    

}
