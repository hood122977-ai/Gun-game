using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 25f; // 총알의 공격력

    // 총알이 다른 오브젝트와 충돌했을 때 호출되는 함수
    void OnCollisionEnter(Collision collision)
    {
   
        // 충돌한 오브젝트가 몬스터라면
        if (collision.gameObject.CompareTag("Monster"))
        {
            // 몬스터 스크립트를 가져와서 피해를 입힘
            Monster monster = collision.gameObject.GetComponent<Monster>();
            if (monster != null)
            {
                monster.TakeDamage(damage); // 몬스터에게 피해를 줌
            }

            // 총알은 충돌 후 삭제
            Destroy(gameObject);
        }
    }

}
