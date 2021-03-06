using System.ComponentModel.DataAnnotations;

namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;

    public sealed class Wit_Status : WitDbContextBase<Wit_Status>
    {
        private readonly String name;
        private readonly int value;

        public static readonly List<KeyValuePair<int, string>> Status = new List<KeyValuePair<int, string>>();
        public static readonly Wit_Status Open = new Wit_Status(1, "Open");
        public static readonly Wit_Status Submitted = new Wit_Status(2, "Submitted");
        public static readonly Wit_Status Accepted = new Wit_Status(3, "Accepted");
        public static readonly Wit_Status Processed = new Wit_Status(4, "Processed");
        public static readonly Wit_Status Billed = new Wit_Status(5, "Billed");
        public static readonly Wit_Status Closed = new Wit_Status(6, "Closed");

        private Wit_Status(int _value, string _name)
        {
            value = _value;
            name = _name;
            Status.Add(new KeyValuePair<int,string>(value,name));
        }

        public Wit_Status() { }

        public bool IsStatusValid(string status)
        {
            if (Wit_Status.Status.Where(statusValue => statusValue.Value == status).Count() == 0)
            {
                LogMsg("Invalid status");
                return false;
            }
            else
                return true;
        }

        public override string ToString()
        {
            return name;
        }
    }

   
}
