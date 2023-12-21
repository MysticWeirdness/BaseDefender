using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Menu_Controller : MonoBehaviour
{

    // global vars
    public float wait_time;
    public int build_index;
    public bool isSplash;
    public GameObject videoplayer;


    void Start()
    {
        if (isSplash)
        {
            StartCoroutine(Wait_For_Time(wait_time));
        }
        
       
    }



    IEnumerator Wait_For_Time(float time)
    {
        yield return new WaitForSeconds(time);
        if (videoplayer != null)
        {
            Destroy(videoplayer);
        }
        SceneManager.LoadScene(build_index);

    }

    public void onClick(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void onClick(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void onClick()
    {
        Application.Quit();
    } 



}
