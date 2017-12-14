using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TrainingDataInit {

	public string InitData = @"
<SaveTrainingData>
  <Training>
    <TrainingData>
      <Name>Cardio, Weights</Name>
      <Description>Cardio, Weights</Description>
      <DayArray>
        <Day>
          <DayData>
            <Day>2015-02-21T06:24:29.7838916-08:00</Day>
            <DayWorkoutArray>
              <DayWorkoutData>
                <WorkoutName>Abs</WorkoutName>
                <WorkoutCompleted>false</WorkoutCompleted>
                <CompletedDateTime>2015-02-21T06:19:47.4724924-08:00</CompletedDateTime>
                <TotalWorkoutTime>0</TotalWorkoutTime>
                <TotalWorkoutWeight>0</TotalWorkoutWeight>
                <WorkoutScore>0</WorkoutScore>
              </DayWorkoutData>
              <DayWorkoutData>
                <WorkoutName>Warm Up Arms</WorkoutName>
                <WorkoutCompleted>false</WorkoutCompleted>
                <CompletedDateTime>2015-02-21T06:19:55.1345032-08:00</CompletedDateTime>
                <TotalWorkoutTime>0</TotalWorkoutTime>
                <TotalWorkoutWeight>0</TotalWorkoutWeight>
                <WorkoutScore>0</WorkoutScore>
              </DayWorkoutData>
            </DayWorkoutArray>
          </DayData>
          <DayData>
            <Day>2015-02-22T06:24:29.7938916-08:00</Day>
            <DayWorkoutArray>
              <DayWorkoutData>
                <WorkoutName>Cardio - 25 Minutes</WorkoutName>
                <WorkoutCompleted>false</WorkoutCompleted>
                <CompletedDateTime>2015-02-21T06:19:59.9755101-08:00</CompletedDateTime>
                <TotalWorkoutTime>0</TotalWorkoutTime>
                <TotalWorkoutWeight>0</TotalWorkoutWeight>
                <WorkoutScore>0</WorkoutScore>
              </DayWorkoutData>
            </DayWorkoutArray>
          </DayData>
          <DayData>
            <Day>2015-02-23T06:24:29.8038916-08:00</Day>
            <DayWorkoutArray>
              <DayWorkoutData>
                <WorkoutName>Fighting, Plyo, Core</WorkoutName>
                <WorkoutCompleted>false</WorkoutCompleted>
                <CompletedDateTime>2015-02-21T06:22:49.5657497-08:00</CompletedDateTime>
                <TotalWorkoutTime>0</TotalWorkoutTime>
                <TotalWorkoutWeight>0</TotalWorkoutWeight>
                <WorkoutScore>0</WorkoutScore>
              </DayWorkoutData>
              <DayWorkoutData>
                <WorkoutName>Arms and Shoulders</WorkoutName>
                <WorkoutCompleted>false</WorkoutCompleted>
                <CompletedDateTime>2015-02-21T06:22:54.687757-08:00</CompletedDateTime>
                <TotalWorkoutTime>0</TotalWorkoutTime>
                <TotalWorkoutWeight>0</TotalWorkoutWeight>
                <WorkoutScore>0</WorkoutScore>
              </DayWorkoutData>
            </DayWorkoutArray>
          </DayData>
        </Day>
      </DayArray>
      <Type>General</Type>
    </TrainingData>
    <TrainingData>
      <Name>Easy Cardio, Weights</Name>
      <Description>Easy Cardio, Weights</Description>
      <DayArray>
        <Day>
          <DayData>
            <Day>2016-02-21T06:48:52.4795033-08:00</Day>
            <DayWorkoutArray>
              <DayWorkoutData>
                <WorkoutName>Warm Up Yoga</WorkoutName>
                <WorkoutCompleted>false</WorkoutCompleted>
                <CompletedDateTime>2016-02-21T06:49:09.127646-08:00</CompletedDateTime>
                <TotalWorkoutTime>0</TotalWorkoutTime>
                <TotalWorkoutWeight>0</TotalWorkoutWeight>
                <WorkoutScore>0</WorkoutScore>
              </DayWorkoutData>
              <DayWorkoutData>
                <WorkoutName>Fighting, Plyo, Core</WorkoutName>
                <WorkoutCompleted>false</WorkoutCompleted>
                <CompletedDateTime>2016-02-21T06:49:11.3774543-08:00</CompletedDateTime>
                <TotalWorkoutTime>0</TotalWorkoutTime>
                <TotalWorkoutWeight>0</TotalWorkoutWeight>
                <WorkoutScore>0</WorkoutScore>
              </DayWorkoutData>
            </DayWorkoutArray>
          </DayData>
          <DayData>
            <Day>2016-02-21T06:49:13.3673874-08:00</Day>
            <DayWorkoutArray>
              <DayWorkoutData>
                <WorkoutName>Warm Up Arms</WorkoutName>
                <WorkoutCompleted>false</WorkoutCompleted>
                <CompletedDateTime>2016-02-21T06:49:28.1995372-08:00</CompletedDateTime>
                <TotalWorkoutTime>0</TotalWorkoutTime>
                <TotalWorkoutWeight>0</TotalWorkoutWeight>
                <WorkoutScore>0</WorkoutScore>
              </DayWorkoutData>
              <DayWorkoutData>
                <WorkoutName>Arms and Shoulders</WorkoutName>
                <WorkoutCompleted>false</WorkoutCompleted>
                <CompletedDateTime>2016-02-21T06:49:31.0472685-08:00</CompletedDateTime>
                <TotalWorkoutTime>0</TotalWorkoutTime>
                <TotalWorkoutWeight>0</TotalWorkoutWeight>
                <WorkoutScore>0</WorkoutScore>
              </DayWorkoutData>
            </DayWorkoutArray>
          </DayData>
          <DayData>
            <Day>2016-02-21T06:49:32.2831406-08:00</Day>
            <DayWorkoutArray />
          </DayData>
          <DayData>
            <Day>2016-02-21T06:50:02.0433728-08:00</Day>
            <DayWorkoutArray>
              <DayWorkoutData>
                <WorkoutName>Warm Up, Chest and Back</WorkoutName>
                <WorkoutCompleted>false</WorkoutCompleted>
                <CompletedDateTime>2016-02-21T06:50:17.0745087-08:00</CompletedDateTime>
                <TotalWorkoutTime>0</TotalWorkoutTime>
                <TotalWorkoutWeight>0</TotalWorkoutWeight>
                <WorkoutScore>0</WorkoutScore>
              </DayWorkoutData>
              <DayWorkoutData>
                <WorkoutName>Chest and Back</WorkoutName>
                <WorkoutCompleted>false</WorkoutCompleted>
                <CompletedDateTime>2016-02-21T06:50:21.0305918-08:00</CompletedDateTime>
                <TotalWorkoutTime>0</TotalWorkoutTime>
                <TotalWorkoutWeight>0</TotalWorkoutWeight>
                <WorkoutScore>0</WorkoutScore>
              </DayWorkoutData>
            </DayWorkoutArray>
          </DayData>
        </Day>
      </DayArray>
      <Type>General</Type>
    </TrainingData>
    <TrainingData>
      <Name>Yoga, Cardio</Name>
      <Description>Yoga, Cardio</Description>
      <DayArray>
        <Day>
          <DayData>
            <Day>2016-02-21T06:51:53.3658729-08:00</Day>
            <DayWorkoutArray>
              <DayWorkoutData>
                <WorkoutName>Warm Up Yoga</WorkoutName>
                <WorkoutCompleted>false</WorkoutCompleted>
                <CompletedDateTime>2016-02-21T06:51:54.0620098-08:00</CompletedDateTime>
                <TotalWorkoutTime>0</TotalWorkoutTime>
                <TotalWorkoutWeight>0</TotalWorkoutWeight>
                <WorkoutScore>0</WorkoutScore>
              </DayWorkoutData>
              <DayWorkoutData>
                <WorkoutName>Fighting, Plyo, Core</WorkoutName>
                <WorkoutCompleted>false</WorkoutCompleted>
                <CompletedDateTime>2016-02-21T06:52:07.09827-08:00</CompletedDateTime>
                <TotalWorkoutTime>0</TotalWorkoutTime>
                <TotalWorkoutWeight>0</TotalWorkoutWeight>
                <WorkoutScore>0</WorkoutScore>
              </DayWorkoutData>
            </DayWorkoutArray>
          </DayData>
        </Day>
      </DayArray>
      <Type>General</Type>
    </TrainingData>
  </Training>
</SaveTrainingData>
";
}
