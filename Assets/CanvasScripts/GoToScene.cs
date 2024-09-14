using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public void goTo2DBallScene(){
        SceneManager.LoadScene("2DBallScene");
    }
    public void goTo2DCounterWeightScene(){
        SceneManager.LoadScene("2DCounterWeightScene");
    }
    public void goTo3DBallScene(){
        SceneManager.LoadScene("3DBallScene");
    }
}
