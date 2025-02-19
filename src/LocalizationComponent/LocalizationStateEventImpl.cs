using System;
using System.Threading.Tasks;

namespace LocalizationComponent
{
    public abstract class LocalizationStateEventImpl
    {
        public event EventHandler<LocalizationStateEventArgs>? LocalizationStateChanged;

        public void NotifyLocalizationStateChanged(Task<LocalizationState> tskLocalizationState)
        {
            if (tskLocalizationState is null)
                return;

            OnLocalizationStateChangedEvent(new LocalizationStateEventArgs { LocalizationState = tskLocalizationState });
        }

        private void OnLocalizationStateChangedEvent(LocalizationStateEventArgs evntLocalizationState)
        {
            EventHandler<LocalizationStateEventArgs>? evntHandler = LocalizationStateChanged;

            if (evntHandler is not null)
                evntHandler(this, evntLocalizationState);
        }
    }
}
