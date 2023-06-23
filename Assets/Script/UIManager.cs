using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

  public GameObject Tuto;
  public GameObject startButton;
  public GameObject restart;
  public GameObject fadeIn;
  public Animator canvasAnim;
  // Start is called before the first frame update
  void Start()
  {
    GameManager.Instance.UISet(this);
  }

  // Update is called once per frame
  void Update()
  {

  }
  public void ButtonStart()
  {
    GameManager.Instance.isFirst = true;
  }
  public void ButtonReStart()
  {
    GameManager.Instance.Restart();
  }
  IEnumerator FadeIn(){
    yield return new WaitForSeconds(1);
    fadeIn.SetActive(false);
  }
}
