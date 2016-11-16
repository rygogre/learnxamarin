using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Collections.Generic;
using D3.Resources.Model;
using D3.Resources.DataHelper;
using D3.Resources;
using Android.Views.InputMethods;
using Android.Content;

namespace D3
{
    [Activity(Label = "Registro", MainLauncher = true, Icon = "@drawable/Icon")]
    public class MainActivity : Activity
    {
        ListView dataListView;
        List<Person> personList = new List<Person>();
        DataBase db;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            
            db = new DataBase();
            db.CreateDataBase();

            dataListView = FindViewById<ListView>(Resource.Id.personasListView);

            var nombreEditText = FindViewById<EditText>(Resource.Id.nombreEditText);
            //nombreEditText.InputType = 0;
            var apellidosEditText = FindViewById<EditText>(Resource.Id.apellidosEditText);
            var emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);

            var addButton = FindViewById<Button>(Resource.Id.addButton);
            var editButton = FindViewById<Button>(Resource.Id.editButton);
            var deleteButton = FindViewById<Button>(Resource.Id.deleteButton);

            GetPersonas();
            HideKeyBoard();

            //eventos botones
            addButton.Click += delegate
            {
                Person person = new Person()
                {
                    Nombre = nombreEditText.Text,
                    Apellidos = apellidosEditText.Text,
                    Email = emailEditText.Text
                };

                db.InsertPerson(person);
                GetPersonas();
                HideKeyBoard();
            };

            editButton.Click += delegate
            {
                Person person = new Person()
                {
                    ID = int.Parse(nombreEditText.Tag.ToString()),
                    Nombre = nombreEditText.Text,
                    Apellidos = apellidosEditText.Text,
                    Email = emailEditText.Text
                };

                db.UpdatePerson(person);
                GetPersonas();
                HideKeyBoard();
            };

            deleteButton.Click += delegate
            {
                Person person = new Person()
                {
                    ID = int.Parse(nombreEditText.Tag.ToString()),
                    Nombre = nombreEditText.Text,
                    Apellidos = apellidosEditText.Text,
                    Email = emailEditText.Text
                };

                db.DeletePerson(person);
                GetPersonas();
                HideKeyBoard();
            };

            dataListView.ItemClick += (s, e) =>
            {
                for(int i=0; i<dataListView.Count; i++)
                {
                    if (e.Position == i)
                        dataListView.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Azure);
                    //else
                    //    dataListView.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);

                }

                var nEditText = e.View.FindViewById<TextView>(Resource.Id.nombreTextView);
                var aEditText = e.View.FindViewById<TextView>(Resource.Id.apellidosTextView);
                var eEditText = e.View.FindViewById<TextView>(Resource.Id.emailTextView);

                nombreEditText.Text = nEditText.Text;
                nombreEditText.Tag = e.Id;
                apellidosEditText.Text = aEditText.Text;
                emailEditText.Text = eEditText.Text;
            };
        }

        private void GetPersonas()
        {
            personList = db.SelectPersons();

            var adapter = new ListViewAdapter(this, personList);
            dataListView.Adapter = adapter;
        }


        private void HideKeyBoard()
        {
            InputMethodManager inputManager = (InputMethodManager)GetSystemService(Context.InputMethodService);
            var currentFocus = Window.CurrentFocus;

            if (currentFocus != null)
            {
                inputManager.HideSoftInputFromWindow(currentFocus.WindowToken, HideSoftInputFlags.None);
            }
        }
    }
}


