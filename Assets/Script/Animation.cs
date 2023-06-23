using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Animation : MonoBehaviour
{
	public float countSpeed;
	public float countTime;
	public TextMeshProUGUI scoreText;
	public GameObject okImage;
  Coroutine scoring;
	float currentScore = 0;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
  public void Scoring()
  {
    scoring = StartCoroutine(score());
  }
  IEnumerator score()
  {
		GameManager.Instance.isCounting = true;
		while(currentScore < GameManager.Instance.score){
			currentScore += 1;
			yield return new WaitForSeconds(countTime);
			scoreText.text = $"{(int)currentScore}";
		}
		scoreText.text = $"{(int)GameManager.Instance.score}";
		okImage.SetActive(true);
		GameManager.Instance.isCounting = false;
  }
}
