using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] GameObject notePrefab;
    [SerializeField] List<GameObject> noteAppearLocation;
    
    TimingManager timingManager;

    public int bpm = 0;
    double currentTime = 0d;
    char generateNoteNum = '1';
    
    //[SerializeField] Transform tfNoteAppear = null;
    //[SerializeField] GameObject goNote = null;

    private void Start()
    {
        timingManager = GetComponent<TimingManager>();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        
        if(currentTime >= 60d / bpm)
        {
            //GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);
            //t_note.transform.SetParent(this.transform);
            //timingManager.boxNoteList.Add(t_note); //
            //currentTime -= 60d / bpm;
        }
    }

    public void CreateNote(string oneLine)
    {
        for (int i = 0; i < oneLine.Length; ++i)
        {
            if (oneLine[i] == generateNoteNum)
            {
                GameObject note = Instantiate(notePrefab, noteAppearLocation[i].transform.position, Quaternion.identity);
                note.transform.SetParent(noteAppearLocation[i].transform);
                note.GetComponent<Note>().noteLineNum = i;

                timingManager.boxNoteList[i].Add(note);
            }
        }
    }
}
