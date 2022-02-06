using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using DG.Tweening;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float resetPos = -30f;
    
    private int _numChildTrs;
    private float _resetTimer = 0f;
    private float _currTime = 0f;
    
    private Transform _tr;

    private void Awake()
    {
        _tr = GetComponent<Transform>();
    }

    private void Start()
    {
        _resetTimer = Mathf.Abs(resetPos) / speed;
        _numChildTrs = _tr.childCount;
        
        _tr.DOMoveX(-speed, 1f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Incremental);
    }

    private void Update()
    {
        _currTime += Time.deltaTime;
        
        if (!(_resetTimer <= _currTime)) return;
        _currTime = 0f;

        var firstChild = _tr.GetChild(0);
        var lastChild  = _tr.GetChild(_numChildTrs - 1);
            
        firstChild.position = lastChild.position + Vector3.left * resetPos;
        firstChild.SetAsLastSibling();
    }
}
