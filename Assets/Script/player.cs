using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
  Rigidbody2D rb;
	public Transform centerOfMass;
  private void Awake() {
    rb = GetComponent<Rigidbody2D>();
		rb.centerOfMass = centerOfMass.position;
  }
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      rb.velocity = new Vector2(rb.velocity.x, 0f);
      rb.AddForce(new Vector2(0,GameManager.Instance.jumpPower),ForceMode2D.Impulse);
    }
  }
}
