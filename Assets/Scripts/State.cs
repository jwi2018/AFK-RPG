public  abstract class State
{
    /// <summary>
    /// ���¸� ������ �� 1ȸ ȣ��
    /// </summary>
    /// <param name="entity"></param>
    public abstract void Enter(Student entity);

    /// <summary>
    /// ���¸� ������Ʈ�� �� �� ������ ȣ��
    /// </summary>
    /// <param name="entity"></param>
    public abstract void Execute(Student entity);

    /// <summary>
    /// ���¸� ������ �� 1ȸ ȣ��
    /// </summary>
    /// <param name="entity"></param>
    public abstract void Exit(Student entity);
}
