using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeManageSystem.Models
{
    public class Department
    {
        public Department(string id, string name, List<IAccount> accounts, List<Course> courses)
        {
            Id = id;
            Name = name;
            Accounts = accounts;
            Courses = courses;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public List<IAccount> Accounts { get; set; }
        public List<Course> Courses { get; set; }

        public List<IAccount> FindAccountByAuthority(int authority)
        {
            List<IAccount> accounts = new List<IAccount>();
            Accounts.ForEach((account) =>
            {
                if (account.Authority == authority)
                    accounts.Add(account);
            });

            return accounts;
        }

        public IAccount FindAccountById(string accountId)
        {
            foreach (var account in Accounts)
            {
                if (account.Id == accountId)
                    return account;
            }
            return null;
        }
    }
}
