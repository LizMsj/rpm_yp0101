using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class Group
    {
        public int Id { get; set; }
        public Special Special { get; set; }
        public int SubGroup { get; set; }
        public int ClassRoom { get; set; }
        public int StartYear { get; set; }
        public string Scp { get; set; }

        public static void CreateGroups()
        {
            using (var db = new DBContext())
            {
                Special special = new Special { Code = "П", Name = "Программисты" };
                db.Specials.Add(special);
                for (int i = 0; i < 4; i++)
                {
                    for (int a = 1; a < 3; a++)
                    {
                        Group group = new Group
                        {
                            ClassRoom = 9,
                            SubGroup = a,
                            StartYear = 2019 + i,
                            Special = special
                        };
                        db.Groups.Add(group);
                        group.Scp = group.GetCode(special);
                    }
                }
                db.SaveChanges();
            }
        }

        public string GetCode(Special special)
        {

            int kourse = DateTime.Now.Year - StartYear;
            if (DateTime.Now.Month >= 9)
                kourse++;
            return $"{kourse}-{SubGroup}{special?.Code}{ClassRoom}";
        }
    }
}
