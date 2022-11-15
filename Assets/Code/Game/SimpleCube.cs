using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleCube : MonoBehaviour
{
    public UnityEvent _action;


    public void Changetile()
    {
        UIManager.Instance.ChangeTile(this.gameObject);
    }

    private void OnMouseDown()
    {
        _action.Invoke();
    }

    
}
