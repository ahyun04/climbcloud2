using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Animator animator;
    public float moveForce;
    public float jumpForce;
    private bool isAttacking = false;
    private bool isMoving = false;

    public GameObject king; 
    public GameObject pig;

    private void Start()
    {
        //Rigidbody2D rb2D = this.gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        bool isLeftArrowHold = Input.GetKey(KeyCode.LeftArrow);
        bool isRightArrowHold = Input.GetKey(KeyCode.RightArrow);
        bool isAHold = Input.GetKey(KeyCode.A);

        if (isLeftArrowHold)
        {
            Debug.Log("Left");
            this.rb2D.AddForce(new Vector2(-1 * this.moveForce, 0));
            this.transform.localScale = new Vector3(-1, 1, 1);
            this.animator.SetInteger("State", 1);
            transform.Translate(Vector3.left * Time.deltaTime);

        }
        else if (isRightArrowHold)
        {
            Debug.Log("Right");
            this.rb2D.AddForce(new Vector2(+1 * this.moveForce, 0));
            this.transform.localScale = new Vector3(1, 1, 1);
            this.animator.SetInteger("State", 1);
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        else
        {
            this.animator.SetInteger("State", 0);
        }

        if (isAHold && !isAttacking)
        {
            StartCoroutine(Attack());
        }
        /* if (Input.GetKeyDown(KeyCode.A)) //&& != animator.GetCurrentAnimatorStateInfo(0).IsName("Attack");
         {
             animator.SetTrigger("Attack");
         }*/

        /* float h = Input.GetAxisRaw("Horizontal");
         if (h > 0)
         {
             transform.localScale = new Vector3(-1, 1, 1);
             animator.SetInteger("State", 1);
         }
         else if (h < 0)
         {
             transform.localScale = new Vector3(1, 1, 1);
             animator.SetInteger("State", 0);
         }
         else this.animator.SetInteger("State", 0);
         transform.Translate(new Vector3(h, 0, 0) * Time.deltaTime);*/
        
    }
    private IEnumerator Attack()
    {
        isAttacking = true;
        StopMoving();
        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        animator.SetInteger("State", 0);
        isAttacking = false;

    }
    private void StopMoving()
    {
        isMoving = false;
        this.animator.SetInteger("State", 0);
        rb2D.velocity = Vector2.zero; 
    }
}
