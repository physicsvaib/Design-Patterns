using Phyw.DesignPatterns;
using UnityEngine;

namespace Phyw.Utils
{

  public class InputManager : MonoBehaviour
  {
    #region Variables

    [SerializeField] private Commander commander;
    [SerializeField] private Raycaster raycaster;



    private CommandStack[] stacks = new CommandStack[3];


    #endregion

    #region UnityMethods
    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.W))
      {
        commander.CreateObject(0);
      }
      else if (Input.GetKeyDown(KeyCode.S))
      {
        commander.Undo();
      }
      else if (Input.GetKeyDown(KeyCode.D))
      {
        commander.CreateObject(1);
      }
      else if (Input.GetKeyDown(KeyCode.A))
      {
        commander.CreateObject(2);
      }
      else if (Input.GetKeyDown(KeyCode.Alpha1))
      {
        stacks[0] = commander.GetCommandStack();
        commander.ClearStack();
      }
      else if (Input.GetKeyDown(KeyCode.Alpha2))
      {
        for (int i = 0; i < stacks[0].GetCount(); i++)
        {
          BuildCommand obj = (BuildCommand)stacks[0].GetAt(i);
          obj.SetOffset(commander.GetRayPos().Value);
          //obj.SetProperties(Quaternion.identity);
          stacks[0].GetAt(i).Execute();
        }
      }
    }

    #endregion


  }
}