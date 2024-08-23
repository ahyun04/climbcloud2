using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KingHumanController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb2D;
    public float moveSpeed = 1f;

    void Update()
    {
        //-1, 0, 1
        float h = Input.GetAxisRaw("Horizontal");
        if (h == 0)
        {
            animator.SetInteger("State", 0);   //Idle
        }
        else
        {
            //-1, 1
            animator.SetInteger("State", 1);    //Run
            this.transform.localScale = new Vector3(h, 1, 1);

            this.rb2D.velocity = new Vector2(h * moveSpeed, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) //리지드 바디 콜라이더끼리 충돌 했을 때
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) //트리거가 다른 콜라이더끼리 충돌했을 때(한번 실행)
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
