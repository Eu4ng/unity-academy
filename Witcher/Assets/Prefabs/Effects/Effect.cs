using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] Sprite m_Sprite;
    [SerializeField] AnimationClip m_AnimationClip;
    Animator m_Animator;
    int m_AnimationCount = 1;

    private void Awake()
    {
        // Sprite Renderer 초기화
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = m_Sprite;

        // Animator 초기화
        m_Animator = GetComponent<Animator>();

        SetEffectAnimation();
        AddAnimationEndEvent();
    }

    void SetEffectAnimation()
    {
        AnimatorOverrideController aoc = new AnimatorOverrideController(m_Animator.runtimeAnimatorController);
        var anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();
        if(aoc.animationClips.Length == m_AnimationCount)
        {
            anims.Add(new KeyValuePair<AnimationClip, AnimationClip>(aoc.animationClips[0], m_AnimationClip));
        }
        aoc.ApplyOverrides(anims);
        m_Animator.runtimeAnimatorController = aoc;
    }

    void AddAnimationEndEvent()
    {
        int layerIndex = 0;
        AnimatorClipInfo[] animatorClipInfos = m_Animator.GetCurrentAnimatorClipInfo(layerIndex);
        if (animatorClipInfos.Length == m_AnimationCount)
        {
            AnimationClip clip = animatorClipInfos[0].clip;
            AnimationEvent endEvent = new AnimationEvent();
            endEvent.time = clip.length;
            endEvent.functionName = "DestroyEffect";

            clip.AddEvent(endEvent);
        }
    }

    void DestroyEffect()
    {
        Destroy(gameObject);
    }
}
