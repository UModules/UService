using UModuleManager.Sample.A;
using UnityEngine;
using UService;

namespace UModuleManager.Sample.B
{
    public class ModuleB : MonoBehaviour
    {
        private void Awake()
        {
            ServiceLocator.RegisterService(this);
        }

        [ContextMenu("PrintMessage")]
        public void PrintMessage()
        {
            ServiceLocator.GetService<ModuleA>().PrintMessage("Hello from the ModuleB!");
        }
    }
}
