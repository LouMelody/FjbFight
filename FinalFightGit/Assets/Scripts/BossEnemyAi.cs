using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossEnemyAi : MonoBehaviour
{
    public AnimConIshi animCon;
    public Transform playerTransform;
    public IsometricPlayerMovementController moveCon;
    [SerializeField]
    private float speed;

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
    private (int x, int y) enemyInput = (0, 0);
    private int randValue;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("Player").transform;
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
                randValue = Random.Range(0, 3);
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
                if (walkTimer >= 3f)
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Low")
            Debug.Log("triggered");
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
        while (true)
        {
            int randValue = Random.Range(0, 4);
            switch (randValue)
            {
                case 0:
                    for (int i = 0; i < 5; i++)
                        moveCon.EnemyMove(1, 0);  // ‰E
                    yield return new WaitForSeconds(0.3f);
                    break;
                case 1:
                    for (int i = 0; i < 5; i++)
                        moveCon.EnemyMove(-1, 0); // ¶
                    yield return new WaitForSeconds(0.3f);
                    break;
                case 2:
                    for (int i = 0; i < 5; i++)
                        moveCon.EnemyMove(0, 1);  // ã
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
        while (true)
        {
            switch (randValue)
            {
                case 0:
                    animCon.PlayBodyBlow();
                    yield return new WaitForSeconds(0.5f);
                    break;
                case 1:
                    animCon.PlayPunch();
                    yield return new WaitForSeconds(0.5f);
                    break;
                case 2:
                    animCon.PlayUpper();
                    yield return new WaitForSeconds(0.5f);
                    break;
            }
        }
    }
}
