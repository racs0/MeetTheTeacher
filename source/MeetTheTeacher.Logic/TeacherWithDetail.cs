using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MeetTheTeacher.Logic
{
    /// <summary>
    /// Klasse, die einen Detaileintrag mit Link auf dem Namen realisiert.
    /// </summary>
    public class TeacherWithDetail : Teacher
    {
        private int _id;

        public TeacherWithDetail(string name, string day, string hour, string time, string room, int id) : base(name, day, hour, time, room)
        {
            _id = id;
        }

        public override string GetHtmlForName()
        {
            return base.GetHtmlForName();
        }
    }
}
