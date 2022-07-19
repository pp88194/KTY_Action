using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Vector3 dir;
    public float speed;
    SpriteRenderer sprite;
    Animator ani;
    Rigidbody2D rid;

    // Start is called before the first frame update
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        rid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CharacterState();
    }


    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        dir = new Vector3(h,z,0);
        dir.Normalize();
        
        RaycastHit2D hit;
        Debug.DrawRay(this.transform.position + new Vector3(h, z) * 1.5f, Vector3.zero, Color.blue);
        hit = Physics2D.Raycast(this.transform.position + new Vector3(h, z) * 1.5f, Vector3.zero, 1,LayerMask.GetMask("map"));  //2d�� �̷��� ���� 3d������ Physics2D hit�־ �� �ֳ��ϸ� ��ȯ�� ����
        if (hit)
        {
            //transform.position += dir * speed * Time.deltaTime;
            rid.velocity = dir * speed; // rid �� ���Ŷ� transform.position�� ���� �ʰ� �ӵ��� ���� �־��༭ �����Ѵ� rid���µ�  transform.position�� ���� �ν��� ���� �Ʒ��� �������� �߷¶�����
        }
    }

    void CharacterState()
    {
        if ((Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal")) && Input.GetAxisRaw("Horizontal") != 0)
        {
            sprite.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        if (rid.velocity.x == 0 && rid.velocity.y == 0)
        {
            ani.SetBool("isrun", false);
        }
        else
        {
            ani.SetBool("isrun", true);
        }



        if ((Input.GetMouseButton(0)))
        {

            ani.SetBool("isattack", true);
            speed = 0;

        }
        else
        {
            ani.SetBool("isattack", false);
            speed = 2;

        }
    }


}
