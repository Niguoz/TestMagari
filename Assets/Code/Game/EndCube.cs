using MagariProject.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MagariProject.Game
{
    public class EndCube : ComplexCube
    {
        public override void SetOwner(GameObject owner) 
        {
            base.SetOwner(owner);

            if(_owner != null)
            {
                Debug.Log(_owner.name + " you win!!");
                Manager.Instance.SetWinner(_owner.name);
                SceneManager.LoadScene("EndScene");
            }
        }
    }
}