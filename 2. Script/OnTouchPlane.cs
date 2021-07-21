using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class OnTouchPlane : MonoBehaviour
{
    public ARRaycastManager RM; //AR���� ����
    public GameObject CubePrefab; //ť��������
    List<ARRaycastHit> hits = new List<ARRaycastHit>(); //������ �浹�� ��ü�� �־��

    //public bool isLife = false;

    public int isLife;

    GameObject temp;
    public GameObject snowman2;


    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject(0)) return;
        //Ui�� ù��°��ġ (0) ���� �� �������� �ʴ´�.

        if (Input.touchCount > 0) //��ġ�� �ϳ� �̻��̶��
        {
            Touch touch = Input.GetTouch(0); //ù��° ��ġ ���� ����
            if (touch.phase == TouchPhase.Began) //ù ��ġ �϶�
            {
                if (isLife == 1 ) //����
                {
                    //�� ������ Ʈ��ŷŸ�� ���� ��ȣ
                    if (RM.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                    {
                        //������ �÷��� �ε����ٸ� �װ��� ť�� �����ϰٴٴ� �ڵ�
                        Pose hitPose = hits[0].pose; //�ε��� ���� ������������ �޾ƿ�

                        temp = Instantiate(CubePrefab, hitPose.position, hitPose.rotation);
                        //����      (������      ,         ��ġ     ,           ȸ��    )
                        //�Ÿ� : hitPose.distance
                        //Ʈ��ĿŸ�� : hitPose.hitType

                    }
  

                }

                if (isLife == 3)
                {
                    Instantiate(snowman2, temp.transform.position + new Vector3(0, 0.5f, 0),transform.rotation);
                }

                else if (isLife == 2 ) //�ı�
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);//������ ����
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))//������ ���
                    {
                        Destroy(hit.transform.gameObject);
                        //����
                        //�Ҹ���
                        //�ִϸ��̼�
                        //= ��ȣ�ۿ�
                    }
                }

            }

            if (touch.phase == TouchPhase.Moved)
            {
                //�� ������ Ʈ��ŷŸ�� ���� ��ȣ
                if (RM.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose; //�ε��� ���� ������������ �޾ƿ�

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
