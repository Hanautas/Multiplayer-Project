﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI")]
    public GameObject loadingScreen;

    [Header("Scene Management")]
    [SerializeField] private string currentSceneName;
    [SerializeField] private string startSceneName;

    private AsyncOperation currentScene;
    private List<AsyncOperation> scenesLoading = new List<AsyncOperation>();

    void Awake()
    {
        instance = this;

        LoadStartScene();
    }

    private void LoadStartScene()
    {
        loadingScreen.SetActive(true);

        scenesLoading.Add(SceneManager.LoadSceneAsync(startSceneName, LoadSceneMode.Additive));

        currentSceneName = startSceneName;

        StartCoroutine(GetSceneLoadProgress());
    }

    public void LoadScene(string sceneName)
    {
        loadingScreen.SetActive(true);

        currentScene = SceneManager.UnloadSceneAsync(currentSceneName);

        scenesLoading.Add(currentScene);
        scenesLoading.Add(SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive));

        currentSceneName = sceneName;

        StartCoroutine(GetSceneLoadProgress());
    }
/*
    public void ReloadScene()
    {
        loadingScreen.SetActive(true);

        currentScene = SceneManager.UnloadSceneAsync(currentSceneName);

        scenesLoading.Add(currentScene);
        scenesLoading.Add(SceneManager.LoadSceneAsync(currentSceneName, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadProgress());
    }
*/
    private IEnumerator GetSceneLoadProgress()
    {
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                yield return null;
            }
        }

        loadingScreen.SetActive(false);
    }

    public void LoadSceneAdditive(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

    public void UnloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }
}