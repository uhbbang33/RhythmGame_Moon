using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadFile : MonoBehaviour
{
    [SerializeField] TextAsset txt;
    [SerializeField] int lineNum;
    [SerializeField] List<Transform> noteAppearLocation;
    [SerializeField] GameObject notePrefab;
    [SerializeField] GameObject noteParent;

    string txtToString;
    string oneLine;

    void Start()
    {
        txtToString = txt.ToString();
        InvokeRepeating("readOneLine", 0, 10f * Time.deltaTime);
    }

    void readOneLine()
    {
        int i = 0;
        while (i < lineNum)
        {
            oneLine += txtToString[i];
            ++i;
        }
        // 2는 문자열 뒤의 공백과 \n을 제거하기 위한 숫자
        txtToString = txtToString.Remove(0, lineNum + 2);

        CreateNote();

        Debug.Log(oneLine);
        oneLine = "";
    }

    void CreateNote()
    {
        for (int i = 0; i < oneLine.Length; ++i)
        {
            if (oneLine[i] == '1')
            {
                GameObject note = Instantiate(notePrefab, noteAppearLocation[i].position, Quaternion.identity);
                note.transform.SetParent(noteParent.transform);
            }
        }
    }

}
