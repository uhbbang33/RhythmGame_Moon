using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadFile : MonoBehaviour
{
    [SerializeField] TextAsset txtFile;
    [SerializeField] int lineNum;
    [SerializeField] TimingManager timingManager;

    NoteManager noteManager;

    string txtToString;
    string oneLine;


    void Start()
    {
        noteManager = GameObject.Find("Note").GetComponent<NoteManager>();

        txtToString = txtFile.ToString();
        InvokeRepeating("readOneLine", 0, 10f * Time.deltaTime);    // юс╫ц
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

        noteManager.CreateNote(oneLine);

        oneLine = "";

        if (txtToString.Length <= 2)
            CancelInvoke();
        else
            txtToString = txtToString.Remove(0, 2); // remove \n, NULL
    }
}
