using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumList : SingleTon<EnumList>
{
    public enum PlayerState
    {
        Idle,                   //   ���
        Walk,                  //   �ȱ�
        Run,                   //   �޸���
        Attack,                //   ����
        Skill                    //   Ư�� �ɷ�
    }
    
    public enum EnemyState
    {
        Idle,                   //   ���
        Walk,                  //   �ȱ�
        Run,                   //   �޸���
        Attack,               //   ����
        Skill                   //   Ư�� �ɷ�
    }
}
