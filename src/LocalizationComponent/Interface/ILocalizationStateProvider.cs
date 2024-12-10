namespace LocalizationComponent.Interface
{
    public interface ILocalizationStateProvider
    {
        event EventHandler<LocalizationStateEventArgs>? LocalizationStateChanged;

        void NotifyLocalizationStateChanged(Task<LocalizationState> tskLocalizationState);
        Task ChangeCultureNameAsync(string sCultureName, CancellationToken tknCancellation);
    }
}
