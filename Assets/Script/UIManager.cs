using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
  private static UIManager instance;
  public static UIManager Instance
	{
		get { return instance; }
	}
  public GameObject Tuto;
  public GameObject startUI;
  public GameObject dieUI;
  public GameObject fadeIn;
  public GameObject okButton;
  public TextMeshProUGUI scoreTextUI;
  public TextMeshProUGUI scoreInfoTextUI;
  public TextMeshProUGUI bestScoreInfoTestUI;
  public GameObject newImage;
  public Animator canvasAnim;
  public Image pauseButtonImage;
  public Sprite[] pauseSprite;
  // Start is called before the first frame update
  void Awake()
  {
    if (instance != null)
    {
      Destroy(gameObject);
      return;
    }
    // 인스턴스가 존재하지 않는 경우, 현재 인스턴스를 할당
    instance = this;

    // 게임 매니저 오브젝트를 파괴하지 않고 유지
    DontDestroyOnLoad(gameObject);

    canvasAnim = GetComponent<Animator>();
  }
  // Update is called once per frame
  void Update()
  {
    canvasAnim.SetBool("isPlay", GameManager.Instance.isPlay);
		canvasAnim.SetBool("isFirst",GameManager.Instance.isFirst);
		canvasAnim.SetBool("isCounting",GameManager.Instance.isCounting);
  }
  public void ButtonStart()
  {
    GameManager.Instance.FirstStart();
    scoreTextUI.text = "0";
    scoreInfoTextUI.text = "0";
    bestScoreInfoTestUI.text = PlayerPrefs.GetInt("score").ToString();
  }
  public void ButtonReStart()
  {
    GameManager.Instance.Restart();
    canvasAnim.SetTrigger("reStart");
    UIManager.Instance.okButton.SetActive(false);
    UIManager.Instance.newImage.SetActive(false);
  }
  public void Pause(){
    GameManager.Instance.Pause();
    pauseButtonImage.sprite = !GameManager.Instance.isStop ? pauseSprite[0] : pauseSprite[1];
  }
  public void addScore(int score){
    scoreTextUI.text = score.ToString();
  }
}
