using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MeetTheTeacher.Logic
{
    /// <summary>
    /// Verwaltet einen Eintrag in der Sprechstundentabelle
    /// Basisklasse für TeacherWithDetail
    /// </summary>
    public class Teacher : IComparable<Teacher>
    {
        private string _day;
        private string _hour;
        private string _room;
        private string _time;
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public Teacher(string name, string day, string hour, string time, string room)
        {
            _day = day;
            _hour = hour;
            _room = room;
            _time = time;
            this.Name = name;
        }

        public int CompareTo(Teacher other)
        {
            var teacher = other as Teacher;
            
            if(teacher == null)
            {
                throw new ArgumentException("Wrong Type");
            }

            return Name.CompareTo(teacher.Name) * -1;
        }

        public virtual string GetHtmlForName()
        {
            throw new NotImplementedException();
        }

        public string GetTeacherHtmlRow()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
