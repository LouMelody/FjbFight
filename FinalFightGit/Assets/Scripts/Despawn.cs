using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    public bool isBoss;

    int lifeCount = 3;

    private void Start()
    {
        if(isBoss)
        {
            lifeCount = 5;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Low")
            lifeCount--;
        if (collision.gameObject.name == "Middle")
            lifeCount--;
        if (collision.gameObject.name == "High")
            lifeCount--;
        if (lifeCount <= 0)
            Destroy(gameObject);
    }
}
