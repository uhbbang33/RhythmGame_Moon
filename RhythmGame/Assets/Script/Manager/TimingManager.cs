using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();

    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;
    Vector2[] timingBoxs = null;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int[] scoreList;
    int score = 0;

    EffectManager effect;

    void Start()
    {
        effect = FindObjectOfType<EffectManager>();

        // Ÿ�̹� �ڽ� ����
        timingBoxs = new Vector2[timingRect.Length];

        for (int i = 0; i < timingRect.Length; ++i)
        {
            timingBoxs[i].Set(Center.localPosition.y - timingRect[i].rect.height / 2, // �ּҰ�: �߽� - (�̹����� ���� / 2)
                Center.localPosition.y + timingRect[i].rect.height / 2);    // �ִ밪: �߽� + (�̹����� ���� / 2)
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
                    // ��Ʈ ����
                    boxNoteList[i].GetComponent<Note>().HideNote();
                    boxNoteList.RemoveAt(i);

                    // ����Ʈ ����
                    if (j < timingBoxs.Length - 1)
                        effect.NoteHitEffect();
                    effect.JudgementEffect(j);

                    // score
                    score += scoreList[j];
                    scoreText.text = score.ToString();
                    return;
                }
            }
        }
    }
}
