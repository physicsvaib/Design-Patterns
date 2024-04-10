using Phyw.DesignPatterns;
using System.Collections.Generic;
using UnityEngine;

namespace Phyw.Utils
{

  public class Raycaster : MonoBehaviour
  {
    #region Variables
    [SerializeField] private LayerMask mask;
    [SerializeField] private Camera cam;
    //[SerializeField] private BuildCommand cmd;
    [SerializeField] GameObject objToSpawn;

    Stack<BuildCommand> cmds = new Stack<BuildCommand>();
    Stack<BuildCommand> newCmds = new Stack<BuildCommand>();

    #endregion

    #region UnityMethods

    private void Update()
    {
      if (Input.GetMouseButtonDown(0))
      {
        GetRayCastPosition();
      }

      if (Input.GetMouseButtonDown(1))
      {
        cmds.Pop().UnExecute();
        print(cmds.Count);
      }

      if (Input.GetMouseButtonDown(2))
      {
        foreach (BuildCommand cmd in cmds)
        {
          cmd.SetProperties(Vector3.one * 5, Quaternion.identity);
          newCmds.Push(cmd);
          cmd.Execute();
        }
        cmds.Clear();
      }

    }

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

        BuildCommand cmd = new BuildCommand();
        cmd.building = objToSpawn;
        cmd.SetProperties(vec, Quaternion.identity);

        cmds.Push(cmd);
        cmd.Execute();



        return hit.point;
      }
      return null;
    }

    #endregion

  }
}