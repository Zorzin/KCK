//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace KCKTest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [Key]
        public int idusers { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public float goal { get; set; }
        public float bikedivider { get; set; }
        public float swimdivider { get; set; }

        public User()
        {
            this.idusers = 0;
            this.name = null;
            this.password = null;
            this.goal = 0;
            this.bikedivider = 0;
            this.swimdivider = 0;
        }

        public User(string name, string password, float goal, float bikedivider, float swimdivider)
        {
            this.name = name;
            this.password = password;
            this.goal = goal;
            this.bikedivider = bikedivider;
            this.swimdivider = swimdivider;
        }
        public User(string name, string password, float goal, float bikedivider, float swimdivider, int idusers)
        {
            this.name = name;
            this.password = password;
            this.goal = goal;
            this.bikedivider = bikedivider;
            this.swimdivider = swimdivider;
            this.idusers = idusers;
        }
    }
}
