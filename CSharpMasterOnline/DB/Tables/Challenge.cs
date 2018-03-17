using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSharpMasterOnline.DB.Tables
{
    public class Challenge
    {

        public Challenge()
        {
            this.Id = Guid.NewGuid().ToString();

        }
     
        public string Id { get; set; }

        public string Name { get; set; }

        public string Section { get; set; }


        public string Condition { get; set; }

        public string Difficulty { get; set; }

        public string InitialCode { get; set; }

        public string SampleInput { get; set; }

        public string SampleOutput { get; set; }

        public string SampleInput2 { get; set; }

        public string SampleOutput2 { get; set; }




    }
}