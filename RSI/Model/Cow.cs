using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RSI.Model
{
    [DataContract]
    public class Cow
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public CowBreed CowBreed { get; set; }

        [DataMember]
        public DateTime DateOfBirth { get; set; }

        [DataMember]
        public DateTime DateOfCalving { get; set; }

        [DataMember]
        public string TagNumber { get; set; }
    }
}