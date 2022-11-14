using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleCube : MonoBehaviour
{
    public UnityEvent _action;

    private void OnMouseDown()
    {
        _action.Invoke();
    }

    public void SetMaterial(MeshRenderer mesh)
    {
        mesh.material = UIManager.Instance.ChooseMaterial;
    }
}
