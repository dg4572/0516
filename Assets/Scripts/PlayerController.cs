using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rig; //이동에 사용할 리지드바디
    public float speed = 8f; //이동 속력

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //좌우 움직임
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        //실제 이동 속도를 입력값과 이동 속력을 통해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);

        //리지드바디의 속도에 할당
        rig.linearVelocity = newVelocity;
    }

    public void Die()
    {
        //게임오브젝트 비활성화
        gameObject.SetActive(false);

        //씬에서 존재하는 게임매니저 타입의 오브젝트를 찾아서 가져오기
        GameManager gameManager = FindFirstObjectByType<GameManager>();

        gameManager.EndGame();
    }
}
