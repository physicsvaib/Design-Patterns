using Phyw.FileSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Phyw.DesignPatterns
{

  public class PlayerMover : MonoBehaviour
  {

    [SerializeField] private FileRead reader;
    [SerializeField] private Transform player;

    private void Start()
    {
      Application.targetFrameRate = 50;
      string str = reader.ReadData();
      print(str);
    }


    #region CustomMethods

    public void Move(ICommand cmd)
    {
      cmd.Execute(player);
    }

    private IEnumerator PerformMoves(List<ICommand> cmds)
    {
      foreach (ICommand cmd in cmds)
      {
        yield return new WaitForSeconds(.02f);
        cmd.Execute(player);
      }
    }


    private IEnumerator UnPerformMoves(List<ICommand> cmds)
    {

      foreach (ICommand cmd in cmds)
      {
        yield return new WaitForSeconds(.02f);
        cmd.UnExecute(player);
      }

    }

    public void MakeMoves(List<ICommand> cmds)
    {
      StartCoroutine(PerformMoves(cmds));
    }

    public void UnMakeMoves(List<ICommand> cmds)
    {
      StartCoroutine(UnPerformMoves(cmds.ToList().AsEnumerable().Reverse().ToList()));
    }


    #endregion

  }
}