using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int health = 100;  // 플레이어의 체력

    // 충돌이 발생하면 호출되는 함수
    private void OnCollisionEnter(Collision collision)
    {
        // 몬스터와 충돌했을 때
        if (collision.gameObject.CompareTag("Monster"))
        {
            Die();  // 즉시 사망 처리
        }
    }

    // 플레이어가 죽는 함수
    void Die()
    {
        // 사망 처리 메시지 출력 (디버그용)
        Debug.Log("플레이어가 사망했습니다!");

        // 사망 시, 사망 애니메이션이나 효과 등을 추가할 수 있습니다.

        // 예시로 사망 후 2초 뒤에 다음 씬으로 전환
        Invoke("LoadNextScene", 1f);  // 2초 후 LoadNextScene() 호출
    }

    // 다음 씬으로 전환하는 함수
    void LoadNextScene()
    {
        // 현재 씬의 번호를 가져옴
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // 다음 씬으로 넘어가려면, 현재 씬 번호 + 1을 사용
        // 현재 씬이 마지막 씬이라면 첫 번째 씬으로 돌아가게 설정할 수도 있습니다.
        int nextSceneIndex = currentSceneIndex + 1;

        // 씬이 마지막 씬을 넘지 않도록 처리
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;  // 첫 번째 씬으로 돌아가도록 설정 (원하는 대로 변경 가능)
        }

        // 씬 전환
        SceneManager.LoadScene("Die Secene");
    }
}
