using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject createEnemy;
    public GameObject createBoss;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("EnemyFlg"))
        {
            //1回で何体生成するかによって変える
            for(int i = 0;i<5;i++)
            {
                float x = Random.Range(other.transform.position.x + 10,other.transform.position.x + 15);
                float y = Random.Range(-0.4f,-1.2f);
                // GameObjectを上記で決まったランダムな場所に生成
                Instantiate(createEnemy, new Vector2(x,y), Quaternion.identity);
            }
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("BossFlg"))
        {
            float x = Random.Range(other.transform.position.x + 10,other.transform.position.x + 15);
            float y = Random.Range(-0.4f,-1.2f);
            // GameObjectを上記で決まったランダムな場所に生成
            Instantiate(createBoss, new Vector2(x,y), Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
