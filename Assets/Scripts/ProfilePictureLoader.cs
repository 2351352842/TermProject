using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class ProfilePictureLoader : MonoBehaviour
{
    Image ima;
    string path;
    // Start is called before the first frame update
    void Start()
    {
        path = Application.dataPath + "/Resources/name.txt";
        ima =GetComponent<Image>();
        ima.sprite = Resources.Load("images/" + Random.Range(0, 7), typeof(Sprite)) as Sprite;
        byte[] buffer = File.ReadAllBytes(path);
        string s =Encoding.UTF8.GetString(buffer);
        transform.GetChild(0).GetComponent<Text>().text=s;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
