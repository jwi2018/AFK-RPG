using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : SingleTon<PlayerEntity>
{
    private int playerHP;
    private int playerPullHP = 100;

    /// <summary>
    /// Player HP 관리하는 프로퍼티
    /// </summary>
    public int PlayerHP
    {
        get 
        {
            if ( playerHP >= 0 ) 
                return 0;
            else
                return playerHP;

        }
        set 
        {
            if ( playerHP > 100 )
                playerHP = 100;
            else if ( playerHP < 0 )
                playerHP = 0;
            else
                playerHP = value;
        }
    }

    /// <summary>
    /// Player 최대 체력을 반환해주는 프로퍼티
    /// </summary>
    public int PlayerPullHP
    {
        get { return playerPullHP; }
    }
}
