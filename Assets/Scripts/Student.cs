using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StudentStates
{
    RestAndSleep,
    StudyHard,
    TakeAExam,
    PlayGame,
    HitTheBottle
}

public class Student : BaseGameEntity
{
    private int knowledge, stress, fatigue, totalScore;     // 지식, 스트레스, 피로, 점수
    //private int stress;
    //private int fatigue;
    //private int totalScore;
    private Locations currentLocation;      // 현재 위치

    private State[] states;
    private State currentState;

    public int Knowledge
    {
        set => knowledge = Mathf.Max(0, value);
        get => knowledge;
    }

    public int Stress
    {
        set => stress = Mathf.Max(0, value);
        get => stress;
    }

    public int Fatigue
    {
        set => fatigue = Mathf.Max(0, value);
        get => fatigue;
    }

    public int TotalScore
    {
        set => totalScore = Mathf.Clamp(0, value, 100);
        get => totalScore;
    }

    public Locations CurrentLocation
    {
        set => currentLocation = value;
        get => currentLocation;
    }

    public override void Setup(string name)
    {
        base.Setup(name);

        gameObject.name = $"{ID:D2}_Student_{name}";

        states = new State[System.Enum.GetValues(typeof(StudentStates)).Length];
        states[(int)StudentStates.RestAndSleep] = new StudentOwnedStates.RestAndSleep();
        states[(int)StudentStates.StudyHard] = new StudentOwnedStates.StudyHard();
        states[(int)StudentStates.TakeAExam] = new StudentOwnedStates.TakeAExam();
        states[(int)StudentStates.PlayGame] = new StudentOwnedStates.PlayAGame();
        states[(int)StudentStates.HitTheBottle] = new StudentOwnedStates.HitTheBottle();

        ChangeState(StudentStates.RestAndSleep);

        knowledge = 0;
        stress = 0;
        fatigue = 0;
        totalScore = 0;
        currentLocation = Locations.SweetHome;
    }

    public override void Updated()
    {
        if (currentState != null) currentState.Execute(this);
    }

    public void ChangeState(StudentStates newState)
    {
        if (states[(int)newState] == null) return;

        if (currentState != null) currentState.Exit(this);

        currentState = states[(int)newState];
        currentState.Enter(this);
    }
}
