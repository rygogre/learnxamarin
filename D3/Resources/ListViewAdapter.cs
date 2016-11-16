using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using D3.Resources.Model;
using Java.Lang;

namespace D3.Resources
{
    public class ViewHolder : Java.Lang.Object
    {
        public TextView nombreTextView { get; set; }
        public TextView apellidosTextView { get; set; }
        public TextView emailTextView { get; set; }
    }
    public class ListViewAdapter:BaseAdapter
    {
        private Activity activity;
        private List<Person> personList;

        public ListViewAdapter(Activity activity, List<Person> personList)
        {
            this.activity = activity;
            this.personList = personList;
        }

        public override int Count
        {
            get
            {
                return personList.Count();
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return personList[position].ID;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.ListViewDataTemplate, parent, false);

            var nombreTexView = view.FindViewById<TextView>(Resource.Id.nombreTextView);
            var apellidosTexView = view.FindViewById<TextView>(Resource.Id.apellidosTextView);
            var emailTexView = view.FindViewById<TextView>(Resource.Id.emailTextView);

            nombreTexView.Text = personList[position].Nombre;
            apellidosTexView.Text = personList[position].Apellidos;
            emailTexView.Text = personList[position].Email;

            return view;
        }       
    }
}