using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private GameObject player;

    private float startPositionX;
    private float startPositionY;

    public int score = 0;

    public bool isFromTube = false;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance == this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
    }

    public void LoadFromTube(int idxOfScene, float x, float y)
    {
        startPositionX = x;
        startPositionY = y;
        SceneManager.LoadScene(idxOfScene);
    }

    public void OnSceneLoad()
    {
        if (isFromTube)
        {
            Player.instance.transform.position = new Vector3(startPositionX, startPositionY, Player.instance.transform.position.z);
        }
    }
}
