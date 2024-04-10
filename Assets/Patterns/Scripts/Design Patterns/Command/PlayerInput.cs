using Phyw.FileSystem;
using System.Collections.Generic;
using UnityEngine;

namespace Phyw.DesignPatterns
{

  public class PlayerInput : MonoBehaviour
  {
    #region Variables

    [SerializeField] Transform player;
    [SerializeField] PlayerMover mover;
    [SerializeField] FileWrite writer;

    MoveCommand moveCommand;

    int horizontal, vertical;

    List<ICommand> cmds = new List<ICommand>();

    bool shouldStop = false;

    #endregion

    #region UnityMethods

    private void Update()
    {

      if (shouldStop) return;

      if (Input.GetMouseButtonDown(1))
      {
        shouldStop = true;
        mover.UnMakeMoves(cmds);
        return;
      }

      horizontal = (int)Input.GetAxisRaw("Horizontal");
      vertical = (int)Input.GetAxisRaw("Vertical");

      moveCommand = new MoveCommand();

      int data = (horizontal * 2) + vertical;
      moveCommand.SetVec(data);

      cmds.Add(moveCommand);
      moveCommand.Execute(player);

      string value = JsonUtility.ToJson(moveCommand);

      writer.WriteToFile(value);


    }

    #endregion

    #region CustomMethods

    #endregion
  }
}