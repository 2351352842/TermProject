using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    InputField name;
    Button loginButton;
    
    // Start is called before the first frame update
    void Start()
    {
        name = GetComponent<InputField>();
        loginButton = GameObject.Find("loginButton").GetComponent<Button>();
        loginButton.onClick.AddListener(login);

    }

    // Update is called once per frame
    public void login()
    {
        string path = Application.dataPath + "/Resources/name.txt";
        byte[] data =Encoding.UTF8.GetBytes(name.text);
        File.WriteAllBytes(path, data);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    void Update()
    {
        
    }
}
