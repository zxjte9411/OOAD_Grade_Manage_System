﻿using System;

namespace GradeManageSystem.Models
{
    public class UserInformation
    {
        public UserInformation()
        {
        }

        public UserInformation(string name, string phone, string address, DateTime birthday, string gender)
        {
            Name = name;
            Phone = phone;
            Address = address;
            Birthday = birthday;
            Gender = gender;
            //Id = id;
        }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        //public int Id { get; set; }
    }
}
