using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public PlayerHPBar hpBar;
    public AnimConIshi animCon;
    public Transform playerTransform;
    public IsometricPlayerMovementController moveCon;
    [SerializeField]
    private float speed;
    private int lifeCount = 3;
    private enum EnemyState
    {
        Wait,
        Walk,
        Chase,
        Attack,
    }
    private EnemyState enemyState = EnemyState.Wait;
    private Coroutine walkRoutine;
    private bool drawable = true;
    private float ellapsed = 0f;
    private float walkTimer = 0f;
    private (int x, int y) enemyInput = (0 , 0);
    private int randValue;
    private Rigidbody2D rb;
    private Collider2D playerHurtBox;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("Player").transform;
        hpBar = GameObject.Find("Player").GetComponent<PlayerHPBar>();
        playerHurtBox = GameObject.Find("Player").transform.GetChild(0).GetComponent<Collider2D>();
        randValue = Random.Range(0, 3);
    }
    private void Update()
    {
        ellapsed += Time.deltaTime;
        if (ellapsed >= 4f)
        {
            drawable = true;
            ellapsed = 0f;
        }

        if (!drawable) return;

        enemyState = MainRoutine();

        switch (enemyState)
        {
            case EnemyState.Wait:
                StopAllCoroutines();
                Debug.Log("wait");
                break;
            case EnemyState.Attack:
                StopAllCoroutines();
                StartCoroutine(nameof(AttackCoroutine));
                break;
        }

        drawable = false;
    }

    private void FixedUpdate()
    {
        switch (enemyState)
        {
            case EnemyState.Walk:
                StopAllCoroutines();
                walkTimer += Time.fixedDeltaTime;
                if(walkTimer >= 3f)
                {
                    walkTimer = 0f;
                    enemyInput = (Random.Range(-1, 2), Random.Range(-1, 2));
                }
                moveCon.EnemyMove(enemyInput.x, enemyInput.y);
                Debug.Log("walk");
                break;
            case EnemyState.Chase:
                StopAllCoroutines();
                Vector3 newPos = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
                rb.MovePosition(newPos);
                Debug.Log("chase");
                break;
        }
        animCon.ChangeDirection(rb.velocity.magnitude);
    }

    // inner
    EnemyState MainRoutine()
    {
        int rand = Random.Range(0, 4);
        return rand switch
        {
            0 => EnemyState.Wait,
            1 => EnemyState.Walk,
            2 => EnemyState.Chase,
            3 => EnemyState.Attack,
        };
    }
    IEnumerator RandomWalk()
    {
        while(true)
        {
            int randValue = Random.Range(0, 4);
            switch (randValue)
            {
                case 0:
                    for(int i = 0; i < 5; i++)
                        moveCon.EnemyMove(1, 0);  // ‰E
                    yield return new WaitForSeconds(0.3f);
                    break;
                case 1:
                    for (int i = 0; i < 5; i++)
                        moveCon.EnemyMove(-1, 0); // ¶
                    yield return new WaitForSeconds(0.3f);
                    break;
                case 2:
                    for (int i = 0; i < 5; i++)
                        moveCon.EnemyMove(0, 1);  // ã
                    yield return new WaitForSeconds(0.3f);
                    break;
                case 3:
                    for (int i = 0; i < 5; i++)
                        moveCon.EnemyMove(0, -1);  //  ‰º
                    yield return new WaitForSeconds(0.3f);
                    break;
            }
        }
    }

    IEnumerator AttackCoroutine()
    {
        while(true)
        {
            switch (randValue)
            {
                case 0:
                    animCon.PlayPunch();
                    yield return LowHit();
                    yield return new WaitForSeconds(0.5f);
                    break;
                case 1:
                    animCon.PlayBodyBlow();
                    yield return MiddleHit();
                    yield return new WaitForSeconds(0.5f);
                    break;
                case 2:
                    animCon.PlayUpper();
                    yield return HighHit();
                    yield return new WaitForSeconds(0.5f);
                    break;
            }
        }
    }

    private IEnumerator DelayMethod(float waitTime, System.Action<Collider2D> action, Collider2D col)
    {
        yield return new WaitForSeconds(waitTime);
        action(col);
    }

    public Collider2D low;
    public Collider2D middle;
    public Collider2D high;
    private IEnumerator LowHit()
    {
        yield return StartCoroutine(DelayMethod(0.1f, low => low.enabled = true, low));
        if (middle.IsTouching(playerHurtBox))
            hpBar.TakeDamage(50);
        StartCoroutine(DelayMethod(0.3f, low => low.enabled = false, low));
    }
    private IEnumerator MiddleHit()
    {
        yield return StartCoroutine(DelayMethod(0.3f, mid => mid.enabled = true, middle));
        if (middle.IsTouching(playerHurtBox))
            hpBar.TakeDamage(50);
        StartCoroutine(DelayMethod(0.3f, mid => mid.enabled = false, middle));
    }
    private IEnumerator HighHit()
    {
        yield return StartCoroutine(DelayMethod(0.5f, high => high.enabled = true, high));
        if (middle.IsTouching(playerHurtBox))
            hpBar.TakeDamage(50);
        StartCoroutine(DelayMethod(0.3f, high => high.enabled = false, high));
    }
}
