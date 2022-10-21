using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    /**�t��*/
    public float speed = 2f;
    private float horizontalMove;

    /**�ʵe*/
    public Animator animator;

    /**���骫��*/
    private Rigidbody2D rb;
    /**�I����*/
    private Collider2D coll;
    /**�ثe�O�_�b�a�O*/
    public bool isJumping;
    /**�a�O�h*/
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
        //�u�����b�a�O��U�~���,�_�h�|�i�H�s���
        if (isJumping == false && Input.GetKey(KeyCode.UpArrow))
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, 3);
        }
    }
    //���z�B���
    private void FixedUpdate()
    {
        //���Ⲿ�ʧP�_
        Move();

        //����P�a���ϼh�o�͸I��
        //�s�WLayer"Ground"����a�O�����󳣩��Ground�h��
        isJumping = !coll.IsTouchingLayers(groundLayer);
    }

    /**
     * �첾
     */
    private void Move()
    {
        //Input.GetAxisRaw("Horizontal")������o-1�B0�B1
        //�Y��Input.GetAxis("Horizontal")��o���O-1~1�A�]�A�d�򤺤p�ƭ�
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        this.transform.localScale = new Vector3(horizontalMove > 0 ? -1 : 1, 1, 0);
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);

        //���ܰʵe�Ѽ�(horizontalMove�����|�O�t��,�ҥH�n��abs)
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        animator.SetBool("IsJumping", isJumping);
    }
}
