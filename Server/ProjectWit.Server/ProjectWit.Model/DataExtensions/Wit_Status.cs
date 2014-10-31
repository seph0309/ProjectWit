using System.ComponentModel.DataAnnotations;

namespace ProjectWit.Model
{
    using System;
    using System.Collections.Generic;

    public sealed class Wit_Status
    {
        private readonly String name;
        private readonly int value;

        public static readonly List<KeyValuePair<int, string>> Status = new List<KeyValuePair<int, string>>();
        public static readonly Wit_Status Started = new Wit_Status(1, "Started");
        public static readonly Wit_Status Accepted = new Wit_Status(2, "Accepted");
        public static readonly Wit_Status Submitted = new Wit_Status(3, "Submitted");

        private Wit_Status(int _value, string _name)
        {
            value = _value;
            name = _name;
            Status.Add(new KeyValuePair<int,string>(value,name));
        }

        public override string ToString()
        {
            return name;
        }
    }

   
}
