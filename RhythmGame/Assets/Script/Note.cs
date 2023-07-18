using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float noteSpeed;

    UnityEngine.UI.Image noteImage;

    private void Start()
    {
        noteSpeed = 400;
        noteImage = GetComponent<UnityEngine.UI.Image>();
    }

    void Update()
    {
        transform.localPosition += Vector3.down * noteSpeed * Time.deltaTime;
    }

    public void HideNote()
    {
        noteImage.enabled = false;
    }

    public bool GetNoteFlag()
    {
        return noteImage.enabled;
    }

}
