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

using ChainViews;
using Mutation.Mutators;
using UnityEngine;
using Visualizers;

namespace Mutation
{
    public class PrintStringMutator : DataMutator
    {
        private MutableField< string > m_StringToPrintField = new MutableField< string > { LiteralValue = "String" };
        [Controllable( LabelText = "String To Print" )]
        public MutableField< string > StringToPrintField
        {
            get { return m_StringToPrintField; }
        }

        protected override MutableObject Mutate( MutableObject mutable )
        {
            if (ChainView.Instance.IsEvaluating || !ChainView.Instance.IsBusy)    // Don't do this during load/save (during load, this method gets executed during schema propagation)
                Debug.Log(StringToPrintField.GetFirstValue(mutable));

            return mutable;
        }
    }
}