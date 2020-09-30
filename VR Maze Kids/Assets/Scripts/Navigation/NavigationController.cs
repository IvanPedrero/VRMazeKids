using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationController : MonoBehaviour
{
    public static NavigationController instance;

    public GameObject navigatorPrefab;

    // Execute before start
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void CreateMenu()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        Vector3 v = p.GetComponent<CameraRayCastController>().navigatorPosition.position;
        var nav = Instantiate(navigatorPrefab);
        nav.transform.position = new Vector3(v.x, v.y, v.z);
    }

    public void GoToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
