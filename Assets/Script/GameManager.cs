using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	public GameObject Object;
	public Transform spawnPoint;
	public float objectInterver;
	public int MaxScore;
	public bool isFirst = false;
	Coroutine spawn;
	public float moveSpeed;
	float initialMoveSpeed;
	public float jumpPower;
	public bool isPlay = true;
	public bool isStop = false;
	public bool isCounting = false;
	public bool CanTouch;
	public int score;
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

		Physics2D.gravity = Vector3.zero;
		initialMoveSpeed = moveSpeed;
		if(MaxScore != -1){
			PlayerPrefs.SetInt("score",MaxScore);
		}
		PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score", 0));
		Application.targetFrameRate = 300;
	}
	void Update() {
    CanTouch = !UIManager.Instance.fadeIn.activeSelf;
	}
	IEnumerator Spawn(){
		while(true){
			Instantiate(Object, spawnPoint.position, Quaternion.identity);
			yield return new WaitForSeconds(objectInterver);
		}
	}
	public void FirstStart(){
		isFirst = true;
		score = 0;
	}
	public void Play(){
		isPlay = true;
		isFirst = false;
		spawn = StartCoroutine(Spawn());
		Physics2D.gravity = Vector3.down * 9.8f;
	}
	public void Pause(){
		Time.timeScale = !isStop? 0 : 1;
		CanTouch = isStop;
		isStop = !isStop;
	}
	public void Die(){
		isPlay = false;
		isFirst = false;
		moveSpeed = 0;
		StopCoroutine(spawn);
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Object"), true);
	}
	public void Restart(){
		Physics2D.gravity = Vector3.zero;
		moveSpeed = initialMoveSpeed;
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Object"), false);
		SceneManager.LoadScene(0);
	}
	public void addScore(){
		score += 1;
		UIManager.Instance.addScore(score);
	}
}
