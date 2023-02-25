using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    enum EnemyState
    {
        Wait,
        Walk,
        Chase,
        Attack,
    }
    EnemyState enemyState = EnemyState.Wait;
    bool coroutineRunning = false;
    private void Update()
    {
        enemyState = MainRoutine();
        if (coroutineRunning) return;

        switch(enemyState)
        { 
            case EnemyState.Wait:
                Debug.Log("wait");
                break;
            case EnemyState.Walk:
                Debug.Log("walk");
                break;
            case EnemyState.Chase:
                Debug.Log("chase");
                break;
            case EnemyState.Attack:
                Debug.Log("attack");
                break;
        }
        StartCoroutine(nameof(AITimer));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Low")
            Debug.Log("triggered");
    }
    // inner
    EnemyState MainRoutine()
    {
        int rand = Random.Range(0, 3);
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
        coroutineRunning = true;
        yield return new WaitForSeconds(10f);
        coroutineRunning = false;
    }
}
