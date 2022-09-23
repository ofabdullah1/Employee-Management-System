using System;
using System.Collections.Generic;
using System.Text;

namespace TEams
{
    class Project
    {
        string Name { get; set; }
        string Description { get; set; }
        string StartDate { get; set; }
        string DueDate { get; set; }
        List<Employee> TeamMembers { get; set; } = new List<Employee>();

        public Project(string name, string description, string startDate, string dueDate)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            DueDate = dueDate;
        }


    }
}
