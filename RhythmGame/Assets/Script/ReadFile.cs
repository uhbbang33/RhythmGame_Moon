using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadFile : MonoBehaviour
{
    TextAsset txt;
    string noteFileToString;

    void Start()
    {
        txt = Resources.Load<TextAsset>("Text.txt");
        noteFileToString = ReadText("text.txt");
        Debug.Log(noteFileToString);
    }
    
    void Update()
    {
        
    }

    string ReadText(string filePath)
    {
        FileInfo fileInfo = new FileInfo(filePath);
        string value = "";

        if (fileInfo.Exists) // 파일 존재 여부
        {
            StreamReader reader = new StreamReader(filePath);
            value = reader.ReadToEnd();
            reader.Close();
        }
        else
            value = "파일이 없습니다.";


        return value;
    }
}
