// Copyright 2017 voidALPHA, Inc.
// This file is part of the Haxxis video generation system and is provided
// by voidALPHA in support of the Cyber Grand Challenge.
// Haxxis is free software: you can redistribute it and/or modify it under the terms
// of the GNU General Public License as published by the Free Software Foundation.
// Haxxis is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A
// PARTICULAR PURPOSE. See the GNU General Public License for more details.
// You should have received a copy of the GNU General Public License along with
// Haxxis. If not, see <http://www.gnu.org/licenses/>.

using System;
using Newtonsoft.Json;

namespace Visualizers
{
    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false, Inherited = true )]
    public class ControllableAttribute : JsonPropertyAttribute
    {
        public enum ConditionBehaviour
        {
            ShowHide,
            EnableDisable,
        }

        
        public string LabelText { get; set; }


        public string ConditionalPropertyName { get; set; }

        public bool InvertConditional { get; set; }

        
        public string ObservableEventName { get; set; }

        public string ValidValuesListName { get; set; }

        
        // Could be one of these for each state (met/not met) with all 4 (Hide, Show, En, Disable) options separate.
        public ConditionBehaviour ConditionalNotMetBehaviour { get; set; }



        public ControllableAttribute()
        {
            LabelText = string.Empty;

            ConditionalNotMetBehaviour = ConditionBehaviour.ShowHide;

            InvertConditional = false;
        }
    }
}
