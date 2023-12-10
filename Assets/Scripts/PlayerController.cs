using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpStrength = 5;

    [SerializeField] private GameObject GroundPoint;
    [SerializeField] private Vector2 GroundPointSize;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private KeyCode attackKey = KeyCode.Mouse0;
    [SerializeField] private GameObject attackPoint;
    [SerializeField] private float attackPointRadius;

    private Rigidbody2D rb;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(moveX));

        Vector3 t = transform.localScale;
        if (moveX > 0)
        {
            t.x = Mathf.Abs(t.x);
        }

        else if (moveX < 0)
        {
            t.x = -Mathf.Abs(t.x);
        }
        transform.localScale = t;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpStrength, ForceMode2D.Impulse);
        }

        Attack();

    }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(GroundPoint.transform.position, GroundPointSize);

            Gizmos.DrawWireSphere(attackPoint.transform.position, attackPointRadius);
        }
        
    bool IsGrounded()
    {
       RaycastHit2D hit = Physics2D.BoxCast(GroundPoint.transform.position, GroundPointSize, 0, Vector2.zero, 0, groundLayerMask);
        return hit.collider != null;

    }

    private void Attack()
    {
        string currentAnimState = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        if(Input.GetKeyDown(attackKey) && currentAnimState != "atack")
        {
            animator.SetTrigger("atack"); 
        }
    }
}
