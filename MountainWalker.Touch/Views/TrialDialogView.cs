using System;
using MonoTouch.Dialog;
using UIKit;

namespace MountainWalker.Touch.Views
{
    public class TrialDialogView : DialogViewController
    {
        public TrialDialogView() : base(UITableViewStyle.Grouped, null)
        {
            Root = new RootElement("MyDialogViewController") {
                new Section ("First Section") {
                    new StringElement ("Hello", () => {
                        var alert = UIAlertController.Create ("Hola", "Thanks for tapping, merci!", UIAlertControllerStyle.Alert);
                        var defaultAction = UIAlertAction.Create ("OK", UIAlertActionStyle.Default, null);
                        alert.AddAction (defaultAction);
                        PresentViewController (alert, true, null);
                    }),
                    new EntryElement ("Name", "Enter your name", String.Empty)
                },
                new Section ("Second Section") {
                },
            };
        }
    }
}
