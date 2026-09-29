using eShop.UseCases.PluginInterfaces.StateStore;

namespace eShop.StateStore.DI
{
    public class StateStoreBase : IStateStore
    {
        protected Action? listeners;

        public void AddStateChangeListeners(Action listener)
        {
            this.listeners += listener;
        }

        public void RemoveStateChangeListeners(Action listener)
        {
            this.listeners -= listener;
        }

        public void BroadCastStateChange()
        {
            this.listeners?.Invoke();
        }
    }
}
