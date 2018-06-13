using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.WebBrowser;

namespace MountainWalker.Core.ViewModels
{
    public class AppDescriptionViewModel : MvxViewModel
    {
        public string Description { get; set; } = "Tutaj fajny opisik";

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
