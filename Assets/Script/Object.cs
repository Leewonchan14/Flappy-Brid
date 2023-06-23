using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
  public Transform goal;
  public float maxY;
  public float minY;
  public float maxLeft;
  public LayerMask player;
  // Start is called before the first frame update
  void Start()
  {
    transform.position = new Vector3(transform.position.x,
      Random.Range(minY, maxY), transform.position.z);
  }
  private void Update()
  {

  }
  // Update is called once per frame
  void FixedUpdate()
  {
    transform.position += new Vector3(-GameManager.Instance.moveSpeed, 0);
    if (transform.position.x <= maxLeft)
      Destroy(gameObject);
  }
}
