using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Morse
{
    /// <summary>
    /// Class for containing the saved records from the app.
    /// </summary>
    public class Database
    {
        private IDictionary<string, string> database;

        public Database()
        {
            FillDatabase();
        }

        /// <summary>
        /// Gets the saved records from the database(txt file) and loads them in a container.
        /// Is used only when the app is open for the first time.
        /// App saves and deletes the records from the container.
        /// </summary>
        public void FillDatabase()
        {
            try
            {
                this.database = new Dictionary<string, string>();
                string[] lines = System.IO.File.ReadAllLines(@"D:\MorseCodeDatabase.txt");

                foreach (string line in lines)
                {
                    string[] inputArgs = line.Split('@').ToArray();
                    string name = inputArgs[0];
                    string text = inputArgs[1];
                    this.database.Add(name, text);
                }
            }
            catch(FileNotFoundException)
            {
                this.database = new Dictionary<string, string>();
            }
        }

        public IDictionary<string, string> GetAllRecords()
        {
            return this.database;
        }

        /// <summary>
        /// Saves the changes made from the app in the container.
        /// Replaces the content of the txt file with the content of the container.
        /// Is used only when the app is finally closed.
        /// </summary>
        public void SaveDatabase()
        {
            System.IO.File.WriteAllText(@"D:\MorseCodeDatabase.txt", string.Empty);

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"D:\MorseCodeDatabase.txt"))
            {
                foreach (KeyValuePair<string,string> line in this.database)
                {

                    file.WriteLine(line.Key + "@" + line.Value);
                }
            }

        }

        /// <summary>
        /// Saves new record in the database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="text"></param>
        public void AddRecord(string name, string text)
        {
            if(this.database.ContainsKey(name))
            {
                throw new DuplicateWaitObjectException("Record with the same name already exist in the database");
            }
            else
            {
                this.database.Add(name, text);
            }
        }

        /// <summary>
        /// Gets a record from database by given key.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetRecord(string name)
        {
            if(!this.database.ContainsKey(name))
            {
                throw new ArgumentException("There is no record wiht such name");
            }
            else
            {
                return this.database[name];
            }
        }

        /// <summary>
        /// Delete a record from database by given key.
        /// </summary>
        /// <param name="name"></param>
        public void DeleteRecord(string name)
        {
            if (!this.database.ContainsKey(name))
            {
                throw new ArgumentException("There is no record wiht such name");
            }
            else
            {
                this.database.Remove(name);
            }
        }

    }
}
