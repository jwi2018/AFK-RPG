using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumList : SingleTon<EnumList>
{
    public enum PlayerState
    {
        Idle,                   //   대기
        Walk,                  //   걷기
        Run,                   //   달리기
        Attack,                //   공격
        Skill                    //   특수 능력
    }
    
    public enum EnemyState
    {
        Idle,                   //   대기
        Walk,                  //   걷기
        Run,                   //   달리기
        Attack,               //   공격
        Skill                   //   특수 능력
    }
}
