using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MeetTheTeacher.Logic
{
    /// <summary>
    /// Verwaltung der Lehrer (mit und ohne Detailinfos)
    /// </summary>
    public class Controller
    {
        private readonly List<Teacher> _teachers;
        private readonly Dictionary<string, int> _details;

        /// <summary>
        /// Liste für Sprechstunden und Dictionary für Detailseiten anlegen
        /// </summary>
        public Controller(string[] teacherLines, string[] detailsLines)
        {
            _details = new Dictionary<string, int>();
            _teachers = new List<Teacher>();

            InitDetails(detailsLines);
            InitTeachers(teacherLines);

            _teachers.Sort();
        }

        public int Count => _teachers.Count;

        public int CountTeachersWithoutDetails => Count - CountTeachersWithDetails;

        /// <summary>
        /// Anzahl der Lehrer mit Detailinfos in der Liste
        /// </summary>
        public int CountTeachersWithDetails => _details.Count;

        /// <summary>
        /// Aus dem Text der Sprechstundendatei werden alle Lehrersprechstunden 
        /// eingelesen. Dabei wird für Lehrer, die eine Detailseite haben
        /// ein TeacherWithDetails-Objekt und für andere Lehrer ein Teacher-Objekt angelegt.
        /// </summary>
        /// <returns>Anzahl der eingelesenen Lehrer</returns>
        private void InitTeachers(string[] lines)
        {
            string[][] splitTeacher = new String[lines.Length][];

            for (int j = 0; j < lines.Length; j++)
            {
                splitTeacher[j] = lines[j].Split(';');

                if (_details.ContainsKey(splitTeacher[j][0]) && splitTeacher[j][0] != null)
                {
                    TeacherWithDetail td = new TeacherWithDetail(splitTeacher[j][0], splitTeacher[j][1], splitTeacher[j][2], splitTeacher[j][3], splitTeacher[j][4], j + 1);
                    _teachers.Add(td);
                }
                else
                {
                    Teacher t = new Teacher(splitTeacher[j][0], splitTeacher[j][1], splitTeacher[j][2], splitTeacher[j][3], splitTeacher[j][4]);
                    _teachers.Add(t);
                }
            }
        }


        /// <summary>
        /// Lehrer, deren Name in der Datei IgnoredTeachers steht werden aus der Liste 
        /// entfernt
        /// </summary>
        public void DeleteIgnoredTeachers(string[] names)
        {
            for (int i = 0; i < _teachers.Count; i++)
            {
                for (int j = 0; j < names.Length; j++)
                {
                    if(_teachers[i].Name.ToLowerInvariant() == names[j].ToLowerInvariant())
                    {
                        _teachers.Remove(_teachers[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Sucht Lehrer in Lehrerliste nach dem Namen
        /// </summary>
        /// <param name="teacherName"></param>
        /// <returns>Index oder -1, falls nicht gefunden</returns>
        private int FindIndexForTeacher(string teacherName)
        {
            for (int i = 0; i < Count; i++)
            {
                if(_teachers[i].Name == teacherName)
                {
                    return 1;
                }
            }

            return -1;
        }


        /// <summary>
        /// Ids der Detailseiten für Lehrer die eine
        /// derartige Seite haben einlesen.
        /// </summary>
        private void InitDetails(string[] lines)
        {
            string[][] splitDetails = new String[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                splitDetails[i] = lines[i].Split(';');
                _details.Add(splitDetails[i][0], Int32.Parse(splitDetails[i][1]));
            }

        }

        /// <summary>
        /// HTML-Tabelle der ganzen Lehrer aufbereiten.
        /// </summary>
        /// <returns>Text für die Html-Tabelle</returns>
        public string GetHtmlTable()
        {
            return "";
        }


    }
}
