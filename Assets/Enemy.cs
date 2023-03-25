using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float maxHp = 100f;
    [SerializeField] private float disappearTime = 1f;
    Animator animator;
    public Transform player;
    public float Hp;
    public float Damage;
    public float speed;
    public float atkCooltime = 4;
    public float atkDelay;
    public Vector2 boxSize;
    [SerializeField] private Transform boxpos;

    // Start is called before the first frame update
    void Start()
    {
        Hp = maxHp;
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage(float damage)
    {
        Hp -= damage;
        if (Hp <= 0f)
        {
            StartCoroutine(Disappear());
        }
    }


    private void Update()
    {
        if (atkDelay >= 0)
        {
            atkDelay -= Time.deltaTime;
        }
    }

    public void DirectionEnemy(float target, float baseobj)
    {
        if (target < baseobj)
            animator.SetFloat("Direction", -1);
        else
            animator.SetFloat("Direction", 1);
    }
    public void Attack()
    {
        if (animator.GetFloat("Direction") == -1)
        {
            if (boxpos.localPosition.x > 0)
            {
                boxpos.localPosition = new Vector2(boxpos.localPosition.x * -1, boxpos.localPosition.y);

            }

        }
        else
        {
            if (boxpos.localPosition.x < 0)
            {
                boxpos.localPosition = new Vector2(Mathf.Abs(boxpos.localPosition.x), boxpos.localPosition.y);

            }
        }

        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(boxpos.position, boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.tag == "Player")
            {

                Debug.Log(Damage);
            }
        }


    }

    private IEnumerator Disappear()
    {
        //animator.SetTrigger("Die"); // "Die" �ִϸ��̼� ��� die�ִϸ��̼� �̼���
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length); // �ִϸ��̼� ���̸�ŭ ���
        Destroy(gameObject, disappearTime); // ���� �ð� �Ŀ� ���� ������Ʈ ����
    }


}
