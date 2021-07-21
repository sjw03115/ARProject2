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

    // 클릭후 딜레이를 위한 2줄
    public void DelaySceneProject(float n)// 딜레이 초 
    {
        Invoke("LoadSceneProject", n);
    }

    public void LoadSceneGame()
    {
        SceneManager.LoadScene("Project");
    }
}
