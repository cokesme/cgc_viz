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

using System.Collections;
using Choreography.Recording;
using Choreography.Views;
using Newtonsoft.Json;
using UnityEngine;
using Utility;
using Visualizers;

namespace Choreography.Steps.Recording
{
    public class StartRecordingStep : Step
    {
        private bool m_TemporarilyDisable;

        [Controllable]
        [JsonIgnore]
        private bool TemporarilyDisable
        {
            get { return m_TemporarilyDisable; }
            set
            {
                m_TemporarilyDisable = value;
            }
        }


        private const string EndEventName = "End";

        public StartRecordingStep()
        {
            Router.AddEvent(EndEventName);
        }

        public override float BaseDuration
        {
            get { return 0.0f; }
        }

        protected override IEnumerator ExecuteStep()
        {
            if ( !TemporarilyDisable )
            {
                if ( !Timeline.IsSeeking )
                {
                    Debug.Log( "Starting recording!" );

                    var filename = CommandLineArgs.GetArgumentValue( "VideoFilename" );
                    if (string.IsNullOrEmpty(filename))
                        filename = "Choreography.mp4";

                    RecordingLord.StartRecording( filename );

                    TimelineViewBehaviour.Instance.NumRecordingsStartedThisPlayback++;
                }
            }

            Router.FireEvent(EndEventName);

            yield return null;
        }
    }
}
