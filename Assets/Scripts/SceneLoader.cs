using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad; // Name of the scene to load when this image is clicked

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
