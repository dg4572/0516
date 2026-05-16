using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    //생성된 탄알의 원본 프리팹 bulletPrefab변수 만들기
    public GameObject bulletPrefab;
    //최초 생성 주기
    public float spawnRate = 0.5f;
    //최대 생성 주기
    public float spawnRateMax = 3f;

    Transform target; //발사할 대상
    float spawnRateStart; //생성 주기
    float timeAfterSpawn; //최근 생성 시점에서 지난 시간
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //최근 생성 이후에 누적 시간을 0으로 초기화
        timeAfterSpawn = 0f;

        //탄알 생성 간격 정하기
        spawnRateStart = Random.Range(spawnRate, spawnRateMax);

        //PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정
        target = FindFirstObjectByType<PlayerController>().transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        //시간을 갱신 시켜야 되기 때문에
        timeAfterSpawn += Time.deltaTime;

        //최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        if(timeAfterSpawn >= spawnRateStart )
        {
            //누적된 시간을 리셋
            timeAfterSpawn = 0f;

            //bulletprefab의 복제본을 만들고
            //transform.position 위치와 transform.rotation 회전으로 생성
            //변수명은 bullet이다.

            //Instantiate(프리팹 원본, p, r)
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            //생성된 bullet게임오브젝트의 정면 방향이 target을 향하도록 회전
            bullet.transform.LookAt(target);

            //다음 생성 간격을 spawn 최소시간~최대시간 사이의 랜덤 지정
            spawnRateStart = Random.Range(spawnRate, spawnRateMax);
        }
    }
}
