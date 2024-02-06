using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneloader : MonoBehaviour
{
    // Method to load a scene asynchronously by name
    public void LoadScene(string sceneName)
    {
        // Use SceneManager to load the scene asynchronously by name
        SceneManager.LoadSceneAsync(sceneName);
    }

    // Method to load a scene asynchronously by build index
    public void LoadScene(int buildIndex)
    {
        // Use SceneManager to load the scene asynchronously by build index
        SceneManager.LoadSceneAsync(buildIndex);
    }
}