using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] Animator noteHitAnimator;
    string hit;

    [SerializeField] Animator judgementAnimator;
    [SerializeField] UnityEngine.UI.Image judgementImage;
    [SerializeField] Sprite[] judgementSprite;

    public void NoteHitEffect()
    {
        noteHitAnimator.SetTrigger(hit);
    }

    public void JudgementEffect(int num)
    {
        judgementImage.sprite = judgementSprite[num];
        judgementAnimator.SetTrigger(hit);
    }

    // Start is called before the first frame update
    void Start()
    {
        hit = "Hit";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
