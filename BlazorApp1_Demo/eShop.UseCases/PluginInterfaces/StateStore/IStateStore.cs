namespace eShop.UseCases.PluginInterfaces.StateStore
{
    public interface IStateStore
    {
        void AddStateChangeListeners(Action listeners);
        void AddStateChangeListener(Action listeners);
        void RemoveStateChangeListeners(Action listeners);
        void RemoveStateChangeListener(Action listeners);
        void BroadCastStateChange();
        void BroadcastStateChange();
    }
}
