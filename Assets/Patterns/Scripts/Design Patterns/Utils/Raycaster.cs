using UnityEngine;

namespace Phyw.Utils
{

  public class Raycaster : MonoBehaviour
  {
    #region Variables
    [SerializeField] private LayerMask mask;
    [SerializeField] private Camera cam;

    #endregion

    #region CustomMethods

    public Vector3? GetRayCastPosition()
    {

      RaycastHit hit;
      if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 1000, mask))
      {
        Vector3 vec = hit.point;
        vec.x -= vec.x % 0.5f;
        vec.z -= vec.z % 0.5f;
        print($"Position {vec}");

        return hit.point;
      }
      return null;
    }

    #endregion

  }
}