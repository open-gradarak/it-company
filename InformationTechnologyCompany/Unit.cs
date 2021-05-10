using System;
using System.Collections.Generic;
using System.Text;

namespace InformationTechnologyCompany
{
    public enum UnitType
    {
        Undefined,
        Company,
        Department,
        Team,
    }

    public class Unit<T> : IReportable
    {
        // Fields
        string unitId = CompanyUtil.getGuid();
        UnitType unitType;

        DateTime createDate = DateTime.UtcNow;
        DateTime updateDate;
        DateTime endDate;
        int minCapacity = 1;
        int maxCapacity = 100;
        string name;
        Employee head;
        List<T> memberList = new List<T>();

        // Constructors
        public Unit(string name, UnitType unitType, int minCapacity, int maxCapacity)
        {

            this.name = name;
            this.unitType = unitType;
            this.minCapacity = minCapacity;
            this.maxCapacity = maxCapacity;
        }

        public Unit(string name, UnitType unitType)
        {
            this.name = name;
            this.unitType = unitType;
        }

        // Properties
        protected List<T> MemberList { get => memberList; }
        public string Name { get => name; set => name = value; }
        protected int MinCapacity { get => minCapacity; set => minCapacity = value; }
        protected int MaxCapacity { get => maxCapacity; set => maxCapacity = value; }
        protected int Size { get => memberList.Count; }
        public string UnitId { get => unitId; }
        protected UnitType UnitType { get => unitType; }
        protected DateTime CreateDate { get => createDate; }
        protected DateTime UpdateDate { get => updateDate; set => updateDate = value; }
        protected DateTime EndDate { get => endDate; }
        public Employee Head { get => head; set => head = value; }

        //  Methods
        protected bool AddMember(T member, bool updateMaxCapacity)
        {
            if (this.memberList.Contains(member))
            {
                return false;
            }
            if (memberList.Count == this.maxCapacity)
            {
                if(updateMaxCapacity)
                {
                    this.maxCapacity = memberList.Count + 1;
                } else
                {
                    return false;
                }
            }
            // add the member
            memberList.Add(member);
            // update the timestamp
            updateDate = DateTime.UtcNow;

            return true;
        }

        protected bool RemoveMember(T member, bool updateMinCapacity)
        {
            if (!this.memberList.Contains(member))
            {
                return false;
            }
            if (this.Size == this.minCapacity)
            {
                if (updateMinCapacity)
                {
                    this.minCapacity = this.Size - 1;
                }
                else
                {
                    return false;
                }
            }
            // remove the member
            memberList.Remove(member);
            // update the timestamp
            updateDate = DateTime.UtcNow;

            return true;
        }

        override
        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string uType = this.unitType.ToString();
            // add unit's name
            sb.AppendLine("*************************************************");
            sb.AppendFormat("The {0} name is {1}", uType.ToLower(), this.name).AppendLine();
            // add unit's head info
            if (head != null)
            {
                sb.AppendFormat("The head of {0} is {1}", name, head.ToString());
                sb.AppendLine();
            } // add units members
            if (this.memberList.Count > 0)
            {
                sb.AppendFormat("{0} members are:", uType).AppendLine();
                foreach (T member in this.memberList)
                {
                    sb.AppendLine(member.ToString());

                }
            }
            return sb.ToString().Trim();
        }

        public void GenerateReport()
        {
            Console.WriteLine(this.ToString());
        }

        public bool IsUnderstaffed()
        {
            return (this.maxCapacity + this.minCapacity) / 2 > this.Size;
        }

        // returns the number of unoccupied positions 
        public int GetUnoccupiedPositionCount()
        {
            return this.maxCapacity - this.Size;
        }
    }
}
