
using System.Collections.Generic;

namespace TRPO3
{
    public class Education
    {
        string name;
        public Education(string name)
        {
            this.name = name;
        }

        public string Name 
        {
            get { return this.name; }
            set { this.name = value is string ? value : null; }
        }

        public List<string> categories = new List<string>();

        public List<string> thisCategories
        {
            get { return this.categories; }
        }

        public string setNewCategory
        {
            set { categories.Add(value); }
        }


    }
}
