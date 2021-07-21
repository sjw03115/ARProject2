using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class OnTouchPlane : MonoBehaviour
{
    public ARRaycastManager RM; //AR전용 광선
    public GameObject CubePrefab; //큐브프리팹
    List<ARRaycastHit> hits = new List<ARRaycastHit>(); //광선에 충돌된 물체를 넣어둠

    //public bool isLife = false;

    public int isLife;

    GameObject temp;
    public GameObject snowman2;


    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject(0)) return;
        //Ui를 첫번째터치 (0) 했을 때 동작하지 않는다.

        if (Input.touchCount > 0) //터치가 하나 이상이라면
        {
            Touch touch = Input.GetTouch(0); //첫번째 터치 정보 버장
            if (touch.phase == TouchPhase.Began) //첫 터치 일때
            {
                if (isLife == 1 ) //생성
                {
                    //이 광선은 트래킹타입 에만 유호
                    if (RM.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                    {
                        //광선이 플랜에 부딛혔다면 그곳에 큐브 생성하겟다는 코드
                        Pose hitPose = hits[0].pose; //부딛힌 곳의 물리정보값을 받아옴

                        temp = Instantiate(CubePrefab, hitPose.position, hitPose.rotation);
                        //생성      (프리팹      ,         위치     ,           회전    )
                        //거리 : hitPose.distance
                        //트래커타입 : hitPose.hitType

                    }
  

                }

                if (isLife == 3)
                {
                    Instantiate(snowman2, temp.transform.position + new Vector3(0, 0.5f, 0),transform.rotation);
                }

                else if (isLife == 2 ) //파괴
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);//광선을 만들어서
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))//광선을 쏜다
                    {
                        Destroy(hit.transform.gameObject);
                        //색을
                        //소리를
                        //애니메이션
                        //= 상호작용
                    }
                }

            }

            if (touch.phase == TouchPhase.Moved)
            {
                //이 광선은 트래킹타입 에만 유호
                if (RM.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose; //부딛힌 곳의 물리정보값을 받아옴

                    temp.transform.position = hitPose.position;

                }
            }
        }
    }

    public void ChangeLife(int n)
    {
        isLife = n;
    }

}
