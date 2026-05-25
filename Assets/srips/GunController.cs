using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;  // 총알 프리팹
    public Transform firePoint;      // 총구 위치 (총알이 나가는 지점)
    public float bulletSpeed = 20f;  // 총알 속도

    // Update는 매 프레임마다 호출됩니다.
    void Update()
    {
        // 마우스 왼쪽 버튼을 눌렀을 때
        if (Input.GetButtonDown("Fire1"))  // Fire1은 기본적으로 마우스 왼쪽 버튼입니다.
        {
            Fire();
        }
    }

    // 총을 발사하는 함수
    void Fire()
    {
        // 총알 프리팹을 총구 위치에서 생성
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // 총알의 Rigidbody를 가져와서 직선으로 힘을 줍니다.
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Rigidbody의 velocity 속성을 사용하여 총알이 직선으로 나가게 합니다.
            rb.velocity = firePoint.forward * bulletSpeed;  // firePoint의 전방 방향으로 속도 적용
        }
        else
        {
            Debug.LogError("Rigidbody가 총알 Prefab에 없습니다!");
        }
    }
}
