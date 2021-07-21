using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class OnTouchplane2B : MonoBehaviour
{
    public ARRaycastManager RM; //AR전용 광선
    public GameObject PL; //큐브프리팹
    public GameObject butten;
    List<ARRaycastHit> hits = new List<ARRaycastHit>(); //광선에 충돌된 물체를 넣어둠

    // Update is called once per frame

    public void Snowing()
    {

        if (EventSystem.current.IsPointerOverGameObject(0)) return;
        //Ui를 첫번째터치 (0) 했을 때 동작하지 않는다.

        if (Input.touchCount > 0) //터치가 하나 이상이라면
        {
            Touch touch = Input.GetTouch(0); //첫번째 터치 정보 버장
            if (touch.phase == TouchPhase.Began) //첫 터치 일때
            {
         
                    //이 광선은 트래킹타입 에만 유호
                    if (RM.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                    {
                        //광선이 플랜에 부딛혔다면 그곳에 큐브 생성하겟다는 코드
                        Pose hitPose = hits[0].pose; //부딛힌 곳의 물리정보값을 받아옴

                        Instantiate(PL, hitPose.position + new Vector3(0, 2, 3), hitPose.rotation);
                        //생성      (프리팹      ,         위치     ,           회전    )
                        //거리 : hitPose.distance
                        //트래커타입 : hitPose.hitType
                    }
                }
            }
        }
    }



  
