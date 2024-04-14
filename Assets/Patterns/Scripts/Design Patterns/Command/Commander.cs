using Phyw.Utils;
using UnityEngine;

namespace Phyw.DesignPatterns
{

  public class Commander : MonoBehaviour
  {
    #region Variables
    [SerializeField] private Raycaster raycaster;
    [SerializeField] private GameObject[] objsToSpawn;

    private CommandStack currentStack;
    private int rotationAngle = 0;
    private int currentIndex = -1;

    #endregion

    #region UnityMethods

    private void OnEnable()
    {
      currentStack = new CommandStack();
    }

    #endregion

    #region CustomMethods


    public Vector3? GetRayPos()
    {
      return raycaster.GetRayCastPosition();

    }

    public void CreateObject(int index)
    {

      Vector3? pos = raycaster.GetRayCastPosition();
      if (pos.HasValue)
      {
        BuildCommand cmd = new GameObject().AddComponent<BuildCommand>();
        cmd.building = objsToSpawn[index];
        cmd.SetProperties(pos.Value, Quaternion.Euler(0, rotationAngle, 0));

        Push(cmd);
        cmd.Execute();
      }

    }

    public void ClearStack()
    {
      currentStack.ClearStack();
      currentIndex = -1;
    }

    public CommandStack GetCommandStack()
    {
      return currentStack.Clone();
    }

    public void Push(ICommandBuilding cmd)
    {
      currentStack.Push(cmd);
      currentIndex++;
      print(currentIndex);
    }

    public void Undo()
    {
      if (currentIndex < 0) { return; }
      print(currentIndex);
      currentStack.Pop().UnExecute();
      currentIndex--;
    }

    //public void Redo()
    //{
    //  currentIndex++;
    //  int count = currentStack.GetCount();
    //  currentIndex = currentIndex < count ? currentIndex : count;
    //  currentStack.GetAt(currentIndex).Execute();
    //}

    public void Pop()
    {
      ICommandBuilding temp = currentStack.Pop();
      temp.UnExecute();
    }

    #endregion

  }
}