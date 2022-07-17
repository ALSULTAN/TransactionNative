using Android.App;
using Android.OS;
using AndroidX.AppCompat.App;

namespace TransactionNative.Android.Activities
{
    [Activity(Label = "@string/AppName", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class TransactionsActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle SavedInstanceState)
        {
            base.OnCreate(SavedInstanceState);
            Xamarin.Essentials.Platform.Init(this, SavedInstanceState);
            UI.TransactionList.Show(this);
        }

        static int CurrentLayout;
        public override void SetContentView(int LayoutResID)
        {
            CurrentLayout = LayoutResID;
            base.SetContentView(CurrentLayout);
        }

        public override void OnBackPressed()
        {
            if (CurrentLayout != Resource.Layout.TransactionMain)
            {
                UI.TransactionList.Show(this);
            }
            else
            {
                base.OnBackPressed();
            }
        }
    }
}

