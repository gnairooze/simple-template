﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SimpleTemplate.Model;

namespace SimpleTemplate.Business.Function
{
    internal class MapFunction : IFunction
    {
        public Model.Variable InputVariable { get; set; }
        public JObject Data { get; set; }
        public Hashtable Mapping { get; set; }

        public MapFunction(Model.Variable inputVariable, JObject data)
        {
            this.Data = data;
            this.InputVariable = inputVariable;
        }

        public string CalculateValue()
        {
            if(this.Mapping == null || this.Mapping.Count == 0 || this.InputVariable == null || this.InputVariable.FunctionArguments == null || this.InputVariable.FunctionArguments.Count == 0)
            {
                return string.Empty;
            }

            //read from the data the value of the variable
            string directValue = Helper.JsonFetch.Fetch(this.Data, this.InputVariable.FunctionArguments[0]).ToString();

            //return the mapping for the variable value
            return this.Mapping[directValue].ToString();
        }
    }
}
