using UModuleManager.Sample.A;
using UModuleManager.Sample.B;
using UnityEngine;
using UService;

namespace UModuleManager.Sample
{
    public class RuntimeSample : MonoBehaviour
    {
        [ContextMenu("PrintMessage A")]
        public void PrintMessageA()
        {
            ServiceLocator.GetService<ModuleA>().PrintMessage("Hello from the RuntimeSample!");
        }

        [ContextMenu("PrintMessage B")]
        public void PrintMessageB()
        {
            Debug.Log("Call from RuntimeSample");
            ServiceLocator.GetService<ModuleB>().PrintMessage();
        }
    }
}
