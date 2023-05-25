using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnemployedOwnedStates
{
    public class RestAndSleep : State<Unemployed>
    {
        public override void Enter(Unemployed entity)
        {
            entity.CurrentLocation = Locations.SweetHome;
            entity.Stress = 0;
            entity.Fatigue = 0;

            entity.PrintText("소파에 눕는다");
        }

        public override void Execute(Unemployed entity)
        {
            string state = Random.Range(0, 2) == 0 ? "잠자는 중....." : "TV 시청 중......";
            entity.PrintText(state);

            entity.Bored += Random.Range(0, 100) < 70 ? 1 : -1;

            if (entity.Bored >= 4) entity.ChangeState(UnemployedStates.PlayAGame);
        }

        public override void Exit(Unemployed entity)
        {
            entity.PrintText("그냥 나간다.");
        }
    }

    public class PlayAGame : State<Unemployed>
    {
        public override void Enter(Unemployed entity)
        {
            entity.CurrentLocation = Locations.PCRoom;
            entity.PrintText("PC방으로 들어간다.");
        }

        public override void Execute(Unemployed entity)
        {
            entity.PrintText("게임중.......");

            int randState = Random.Range(0, 10);
            if (randState == 0 || randState == 9)
            {
                entity.Stress += 20;
                entity.ChangeState(UnemployedStates.HitTheBottle);
            }
            else
            {
                entity.Bored--;
                entity.Fatigue += 2;

                if (entity.Bored <= 0 || entity.Fatigue >= 50) entity.ChangeState(UnemployedStates.RestAndSleep);
            }
        }

        public override void Exit(Unemployed entity)
        {
            entity.PrintText("PC방에서 나온다");
        }
    }

    public class HitTheBottle : State<Unemployed>
    {
        public override void Enter(Unemployed entity)
        {
            entity.CurrentLocation = Locations.Pub;
            entity.PrintText("술집으로 들어간다.");
        }

        public override void Execute(Unemployed entity)
        {
            entity.PrintText("술 마시는 중......");

            entity.Bored += Random.Range(0, 2) == 0 ? 1 : -1;

            entity.Stress -= 4;
            entity.Fatigue += 4;

            if (entity.Stress <= 0 || entity.Fatigue >= 50) entity.ChangeState(UnemployedStates.RestAndSleep);
        }

        public override void Exit(Unemployed entity)
        {
            entity.PrintText("술집에서 나온다.");
        }
    }

    public class VisitBathroom : State<Unemployed>
    {
        public override void Enter(Unemployed entity)
        {
            entity.PrintText("화장실에 들어간다.");
        }

        public override void Execute(Unemployed entity)
        {
            entity.PrintText("볼일 보는 중......");
            entity.RevertToPreviousState();
        }

        public override void Exit(Unemployed entity)
        {
            entity.PrintText("화장실에서 나온다.");
        }
    }

    /// <summary>
    /// 화장실을 갈 것인지 결정
    /// </summary>
    public class StateGlobal : State<Unemployed>
    {
        public override void Enter(Unemployed entity)
        {
        }

        public override void Execute(Unemployed entity)     // 10퍼센트의 확률로 화장실 가는 상태로 변경
        {
            if (entity.CurrentState == UnemployedStates.VisitBathroom) return;

            int bathroomState = Random.Range(0, 100);
            if (bathroomState < 10) entity.ChangeState(UnemployedStates.VisitBathroom);
        }

        public override void Exit(Unemployed entity)
        {
        }
    }
}