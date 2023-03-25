using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Walk,
    Run,
    Attack
}

public class PlayerController : MonoBehaviour
{
    private PlayerState playerState;

    private void Awake()
    {
        ChangeState(PlayerState.Idle);
    }

    private void Update()
    {
        if (Input.GetKeyDown("1"))            ChangeState(PlayerState.Idle);
        else if (Input.GetKeyDown("2"))     ChangeState(PlayerState.Walk);
        else if (Input.GetKeyDown("3"))     ChangeState(PlayerState.Run);
        else if (Input.GetKeyDown("4"))     ChangeState(PlayerState.Attack);
    }

    private void ChangeState(PlayerState newState)
    {
        StopCoroutine(playerState.ToString());
        playerState = newState;
        StartCoroutine(playerState.ToString());
    }

    private IEnumerator Idle()
    {
        Debug.Log("대기 상태로 변경");
        Debug.Log("체력 / 마력 초당 10씩 자동 회복");

        while (true)
        {
            Debug.Log("플레이어가 대기중입니다.");
            yield return null;
        } 
    }

    private IEnumerator Walk()
    {
        Debug.Log("이동속도를 2로 설정");

        while (true)
        {
            Debug.Log("플레이어가 걸어갑니다.");
            yield return null;
        }
    }

    private IEnumerator Run()
    {
        Debug.Log("이동속도를 5로 설정");

        while (true)
        {
            Debug.Log("플레이어가 뛰어갑니다.");
            yield return null;
        }
    }

    private IEnumerator Attack()
    {
        Debug.Log("공격 모드로 변경");
        Debug.Log("자동 회복 중지");

        while (true)
        {
            Debug.Log("플레이어가 공격합니다.");
            yield return null;
        }
    }
}
