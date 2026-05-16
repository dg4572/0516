using UnityEngine;
using TMPro; //텍스트 메쉬 프로
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //게임오버 시 활성화 될 텍스트 게임 오브젝트 변수 만들기 변수 이름은 gameOverText;
    public GameObject gameOverText;

    //생존 시간을 표시할 tmp컴포넌트
    public TextMeshProUGUI timeText;
    
    //최고 기록을 표시
    public TextMeshProUGUI recordText;

    //생존 시간
    float surviveTime;

    //게임오버 상태
    bool isGameOver;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //생존 시간과 게임오버 상태를 초기화
        surviveTime = 0f;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver)
        {
            //생존 시간 갱신
            surviveTime += Time.deltaTime;

            //갱신한 생존 시간을 text컴포넌트에 표시
            timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    //현재 게임을 게임 오버 상태로 변경하는 메서드
    public void EndGame()
    {
        isGameOver = true;

        //게임오버 텍스트를 활성화
        gameOverText.SetActive(true);

        //BestTime키로 지정된 이전까지의 최고 기록 가져오기
        //PlayerPrefs => 유니티에서 제공하는 간단 저장 시스템
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //이전 기록보다 현재 기록이 더 크다면
        if(surviveTime > bestTime)
        {
            bestTime = surviveTime; //값 갱신

            //변경된 최고 기록을 BestTime키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        //최고 기록을 표시
        recordText.text = "Best Time : " + (int)bestTime;
    }
}
