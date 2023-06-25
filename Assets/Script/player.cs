using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class player : MonoBehaviour
{
  public float upHeadZ;
  public float downHeadZ;
  public float rotateSpeed;
  float t = 0f;
  Rigidbody2D rb;
  Animator anim;
  int pointerID;
  private void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    if(Application.platform == RuntimePlatform.WindowsPlayer){
      pointerID = -1; //PC나 유니티 상에서는 -1
    } else if(Application.platform == RuntimePlatform.Android){
      pointerID = 0;  // 휴대폰이나 이외에서 터치 상에서는 0 
    }
  }
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.touchCount > 0 ){
      Touch touch = Input.GetTouch(0);
      if(touch.phase == TouchPhase.Began){
        if(GameManager.Instance.CanTouch
            && !GameManager.Instance.isStop
              && EventSystem.current.IsPointerOverGameObject(pointerID) == false)
        {
          if (GameManager.Instance.isFirst || GameManager.Instance.isPlay)
          {
            if (GameManager.Instance.isFirst)
              GameManager.Instance.Play();
            OnTap();
          }
        }
      }
    }
    anim.SetBool("isPlay", GameManager.Instance.isPlay);
    anim.SetBool("isFirst", GameManager.Instance.isFirst);
  }
  private void FixedUpdate()
  {
    Rotate();
  }
  void OnTap()
  {
    rb.velocity = new Vector2(rb.velocity.x, GameManager.Instance.jumpPower);
    transform.rotation = Quaternion.Euler(0, 0, upHeadZ);
    t = 0;
  }
  void Rotate()
  {
    //올라갈땐 회전 변하지 않고 내려 갈때만 회전
    if (rb.velocity.y < 0)
    {
      t += rotateSpeed * Time.deltaTime;  // 시간에 따라 회전 속도 조절
      // 회전 보간
      Quaternion newRotation = Quaternion.Lerp(Quaternion.Euler(0, 0, upHeadZ), Quaternion.Euler(0, 0, downHeadZ), t);

      // 오브젝트에 새로운 회전값 적용
      transform.rotation = newRotation;
    }
  }
  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.layer == LayerMask.NameToLayer("Object") || other.gameObject.tag == "Ground")
    {
      GameManager.Instance.Die();
    }
  }
  private void OnCollisionExit2D(Collision2D other)
  {
    if (other.gameObject.layer == LayerMask.NameToLayer("Goal"))
    {
      GameManager.Instance.addScore();
    }
  }
}
