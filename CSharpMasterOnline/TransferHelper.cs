using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using CSharpMasterOnline.Models;
using CSharpMasterOnline.DB.Tables;

namespace CSharpMasterOnline
{
    public class TransferHelper
    {
    

        public static Object ChallengeTransport(Challenge challenge)
        {

            var input = File.ReadAllText(challenge.SampleInput).Replace("\n", "<br />");
            var input2 = File.ReadAllText(challenge.SampleInput2).Replace("\n", "<br />"); 

            var output = File.ReadAllText(challenge.SampleOutput).Replace("\n", "<br />");
            var output2 = File.ReadAllText(challenge.SampleOutput2).Replace("\n", "<br />");


            ChallengeTransport result = new ChallengeTransport()
            {
                Name = challenge.Name,
                Id = challenge.Id,
                Condition = challenge.Condition,
                Difficulty = challenge.Difficulty,
                Section = challenge.Section,
                InitialCode = challenge.InitialCode,
                SampleInput = input,
                SampleInput2 = input2,
                SampleOutput = output,
                SampleOutput2 = output2
                
              
             };

            return result;
        }
    }
}