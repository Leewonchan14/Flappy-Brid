using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
  public float upHeadZ;
  public float downHeadZ;
  public float rotateSpeed;
  float t = 0f;
  Rigidbody2D rb;
  Animator anim;
  private void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
  }
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    if(Input.GetMouseButtonDown(0)){
      if(GameManager.Instance.isFirst){
        GameManager.Instance.Play();
        OnTap();
      }
      if(GameManager.Instance.isPlay){
        OnTap();
      }
    }
    anim.SetBool("isPlay",GameManager.Instance.isPlay);
    anim.SetBool("isFirst",GameManager.Instance.isFirst);
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
}
