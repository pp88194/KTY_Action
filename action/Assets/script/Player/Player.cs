using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public Vector3 dir;
    public Vector3 Dir => dir;
    SpriteRenderer sprite;
    int cnt = 0;
    Animator ani;
    public Animator Ani => ani;
    Rigidbody2D rid;
    public Rigidbody2D Rigid => rid;
    private Istate currentState;
    RaycastHit2D hit;
    public RaycastHit2D Hit => hit;
    int health = 3;
    int maxhealth = 3;
    bool isDie = false;
    bool isUnBeatTime = false;
    // Start is called before the first frame update
    void Awake()
    {
        health = maxhealth;
        Instance = this;
        sprite = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        rid = GetComponent<Rigidbody2D>();
        SetState(new Idle());
    }
    

    // Update is called once per frame
    void Update()
    {

        currentState.Update();
        CharacterState();


        float h = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        dir = new Vector3(h, z, 0);
        dir.Normalize();

        Debug.DrawRay(this.transform.position + new Vector3(h, z) * 1.0f, Vector3.forward, Color.blue);
        hit = Physics2D.Raycast(this.transform.position + dir  * 1.0f, Vector3.forward, 1, LayerMask.GetMask("map"));  //2d면 이렇게 쓰고 3d에서만 Physics2D hit넣어서 함 왜냐하면 반환형 때문
       
        if(health == 0)
        {
            Debug.Log("die");
            gameObject.SetActive(false);
        }

    }

    public void SetState(Istate nextState)
    {
        //기존의 상태가 존재 했다면  OnExit()호출
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = nextState;
        currentState.OnEnter(this);

    }

    //void Move()
    //{
    //    float h = Input.GetAxisRaw("Horizontal");
    //    float z = Input.GetAxisRaw("Vertical");
    //    dir = new Vector3(h,z,0);
    //    dir.Normalize();

    //    RaycastHit2D hit;
    //    Debug.DrawRay(this.transform.position + new Vector3(h, z) * 1.5f, Vector3.zero, Color.blue);
    //    hit = Physics2D.Raycast(this.transform.position + new Vector3(h, z) * 1.5f, Vector3.zero, 1,LayerMask.GetMask("map"));  //2d면 이렇게 쓰고 3d에서만 Physics2D hit넣어서 함 왜냐하면 반환형 때문
    //    if (hit)
    //    {
    //        //transform.position += dir * speed * Time.deltaTime;
    //        rid.velocity = dir * speed; // rid 를 쓸거라서 transform.position을 쓰지 않고 속도에 값을 넣어줘서 실행한다 rid쓰는데  transform.position을 쓰면 인식을 못해 아래로 떨어진다 중력때문에
    //    }
    //}

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
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Monster" && collision.isTrigger  && !isUnBeatTime)
        {
            health--;
            Debug.Log(health);
            if(health >0)
            {
                isUnBeatTime = true;
                StartCoroutine("UnBeatTime");
            }
        }
    }


    IEnumerator UnBeatTime()
    {
        int countTime = 0;

        while(countTime < 10)
        {
            if(countTime%2 == 0)
            {
                sprite.color = new Color32(255, 255, 255, 90);
            }
            else
            {
                sprite.color = new Color32(255, 255, 255, 180);
            }
            yield return new WaitForSeconds(0.2f);
            countTime++;
        }
        sprite.color = new Color32(255, 255, 255, 255);

        isUnBeatTime = false;

        yield return null;
    }
}

