using MagariProject.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MagariProject.Game
{
    public class EndCube : ComplexCube
    {
        /// <summary>
        /// Set the owner of the cube and call the End Screen
        /// </summary>
        public override void SetOwner(GameObject owner)
        {
            base.SetOwner(owner);

            if (_owner != null)
            {
                DataManager.Instance.WinnerName = _owner.name;
                SceneManager.LoadScene("EndScene");
            }
        }
    }
}