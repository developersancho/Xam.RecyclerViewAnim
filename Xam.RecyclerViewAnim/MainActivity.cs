using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Xam.RecyclerViewAnim.Adapter;
using System;
using Android.Views.Animations;

namespace Xam.RecyclerViewAnim
{
    [Activity(Label = "Xam.RecyclerViewAnim", MainLauncher = true, Icon = "@mipmap/icon"
              //Theme = "@style/Theme.AppCompact.Light.NoActionBar"
             )]
    public class MainActivity : Activity
    {
        RecyclerView recyclerView;
        Button btnFallDown, btnSlideBottom, btnFromLeft;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            btnFallDown = FindViewById<Button>(Resource.Id.btnFallDown);
            btnFallDown.Click += delegate {
                RunAnimation(recyclerView, 0);
            };

            btnSlideBottom = FindViewById<Button>(Resource.Id.btnSlideBottom);
            btnSlideBottom.Click += delegate {
                RunAnimation(recyclerView, 1);
            };

            btnFromLeft = FindViewById<Button>(Resource.Id.btnFromLeft);
            btnFromLeft.Click += delegate {
                RunAnimation(recyclerView, 2);
            };

            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
           
           
        }

        private void RunAnimation(RecyclerView recycView, int type)
        {
            var context = recycView.Context;
            LayoutAnimationController controller = null;

            if (type == 0)
                controller = AnimationUtils.LoadLayoutAnimation(context, Resource.Animation.layout_fall_down);
            else if (type == 1)
                controller = AnimationUtils.LoadLayoutAnimation(context, Resource.Animation.layout_slide_from_bottom);
            else if (type == 2)
                controller = AnimationUtils.LoadLayoutAnimation(context, Resource.Animation.layout_slide_from_left);
            
            recyclerView.SetLayoutManager(new GridLayoutManager(this,4));
            SimpleRecyclerAdapter adapter = new SimpleRecyclerAdapter();
            recyclerView.SetAdapter(adapter);

            recyclerView.LayoutAnimation = controller;
            recyclerView.GetAdapter().NotifyDataSetChanged();
            recyclerView.ScheduleLayoutAnimation();
        }
    }
}

