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
        if (Input.GetKeyDown("1")) ChangeStateEnumList(EnumList.PlayerState.Idle);
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

    private void ChangeStateEnumList(EnumList.PlayerState playerState)
    {

    }

    private IEnumerator Idle()
    {
        Debug.Log("��� ���·� ����");
        Debug.Log("ü�� / ���� �ʴ� 10�� �ڵ� ȸ��");

        while (true)
        {
            Debug.Log("�÷��̾ ������Դϴ�.");
            yield return null;
        } 
    }

    private IEnumerator Walk()
    {
        Debug.Log("�̵��ӵ��� 2�� ����");

        while (true)
        {
            Debug.Log("�÷��̾ �ɾ�ϴ�.");
            yield return null;
        }
    }

    private IEnumerator Run()
    {
        Debug.Log("�̵��ӵ��� 5�� ����");

        while (true)
        {
            Debug.Log("�÷��̾ �پ�ϴ�.");
            yield return null;
        }
    }

    private IEnumerator Attack()
    {
        Debug.Log("���� ���� ����");
        Debug.Log("�ڵ� ȸ�� ����");

        while (true)
        {
            Debug.Log("�÷��̾ �����մϴ�.");
            yield return null;
        }
    }
}
