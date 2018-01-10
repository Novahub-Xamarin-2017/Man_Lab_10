using Android.App;
using Android.OS;
using Android.Widget;
using Java.IO;
using Uri = Android.Net.Uri;

namespace Exercise_3
{
    [Activity(Label = "PlayVideoActivity")]
    public class PlayVideoActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_play_video);

            var videoView = FindViewById<VideoView>(Resource.Id.videoView);
            var fileVideo = Intent.GetStringExtra("fileVideo");
            videoView.SetVideoURI(Uri.FromFile(new File(fileVideo)));
            videoView.Start();
        }
    }
}