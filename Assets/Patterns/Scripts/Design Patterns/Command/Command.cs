using UnityEngine;

namespace Phyw.DesignPatterns
{
  public interface ICommand
  {
    void Execute(Transform obj);
    void UnExecute(Transform obj);
  }
}