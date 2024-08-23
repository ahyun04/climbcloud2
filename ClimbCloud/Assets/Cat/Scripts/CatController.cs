using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Animator animator;
    public float moveForce;
    public float jumpForce;

    private void Start()
    {
        //Rigidbody2D rb2D = this.gameObject.GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        bool isLeftArrowHold = Input.GetKey(KeyCode.LeftArrow);
        bool isRightArrowHold = Input.GetKey(KeyCode.RightArrow);

        if (isLeftArrowHold)
        {
            Debug.Log("Left");
            this.rb2D.AddForce(new Vector2(-1 * this.moveForce, 0));

            this.transform.localScale = new Vector3(-1, 1, 1);

            this.animator.SetInteger("State", 1);

        }
        else if (isRightArrowHold)
        {
            Debug.Log("Right");
            this.rb2D.AddForce(new Vector2(+1 * this.moveForce, 0));

            this.transform.localScale = new Vector3(1, 1, 1);

            this.animator.SetInteger("State", 1);
        }
        else
        {
            this.animator.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //jump
            this.rb2D.AddForce(new Vector2(0, +1 * this.jumpForce));
        }

    }
}
