using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

  public GameObject Tuto;
  public GameObject startUI;
  public GameObject dieUI;
  public GameObject fadeIn;
  public GameObject score;
  public Animator canvasAnim;
  public Image pauseButtonImage;
  public Sprite[] pauseSprite;
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
    GameManager.Instance.FirstStart();
  }
  public void ButtonReStart()
  {
    GameManager.Instance.Restart();
  }
  public void Pause(){
    GameManager.Instance.Pause();
    if(!GameManager.Instance.isStop){
      pauseButtonImage.sprite = pauseSprite[0];
    }
    else{
      pauseButtonImage.sprite = pauseSprite[1];
    }
  }
  IEnumerator FadeIn(){
    yield return new WaitForSeconds(1);
    fadeIn.SetActive(false);
  }
}
