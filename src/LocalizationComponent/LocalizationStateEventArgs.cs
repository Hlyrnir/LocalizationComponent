namespace LocalizationComponent
{
    public sealed class LocalizationStateEventArgs : EventArgs
    {
        public required Task<LocalizationState> LocalizationState { get; init; }
    }
}
