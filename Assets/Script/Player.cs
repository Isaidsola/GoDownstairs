using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    /**速度*/
    public float speed = 2f;
    private float horizontalMove;

    /**動畫*/
    public Animator animator;

    /**鋼體物件*/
    private Rigidbody2D rb;
    /**碰撞體*/
    private Collider2D coll;
    /**目前是否在地板*/
    public bool isJumping;
    /**地板層*/
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        coll = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //只有站在地板當下才能跳,否則會可以連續跳
        if (isJumping == false && Input.GetKey(KeyCode.UpArrow))
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, 3);
        }
    }
    //物理運算用
    private void FixedUpdate()
    {
        //角色移動判斷
        Move();

        //角色與地面圖層發生碰撞
        //新增Layer"Ground"之後地板類物件都放到Ground層級
        isJumping = !coll.IsTouchingLayers(groundLayer);
    }

    /**
     * 位移
     */
    private void Move()
    {
        //Input.GetAxisRaw("Horizontal")直接獲得-1、0、1
        //若用Input.GetAxis("Horizontal")獲得的是-1~1，包括範圍內小數值
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        this.transform.localScale = new Vector3(horizontalMove > 0 ? -1 : 1, 1, 0);
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);

        //改變動畫參數(horizontalMove往左會是負值,所以要用abs)
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        animator.SetBool("IsJumping", isJumping);
    }
}
