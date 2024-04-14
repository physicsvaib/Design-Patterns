using System.Collections.Generic;

namespace Phyw.DesignPatterns
{

  public class CommandStack
  {
    #region Variables

    private List<ICommandBuilding> stack = new List<ICommandBuilding>();

    #endregion

    #region CustomMethods

    public CommandStack Clone()
    {
      CommandStack clone = new CommandStack();

      foreach (ICommandBuilding c in stack)
      {
        clone.stack.Add(c);
      }

      return clone;
    }

    public void ClearStack()
    {
      stack.Clear();
    }

    public void Push(ICommandBuilding command)
    {
      stack.Add(command);
    }

    public ICommandBuilding Pop()
    {
      ICommandBuilding temp = stack[stack.Count - 1];
      stack.RemoveAt(stack.Count - 1);
      return temp;
    }

    public int GetCount()
    {
      return stack.Count;
    }

    public ICommandBuilding? GetAt(int index)
    {
      if (index < 0) return null;
      return stack[index];
    }

    #endregion

  }
}