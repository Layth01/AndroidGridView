using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System.Collections.Generic;
using Android;
using System;
using Android.Runtime;


namespace AndroidGridView
{
    [Activity(Label = "AndroidGridView", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        List<TableItem> tableItems;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            GridView gridView1 = FindViewById<GridView>(Resource.Id.gridView1);

            tableItems = new List<TableItem>();
            tableItems.Add(new TableItem("Layth", "Devepoer CEO", Resource.Drawable.Layth));
            tableItems.Add(new TableItem("Ahmed", "Admin", Resource.Drawable.Icon));
            tableItems.Add(new TableItem("Jasim", "Manager", Resource.Drawable.Icon));
            gridView1.Adapter = new HomeScreenAdapter(this, tableItems);
            gridView1.ItemClick += OnListItemClick;  // to be defined

        }

        // get item slected
        void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var t = tableItems[e.Position];
            Android.Widget.Toast.MakeText(this, t.Heading, Android.Widget.ToastLength.Short).Show();
        }
    }
    }
    public class TableItem
    {
        public string Heading;
        public string SubHeading;
        public int ImageResourceId;
        public TableItem(string Heading, string SubHeading, int ImageResourceId)
        {
            this.Heading = Heading;
            this.SubHeading = SubHeading;
            this.ImageResourceId = ImageResourceId;
        }
    }
    public class HomeScreenAdapter : BaseAdapter<TableItem>
    {
        List<TableItem> items;
        Activity context;
        public HomeScreenAdapter(Activity context, List<TableItem> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override TableItem this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.TicketView, null);
            view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Heading;
            view.FindViewById<TextView>(Resource.Id.Text2).Text = item.SubHeading;
            view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(item.ImageResourceId);
            return view;
        }
    }


