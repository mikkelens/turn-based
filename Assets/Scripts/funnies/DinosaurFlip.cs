using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class DinosaurFlip : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    [ReadOnly] private bool _flipping;
    
    
    public void ToggleFlipping()
    {
        _flipping = !_flipping;
        animator.SetBool("FLIP", _flipping);
    }

    public void SetSpeed(Slider slider)
    {
        animator.speed = slider.value;
    }
}
