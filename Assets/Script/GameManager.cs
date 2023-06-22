using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	public float moveSpeed;
	public float jumpPower;
  // 게임 매니저에 대한 접근을 제공하는 프로퍼티
	public static GameManager Instance
	{
		get { return instance; }
	}
	private void Awake() {
    if (instance != null)
    {
      Destroy(gameObject);
      return;
    }

    // 인스턴스가 존재하지 않는 경우, 현재 인스턴스를 할당
    instance = this;

    // 게임 매니저 오브젝트를 파괴하지 않고 유지
    DontDestroyOnLoad(gameObject);
	}
}
