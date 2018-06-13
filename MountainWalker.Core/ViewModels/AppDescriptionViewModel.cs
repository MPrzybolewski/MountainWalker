using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.WebBrowser;

namespace MountainWalker.Core.ViewModels
{
    public class AppDescriptionViewModel : MvxViewModel
    {
        public string Description { get; set; } = "Aplikacja została stworzona z myślą o ludziach, którzy uwielbiają " +
            "wędrówki po polskich Tatrach. Dzięki niej użytkownicy mogą mieć wszystko w jednym " +
            "miejscu: mapę ze szlakami, informacje o szlakach oraz historię swoich wypraw. " +
            "Mountain Walker jest ekwiwalentem Endomondo dla ludzi, którzy aktywnie zwiedzają Tatry. " +
            "\n\n" +
            "Aplikacja umożliwia przeglądanie mapy wraz z naniesionymi szlakami oraz czytanie ich opisu. " +
            "Jej główną przewagą nad innymi aplikacjami tego typu jest fakt, że umożliwia śledzenie wędrówki" +
            "dzięki obsłudze Google Maps, zapisywanie przebytych wędrówek oraz zdobywanie osiągnięc, czyli szczytów górskich. " +
            "Aplikacja może rozpocząć wędrówkę tylko wtedy, gdy jesteśmy przy punkcie na szlaku (przecięciu się szlaków lub przy ich początkach). " +
            "Wszystko dzieje się w tle, więc użytkownik nie musi się martwić o to, co robi aplikacja. " +
            "Po zakończeniu podróży aplikacja zapisze nasze dokonania i od razu będziemy mieli do nich dostęp." +
            "\nMountain Walker powstał jako projekt licencjacki niżej wymienionych studentów z pomocą firmy Jit Solutions.";

        public IMvxCommand PatrykLinkedInCommand { get; }
        public IMvxCommand PatrykGithubCommand { get; }

        public IMvxCommand MichalLinkedInCommand { get; }
        public IMvxCommand MichalGithubCommand { get; }

        public IMvxCommand MarekLinkedInCommand { get; }
        public IMvxCommand MarekGithubCommand { get; }

        private IMvxWebBrowserTask _task;

        public AppDescriptionViewModel()
        {
            PatrykLinkedInCommand = new MvxCommand(PatrykLinkedIn);
            PatrykGithubCommand = new MvxCommand(PatrykGithub);
            MichalLinkedInCommand = new MvxCommand(MichalLinkedIn);
            MichalGithubCommand = new MvxCommand(MichalGithub);
            MarekLinkedInCommand = new MvxCommand(MarekLinkedIn);
            MarekGithubCommand = new MvxCommand(MarekGithub);
            PluginLoader.Instance.EnsureLoaded();
            _task = Mvx.Resolve<IMvxWebBrowserTask>();
        }

        private void PatrykLinkedIn()
        {
            _task.ShowWebPage("https://www.linkedin.com/in/patryk-matuszak-0b841a146/");
        }

        private void PatrykGithub()
        {
            _task.ShowWebPage("https://github.com/matuszakpatryk");
        }

        private void MichalLinkedIn()
        {
            _task.ShowWebPage("https://www.linkedin.com/");
        }

        private void MichalGithub()
        {
            _task.ShowWebPage("https://github.com/xvoxin");
        }

        private void MarekLinkedIn()
        {
            _task.ShowWebPage("https://www.linkedin.com/in/marek-przybolewski-253664122/");
        }

        private void MarekGithub()
        {
            _task.ShowWebPage("https://github.com/MPrzybolewski");
        }
    }
}
