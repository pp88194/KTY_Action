using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private enum PlayerState { Idle = 0, Run, Attack }
    private PlayerState playerstate;
    private bool ischanged = false;
    // Start is called before the first frame update
   private  void Awake()
    {
        ChangeState(PlayerState.Idle);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1")) ChangeState(PlayerState.Idle);
        else if (Input.GetKeyDown("2")) ChangeState(PlayerState.Run);
        else if (Input.GetKeyDown("3")) ChangeState(PlayerState.Attack);
        UpdateState();
    }

    private void UpdateState()
    {
        if(playerstate == PlayerState.Idle)
        {
            Debug.Log("대기중");
        }
        else if (playerstate == PlayerState.Run)
        {
            Debug.Log("달리는중");
        }
        else if (playerstate == PlayerState.Attack)
        {
            Debug.Log("공격하는중");
        }
    }

    private void ChangeState(PlayerState newstate)
    {
        playerstate = newstate;
        ischanged = true;
    }
}
