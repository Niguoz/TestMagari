using UnityEngine;
using UnityEngine.Events;

public class SimpleCube : MonoBehaviour
{
    public UnityEvent _action;
    public bool _nearcomplexCube = false;
    [SerializeField]
    private LayerMask _layer;

    public void Changetile()
    {
        UIManager.Instance.ChangeTile(this.gameObject);
    }

    private void OnMouseDown()
    {
        if (_nearcomplexCube)
            _action.Invoke();
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1, Color.red);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1, Color.red);
    }

    public void Check()
    {
       // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);

        /*RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.left), out hit, 10))
        {
            Debug.Log(hit.collider.name + " " + this.gameObject.name);
            if (hit.collider.name != this.gameObject.name)
            {
                Debug.Log("Ciao");
                ChangeBool();
            }
        }
        else if (Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.right), out hit, 10))
        {
            Debug.Log(hit.collider.name + " " + this.gameObject.name);
            if (hit.collider.name != this.gameObject.name)
            {
                ChangeBool();
                Debug.Log("CIao1");
            }
        }
        else if (Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.forward), out hit, 10))
        {
            Debug.Log(hit.collider.name + " " + this.gameObject.name);
            if (hit.collider.name != this.gameObject.name)
            {
                Debug.Log("CIao2");
                ChangeBool(); 
            }
        }
        else if (Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.back), out hit, 10))
        {
            Debug.Log(hit.collider.name + " " + this.gameObject.name);
            if (hit.collider.name != this.gameObject.name)
            {
                ChangeBool();
                Debug.Log("MIAO");
            }
        }*/

        if(!CheckDirection(Vector3.back))
        {
            if(!CheckDirection(Vector3.forward))
            {
                if (!CheckDirection(Vector3.right))
                {
                    if (!CheckDirection(Vector3.left))
                    {
                        _nearcomplexCube = false;
                    }
                }
            }
        }

       // Debug.Log(hit.collider.name);
    }

    public void ChangeBool()
    {
        _nearcomplexCube = true;
    }


    private bool CheckDirection(Vector3 direction)
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.TransformDirection(direction), out hit, 2f, _layer))
        {
            Debug.Log(hit.collider.name + " " + this.gameObject.name + " " + direction);
            if (hit.collider.name != "SimpleCube")
            {
                Debug.Log("Ciao");
                ChangeBool();
                return true;
            }
            else
                return false;
        }
        return false;
    }
}
