public  abstract class State<T> where T : class
{
    /// <summary>
    /// ���¸� ������ �� 1ȸ ȣ��
    /// </summary>
    /// <param name="entity"></param>
    public abstract void Enter(T entity);

    /// <summary>
    /// ���¸� ������Ʈ�� �� �� ������ ȣ��
    /// </summary>
    /// <param name="entity"></param>
    public abstract void Execute(T entity);

    /// <summary>
    /// ���¸� ������ �� 1ȸ ȣ��
    /// </summary>
    /// <param name="entity"></param>
    public abstract void Exit(T entity);
}
