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
            //1��ŉ��̐������邩�ɂ���ĕς���
            for(int i = 0;i<5;i++)
            {
                float x = Random.Range(other.transform.position.x + 10,other.transform.position.x + 15);
                float y = Random.Range(-0.4f,-1.2f);
                // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
                Instantiate(createEnemy, new Vector2(x,y), Quaternion.identity);
            }
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("BossFlg"))
        {
            float x = Random.Range(other.transform.position.x + 10,other.transform.position.x + 15);
            float y = Random.Range(-0.4f,-1.2f);
            // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
            Instantiate(createBoss, new Vector2(x,y), Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
