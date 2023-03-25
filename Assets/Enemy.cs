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
        //animator.SetTrigger("Die"); // "Die" 애니메이션 재생 die애니메이션 미설정
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length); // 애니메이션 길이만큼 대기
        Destroy(gameObject, disappearTime); // 일정 시간 후에 몬스터 오브젝트 제거
    }


}
