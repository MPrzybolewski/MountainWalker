using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using MountainWalker.Core.Interfaces;
using MountainWalker.Droid.Views;
using Debug = System.Diagnostics.Debug;
using DialogFragment = MountainWalker.Droid.Fragments.DialogFragment;

namespace MountainWalker.Droid.Services
{
    public class DroidMainActivityService : IMainActivityService
    {
        public void SetLatLngButton(double latitude, double longitude)
        {
            LatLng coordinate = new LatLng(latitude, longitude);
            CameraUpdate yourLocation = CameraUpdateFactory.NewLatLngZoom(coordinate, 17);
            MainView.Map.AnimateCamera(yourLocation);
        }

        public void SetCurrentLocation(double latitude, double longitude)
        {
            LatLng coordinate = new LatLng(latitude, longitude);
            CameraUpdate yourLocation = CameraUpdateFactory.NewLatLngZoom(coordinate, 17);
            MainView.Map.AnimateCamera(yourLocation);
        }

        public void CloseMainDialog()
        {
            DialogFragment.dialog.Dismiss();
        }

        public bool CheckPointIsNear()
        {
            //TODO later
            return false;
        }
    }
}