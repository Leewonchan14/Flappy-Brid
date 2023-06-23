using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	GameObject Tuto;
	GameObject restart;
	GameObject startButton;
	Animator canvasAnim;
	public GameObject Object;
	public Transform spawnPoint;
	public float objectInterver;
	public bool isFirst = false;
	Coroutine spawn;
	public float moveSpeed;
	float initialMoveSpeed;
	public float jumpPower;
	public bool isPlay = true;
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
	}
	void Update() {
    canvasAnim.SetBool("isPlay", isPlay);
	}
	IEnumerator Spawn(){
		while(true){
			Instantiate(Object, spawnPoint.position, Quaternion.identity);
			yield return new WaitForSeconds(objectInterver);
		}
	}
	public void Play(){
		isPlay = true;
		isFirst = false;
		spawn = StartCoroutine(Spawn());
		Physics2D.gravity = Vector3.down * 9.8f;
		Tuto.SetActive(false);
	}
	public void Die(){
		isPlay = false;
		isFirst = false;
		moveSpeed = 0;
		StopCoroutine(spawn);
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Object"), true);
		restart.SetActive(true);
	}
	public void Restart(){
		Physics2D.gravity = Vector3.zero;
		moveSpeed = initialMoveSpeed;
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Object"), false);
		SceneManager.LoadScene(0);
	}
	public void UISet(UIManager uI){
		Tuto = uI.Tuto;
		restart = uI.restart;
		startButton = uI.startButton;
		canvasAnim = uI.canvasAnim;
	}
}
