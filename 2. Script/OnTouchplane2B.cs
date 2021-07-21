using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class OnTouchplane2B : MonoBehaviour
{
    public ARRaycastManager RM; //AR���� ����
    public GameObject PL; //ť��������
    public GameObject butten;
    List<ARRaycastHit> hits = new List<ARRaycastHit>(); //������ �浹�� ��ü�� �־��

    // Update is called once per frame

    public void Snowing()
    {

        if (EventSystem.current.IsPointerOverGameObject(0)) return;
        //Ui�� ù��°��ġ (0) ���� �� �������� �ʴ´�.

        if (Input.touchCount > 0) //��ġ�� �ϳ� �̻��̶��
        {
            Touch touch = Input.GetTouch(0); //ù��° ��ġ ���� ����
            if (touch.phase == TouchPhase.Began) //ù ��ġ �϶�
            {
         
                    //�� ������ Ʈ��ŷŸ�� ���� ��ȣ
                    if (RM.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                    {
                        //������ �÷��� �ε����ٸ� �װ��� ť�� �����ϰٴٴ� �ڵ�
                        Pose hitPose = hits[0].pose; //�ε��� ���� ������������ �޾ƿ�

                        Instantiate(PL, hitPose.position + new Vector3(0, 2, 3), hitPose.rotation);
                        //����      (������      ,         ��ġ     ,           ȸ��    )
                        //�Ÿ� : hitPose.distance
                        //Ʈ��ĿŸ�� : hitPose.hitType
                    }
                }
            }
        }
    }



  
