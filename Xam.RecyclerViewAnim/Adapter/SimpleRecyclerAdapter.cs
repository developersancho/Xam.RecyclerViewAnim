using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using static Android.Support.V7.Widget.RecyclerView;

namespace Xam.RecyclerViewAnim.Adapter
{

    public class SimpleViewHolder : ViewHolder
    {

        public TextView textView { get; set; }

        public SimpleViewHolder(View itemView) : base(itemView)
        {
            textView = itemView.FindViewById<TextView>(Resource.Id.textView);
        }
    }

    public class SimpleRecyclerAdapter : RecyclerView.Adapter
    {
        List<int> dataSource;

        public SimpleRecyclerAdapter()
        {
            dataSource = new List<int>();
            for (int i = 0; i < 50; i++)
            {
                dataSource.Add(i);
            }
        }

        public override int ItemCount => dataSource.Count;

        public override void OnBindViewHolder(ViewHolder holder, int position)
        {
            SimpleViewHolder vh = holder as SimpleViewHolder;
            vh.textView.Text = dataSource[position].ToString();
        }

        public override ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ListItem, parent, false);
            return new SimpleViewHolder(view);
        }
    }
}
