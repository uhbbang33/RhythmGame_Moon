using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();

    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;
    Vector2[] timingBoxs = null;

    void Start()
    {
        // 타이밍 박스 설정
        timingBoxs = new Vector2[timingRect.Length];

        for (int i = 0; i < timingRect.Length; ++i)
        {
            timingBoxs[i].Set(Center.localPosition.y - timingRect[i].rect.height / 2, // 최소값: 중심 - (이미지의 너비 / 2)
                Center.localPosition.y + timingRect[i].rect.height / 2);    // 최대값: 중심 + (이미지의 너비 / 2)
        }
    }

    public void CheckTiming()
    {
        for (int i = 0; i < boxNoteList.Count; ++i)
        {
            float notePosY = boxNoteList[i].transform.localPosition.y;
            for (int j = 0; j < timingBoxs.Length; ++j)
            {
                if (timingBoxs[j].x <= notePosY && notePosY <= timingBoxs[j].y)
                {
                    Debug.Log("Hit" + j);
                    return;
                }
            }
        }
        Debug.Log("Miss");
    }
}
