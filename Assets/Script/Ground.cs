using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

  public float offset = 4.75f;
  public Vector3 initPoistion;
  // Start is called before the first frame update

  void Awake()
  {
    initPoistion = transform.position;
  }
  void Start()
  {

  }

  // Update is called once per frame
  void FixedUpdate()
  {

    transform.position += new Vector3(-GameManager.Instance.moveSpeed, 0);
    if (transform.position.x <= offset)
      transform.position = initPoistion;
  }
}
