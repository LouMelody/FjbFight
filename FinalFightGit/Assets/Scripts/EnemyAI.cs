using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyAI : MonoBehaviour
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
    private bool drawable = true;
    private float ellapsed = 0f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        Coroutine walkRoutine = null;
        switch(enemyState)
        { 
            case EnemyState.Wait:
                Debug.Log("wait");
                break;
            case EnemyState.Walk:
                StartCoroutine(nameof(RandomWalk));
                Debug.Log("walk");
                break;
            case EnemyState.Chase:
                Vector3 newPos = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
                rb.MovePosition(newPos);
                Debug.Log("chase");
                break;
            case EnemyState.Attack:
                int randValue = Random.Range(0, 3);
                switch(randValue)
                {
                    case 0:
                        animCon.PlayBodyBlow();
                        break;
                    case 1:
                        animCon.PlayPunch();
                        break;
                    case 2:
                        animCon.PlayUpper();
                        break;
                }
                break;
        }
        animCon.ChangeDirection(rb.velocity.magnitude);
        //StartCoroutine(nameof(AITimer));
        drawable = false;
        if(walkRoutine != null)
            StopCoroutine(walkRoutine);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Low")
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
    IEnumerator AITimer()
    {
        //coroutineRunning = true;
        yield return new WaitForSeconds(4f);
        //coroutineRunning = false;
    }
    IEnumerator RandomWalk()
    {
        int randValue = Random.Range(0, 4);
        switch(randValue)
        {
            case 0:
                moveCon.EnemyMove(1, 0);  // âE
                break;
            case 1:
                moveCon.EnemyMove(-1, 0); // ç∂
                break;
            case 2:
                moveCon.EnemyMove(0, 1);  // è„
                break;
            case 3:
                moveCon.EnemyMove(0, -1);  //  â∫
                break;
        }
        yield return null;
    }
}
