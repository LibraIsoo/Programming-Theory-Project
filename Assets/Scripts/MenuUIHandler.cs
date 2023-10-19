using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public string userName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetUserName(string s)
    {
        userName = s;
        Debug.Log("Username is: " +  userName);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
