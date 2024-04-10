using UnityEngine;

namespace Phyw.DesignPatterns
{

  [System.Serializable]

  public class MoveCommand : ICommand
  {
    private Transform player;

    private int vec;

    public void SetVec(int vec)
    {
      this.vec = vec;
    }


    public void Execute(Transform obj)
    {
      Debug.Log(vec);
      Vector2 val = new Vector2(Mathf.Floor(vec / 2), vec % 2);
      obj.Translate(val * 0.2f);
    }

    public void UnExecute(Transform obj)
    {
      Vector2 val = new Vector2(-Mathf.Floor(vec / 2), -vec % 2);
      obj.Translate(val * 0.2f);

    }
  }
}