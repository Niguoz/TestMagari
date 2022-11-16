using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SimpleCube : MonoBehaviour
{
    public UnityEvent _action;
    public bool _nearcomplexCube = false;

    [SerializeField]
    private LayerMask _layer;
    [SerializeField]
    private float _distance;
    [SerializeField]
    private Material _possibleChangeMat;


    public void Changetile()
    {
        UIManager.Instance.ChangeTile(this.gameObject);
    }

    public void Start()
    {
        CheckUp();

    }

    private void OnMouseDown()
    {
        if (_nearcomplexCube)
        {
            _action.Invoke();
            GridManager.Instance.Check();
        }
    }

    public void ChangeBool()
    {
        _nearcomplexCube = true;
        if (this.gameObject.name == "SimpleCube")
        {
            this.gameObject.GetComponent<MeshRenderer>().material = _possibleChangeMat;
        }
        Debug.Log("Cambiato bool");
    }

    private void CheckLeft()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, _distance, _layer))
        {
            if (hit.collider.tag == "ComplexCube")
            {
                ChangeBool();
            }
            else
            {
                CheckDown();
            }
        }
        else
        {
            CheckDown();
        }
    }

    private void CheckUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, _distance, _layer))
        {
            if (hit.collider.tag == "ComplexCube")
            {
                ChangeBool();
            }
            else
            {
                CheckLeft();
            }

        }
        else
        {
            CheckLeft();
        }
    }

    private void CheckDown()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, _distance, _layer))
        {
            if (hit.collider.tag == "ComplexCube")
            {
                ChangeBool();
            }
            else
            {
                CheckRight();
            }
        }
        else
        {
            CheckRight();
        }
    }

    private void CheckRight()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, _distance, _layer))
        {
            if (hit.collider.tag == "ComplexCube")
            {
                ChangeBool();
            }
        }
    }

}