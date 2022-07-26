using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    //fsm은 각 개별적인 상태를 만들기 때문에 상태글끼리 연결이 안돼있어서  상태들끼리 오류가 생긱는 경우가 적다 근데 상태에 싱글톤을 써서 다른 상태로 불러오면
    //상태들끼리 연결이 되기 때문에 fsm의 장점이 사라진다 그래서 할수 있으면 상속받고 있는 Monster 같은 것에서 받아오는거 말고는 안받아 오는게 좋다.
    private ISTATe CurrentState;
    public static Monster Instance;
    Transform target = null;
    public Transform Target /*=> target;*/ //읽기전용 프로퍼티 축약형 //값을 할당 할때는 set 읽어올때는 get
    {
        get => target;
        set => target = value;
    }
    Collider2D D;
    Animator ani;
    public Animator Ani => ani;
    RaycastHit2D hit;
    SpriteRenderer sprite;
    Rigidbody2D rid;
   public  Rigidbody2D Rid => rid;
    void Start()
    {
        Instance = this;
        SetState(new IDle());
        D = GetComponent<Collider2D>();
        ani = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.Update();
        CharacterState();
    }

    public void SetState(ISTATe nextState)
    {
        if (CurrentState != null)
        {
            CurrentState.OnExit();
        }
        CurrentState = nextState;
        CurrentState.OnEnter(this);
    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player") //player감지하면 target에 player위치값 넣어주고  monster가 움직이는 모션을 true해준다
        {
            target = col.gameObject.transform;
            ani.SetBool("isRun", true);
        }


    }

    private void OnTriggerExit2D(Collider2D col)
    {
            ani.SetBool("isRun", false);
        target = null;
    }


    void CharacterState()
    {
            sprite.flipX = Player.Instance.transform.position.x < transform.position.x;
    }

}
