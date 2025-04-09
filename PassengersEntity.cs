using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementEntityLibrary
{
    public class PassengersEntity
    {
        private int passengerId;
        private string firstName;
        private string gender;
        private int age;
        private string email;
        private string phoneNumber;

        public int PassengerId
        {
            set { passengerId = value; }
            get { return passengerId; }
        }

        public string FirstName
        {
            set { firstName = value; }
            get { return firstName; }
        }

        public string Gender
        {
            set { gender = value; }
            get { return gender; }
        }

        public int Age
        {
            set { age = value; }
            get { return age; }
        }

        public string Email
        {
            set { email = value; }
            get { return email; }
        }

        public string PhoneNumber
        {
            set { phoneNumber = value; }
            get{ return phoneNumber; }         
        }

        public PassengersEntity()
        {

        }

        public PassengersEntity(int passengerId, string firstName, string gender, int age, string email, string phoneNumber)
        {
            this.passengerId = passengerId;
            this.firstName = firstName;
            this.gender = gender;
            this.age = age;
            this.email = email;
            this.phoneNumber = phoneNumber;          
        }
    }
}
