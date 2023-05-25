using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StudentOwnedStates
{
    public class RestAndSleep : State<Student>
    {
        public override void Enter(Student entity)
        {
            entity.CurrentLocation = Locations.SweetHome;
            entity.Stress = 0;

            entity.PrintText("���� ���Դ�.");
            entity.PrintText("ħ�뿡 ���� ���� �ܴ�.");
        }

        public override void Execute(Student entity)
        {
            entity.PrintText("�� �ڴ� ��.........");

            if (entity.Fatigue > 0) entity.Fatigue -= 10;
            else entity.ChangeState(StudentStates.StudyHard);
        }

        public override void Exit(Student entity)
        {
            entity.PrintText("�Ͼ�� �� ������ ������.");
        }
    }

    public class StudyHard : State<Student>
    {
        public override void Enter(Student entity)
        {
            entity.CurrentLocation = Locations.Library;
            entity.PrintText("���������� �Դ�.");
        }

        public override void Execute(Student entity)
        {
            entity.PrintText("������........");

            entity.Knowledge++;
            entity.Stress++;
            entity.Fatigue++;

            if (entity.Knowledge >= 3 && entity.Knowledge <= 10)
            {
                int isExit = Random.Range(0, 2);
                if (isExit == 1 || entity.Knowledge == 10) entity.ChangeState(StudentStates.TakeAExam);
            }

            if (entity.Stress >= 20) entity.ChangeState(StudentStates.PlayAGame);

            if (entity.Fatigue >= 50) entity.ChangeState(StudentStates.RestAndSleep);
        }

        public override void Exit(Student entity)
        {
            entity.PrintText("�������� ������.");
        }
    }

    public class TakeAExam : State<Student>
    {
        public override void Enter(Student entity)
        {
            entity.CurrentLocation = Locations.LectureRoom;
            entity.PrintText("���ǽǿ� �� �������� �޾Ҵ�.");
        }

        public override void Execute(Student entity)
        {
            int examScore = 0;

            if (entity.Knowledge == 10) examScore = 10;
            else
            {
                int randIndex = Random.Range(0, 10);
                examScore = randIndex < entity.Knowledge ? Random.Range(6, 11) : Random.Range(1, 6);
            }

            entity.Knowledge = 0;
            entity.Fatigue += Random.Range(5, 11);

            entity.TotalScore += examScore;
            entity.PrintText($"���� ����({examScore}), ����({entity.TotalScore})");

            if (entity.TotalScore >= 100)
            {
                GameController.Stop(entity);
                return;
            }

            if (examScore <= 3) entity.ChangeState(StudentStates.HitTheBottle);
            else if (examScore <= 7) entity.ChangeState(StudentStates.StudyHard);
            else entity.ChangeState(StudentStates.PlayAGame);
        }

        public override void Exit(Student entity)
        {
            entity.PrintText("���ǽ� ���� ���� ���´�.");
        }
    }

    public class PlayAGame : State<Student>
    {
        public override void Enter(Student entity)
        {
            entity.CurrentLocation = Locations.PCRoom;
            entity.PrintText("PC������ ����.");
        }

        public override void Execute(Student entity)
        {
            entity.PrintText("������.......");

            int randState = Random.Range(0, 10);
            if (randState == 0 || randState == 9)
            {
                entity.Stress += 20;
                entity.ChangeState(StudentStates.HitTheBottle);
            }
            else
            {
                entity.Stress--;
                entity.Fatigue += 2;

                if (entity.Stress <= 0) entity.ChangeState(StudentStates.StudyHard);
            }
        }

        public override void Exit(Student entity)
        {
            entity.PrintText("PC�濡�� ���´�");
        }
    }

    public class HitTheBottle : State<Student>
    {
        public override void Enter(Student entity)
        {
            entity.CurrentLocation = Locations.Pub;
            entity.PrintText("�������� ����.");
        }

        public override void Execute(Student entity)
        {
            entity.PrintText("�� ���ô� ��......");

            entity.Stress -= 5;
            entity.Fatigue += 5;

            if (entity.Stress <= 0 || entity.Fatigue >= 50) entity.ChangeState(StudentStates.RestAndSleep);
        }

        public override void Exit(Student entity)
        {
            entity.PrintText("�������� ���´�.");
        }
    }
}