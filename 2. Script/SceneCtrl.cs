using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneCtrl : MonoBehaviour
{
    // Start is called before the first frame update
   public void NextScene(string name)
    {
      SceneManager.LoadScene(name);
    }

    // Ŭ���� �����̸� ���� 2��
    public void DelaySceneProject(float n)// ������ �� 
    {
        Invoke("LoadSceneProject", n);
    }

    public void LoadSceneGame()
    {
        SceneManager.LoadScene("Project");
    }
}
