using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Morse
{
    public class Database
    {
        private IDictionary<string, string> database;

        public Database()
        {
            FillDatabase();
        }

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
