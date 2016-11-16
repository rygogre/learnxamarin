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
using SQLite;
using Android.Util;
using D3.Resources.Model;

namespace D3.Resources.DataHelper
{
    public class DataBase
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public DataBase()
        {

        }

        //public int Persona { get; private set; }

        public bool CreateDataBase()
        {
            try
            {
                using (var cnn = new SQLiteConnection(System.IO.Path.Combine(folder, "personas.db")))
                {
                    cnn.CreateTable<Person>();
                    return true;
                }
            }
            catch(SQLiteExcepcion ex)
            {
                Log.Info("SQLiteEX", ex.Message);

                return false;
            }
        }

        public bool InsertPerson(Person person)
        {
            try
            {
                using (var cnn = new SQLiteConnection(System.IO.Path.Combine(folder, "personas.db")))
                {
                    cnn.Insert(person);
                    return true;
                }
            }
            catch (SQLiteExcepcion ex)
            {
                Log.Info("SQLiteEX", ex.Message);

                return false;
            }
        }

        public List<Person> SelectPersons()
        {
            try
            {
                using (var cnn = new SQLiteConnection(System.IO.Path.Combine(folder, "personas.db")))
                {
                    return cnn.Table<Person>().ToList();
                   
                }
            }
            catch (SQLiteExcepcion ex)
            {
                Log.Info("SQLiteEX", ex.Message);

                return null;
            }
        }


        public bool UpdatePerson(Person person)
        {
            try
            {
                using (var cnn = new SQLiteConnection(System.IO.Path.Combine(folder, "personas.db")))
                {
                    cnn.Query<Person>("UPDATE Person SET Nombre=?, Apellidos=?, Email=? WHERE ID=?", person.Nombre, person.Apellidos, person.Email, person.ID);
                    return true;
                }
            }
            catch (SQLiteExcepcion ex)
            {
                Log.Info("SQLiteEX", ex.Message);

                return false;
            }
        }

        public bool DeletePerson(Person person)
        {
            try
            {
                using (var cnn = new SQLiteConnection(System.IO.Path.Combine(folder, "personas.db")))
                {
                    cnn.Delete(person);
                    return true;
                }
            }
            catch (SQLiteExcepcion ex)
            {
                Log.Info("SQLiteEX", ex.Message);

                return false;
            }
        }

        public bool SelectPerson(int id)
        {
            try
            {
                using (var cnn = new SQLiteConnection(System.IO.Path.Combine(folder, "personas.db")))
                {
                    cnn.Query<Person>("SELECT * FROM WHERE ID=?", id);
                    return true;
                }
            }
            catch (SQLiteExcepcion ex)
            {
                Log.Info("SQLiteEX", ex.Message);

                return false;
            }
        }
    }
}