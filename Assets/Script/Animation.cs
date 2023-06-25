using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Animation : MonoBehaviour
{
	public float countTime;
  Coroutine scoring;

  // Start is called before the first frame update
  public void Scoring()
  {
    scoring = StartCoroutine(score());
  }
  IEnumerator score()
  {
    float tempTime = 0f;
		GameManager.Instance.isCounting = true;
    while(tempTime < countTime){
      UIManager.Instance.scoreInfoTextUI.text
        = ((int)Mathf.Lerp(0, GameManager.Instance.score, tempTime / countTime)).ToString();
      tempTime += Time.deltaTime;
      yield return null;
    }
		UIManager.Instance.scoreInfoTextUI.text = $"{(int)GameManager.Instance.score}";
		GameManager.Instance.isCounting = false;
    UIManager.Instance.okButton.SetActive(true);
    //베스트 스코어라면
    if(GameManager.Instance.score > PlayerPrefs.GetInt("score")){
      UIManager.Instance.bestScoreInfoTestUI.text = GameManager.Instance.score.ToString();
      PlayerPrefs.SetInt("score",GameManager.Instance.score);
      UIManager.Instance.newImage.SetActive(true);
    }
  }
}
