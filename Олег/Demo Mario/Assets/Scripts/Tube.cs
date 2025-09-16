using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tube : MonoBehaviour
{
    public float startPointX;
    public float startPointY;

    public int idxOfScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.instance.isFromTube = true;
            GameManager.instance.LoadFromTube(idxOfScene, startPointX, startPointY);
        }
    }
}
