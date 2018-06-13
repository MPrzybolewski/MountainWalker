using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.WebBrowser;

namespace MountainWalker.Core.ViewModels
{
    public class AppDescriptionViewModel : MvxViewModel
    {
        public IMvxCommand PatrykLinkedInCommand { get; }
        public IMvxCommand PatrykGithubCommand { get; }

        public IMvxCommand MichalLinkedInCommand { get; }
        public IMvxCommand MichalGithubCommand { get; }

        public IMvxCommand MarekLinkedInCommand { get; }
        public IMvxCommand MarekGithubCommand { get; }

        public AppDescriptionViewModel()
        {
            PatrykLinkedInCommand = new MvxCommand(PatrykLinkedIn);
            PatrykGithubCommand = new MvxCommand(PatrykGithub);
            MichalLinkedInCommand = new MvxCommand(MichalLinkedIn);
            MichalGithubCommand = new MvxCommand(MichalGithub);
            MarekLinkedInCommand = new MvxCommand(MarekLinkedIn);
            MarekGithubCommand = new MvxCommand(MarekGithub);
        }

        private void PatrykLinkedIn()
        {
            PluginLoader.Instance.EnsureLoaded();
            var task = Mvx.Resolve<IMvxWebBrowserTask>();
            task.ShowWebPage("http://www.xamarin.com");        
        }

        private void PatrykGithub()
        {
            
        }

        private void MichalLinkedIn()
        {

        }

        private void MichalGithub()
        {

        }

        private void MarekLinkedIn()
        {

        }

        private void MarekGithub()
        {

        }
    }
}
