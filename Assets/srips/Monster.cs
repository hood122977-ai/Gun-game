using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리를 위해 추가

public class Monster : MonoBehaviour
{
    public float health = 2000f; // 몬스터의 최대 체력
    private bool isDead = false; // 몬스터가 죽었는지 여부
    public string dieSceneName = "End Scene"; // 이동할 씬 이름

    void Update()
    {
        // 체력이 0 이하일 경우 몬스터를 죽임
        if (health <= 0 && !isDead)
        {
            Die(); // 몬스터 죽음 처리
        }
    }

    // 총알이 몬스터에 맞았을 때 호출되는 함수
    public void TakeDamage(float damage)
    {
        if (isDead) return; // 몬스터가 이미 죽었으면 피해를 받지 않음

        health -= damage; // 피해를 받음
        Debug.Log("몬스터 체력: " + health);
    }

    // 몬스터가 죽었을 때 호출되는 함수
    private void Die()
    {
        isDead = true;
        Debug.Log("몬스터가 죽었습니다!");

        // 씬 전환
        SceneManager.LoadScene(dieSceneName);
    }
}
