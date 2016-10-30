using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_4_5_zadatak
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }

        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public Student(string name, string jmbag, Gender gender)
        {
            Name = name;
            Jmbag = jmbag;
            Gender = gender;
        }

        public static bool operator ==(Student a, Student b)
        {
            if (object.ReferenceEquals(a,null)||object.ReferenceEquals(b,null))
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(Student a, Student b)
        {
            if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
                return false;
            return a.Equals(b);
        }


        // DISTINCT ==> EQUALS I GETHASHCODE
        /*Notes to Implementers:
            Implementations are required to ensure that if the Equals method returns true for two objects x and y, 
            then the value returned by the GetHashCode method for x must equal the value returned for y.
            The Equals method is reflexive, symmetric, and transitive. That is, it returns true if used to 
            compare an object with itself; true for two objects x and y if it is true for y and x; and true for 
            two objects x and z if it is true for x and y and also true for y and z.
            
            KAKO BI TO TREBALO IZGLEDATI?! (msdn)
              public override bool Equals(Object obj)
              {
                Person personObj = obj as Person; 
                if (personObj == null)
                    return false;
                else
                    return idNumber.Equals(personObj.idNumber);
              }
              
             public override int GetHashCode()
             {
                return this.idNumber.GetHashCode(); 
             }*/

        public override bool Equals(Object obj)
        {
            Student chan = obj as Student;
            if (chan == null)
                return false;
            return Jmbag.Equals(chan.Jmbag);
        }

        /*Notes to Implementers:
        Implementations are required to ensure that if the Equals method returns true for two objects x and y, 
        then the value returned by the GetHashCode method for x must equal the value returned for y.*/

        public override int GetHashCode()
        {
            return this.Jmbag.GetHashCode();
        }
    }

    public enum Gender
        {
            Male, Female 
        }
}
