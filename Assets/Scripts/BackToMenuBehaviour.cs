using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuBehaviour : MonoBehaviour
{
    public void ButtonOnPress()
    {
        SceneManager.LoadScene("Menu");
    }
}
