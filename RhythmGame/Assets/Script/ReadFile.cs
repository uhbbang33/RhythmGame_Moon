using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadFile : MonoBehaviour
{
    [SerializeField] TextAsset txtFile;
    [SerializeField] int lineNum;
    [SerializeField] List<Transform> noteAppearLocation;
    [SerializeField] GameObject notePrefab;
    [SerializeField] GameObject noteParent;

    string txtToString;
    string oneLine;

    char generateNoteNum = '1';

    void Start()
    {
        txtToString = txtFile.ToString();
        InvokeRepeating("readOneLine", 0, 10f * Time.deltaTime);    // �ӽ�
    }

    void readOneLine()
    {
        int i = 0;
        while (i < lineNum)
        {
            oneLine += txtToString[i];
            ++i;
        }
        txtToString = txtToString.Remove(0, lineNum);

        CreateNote();
        oneLine = "";

        if (txtToString.Length <= 2)
            CancelInvoke();
        else
            txtToString = txtToString.Remove(0, 2);
    }

    void CreateNote()
    {
        for (int i = 0; i < oneLine.Length; ++i)
        {
            if (oneLine[i] == generateNoteNum)
            {
                GameObject note = Instantiate(notePrefab, noteAppearLocation[i].position, Quaternion.identity);
                note.transform.SetParent(noteParent.transform);
            }
        }
    }

}
