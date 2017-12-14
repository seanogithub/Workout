using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class WorkoutDataInit {

	public string InitData = @"
<SaveWorkoutData>
  <Workout>
    <WorkoutData>
      <Name>7 Minute</Name>
      <Description>7 Minute</Description>
      <Type>General</Type>
      <ExerciseArray>
        <Exercise>
          <ExerciseData>
            <Name>Jumping Jacks</Name>
            <Description>Jumping Jacks</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Wall Sit</Name>
            <Description>Wall Sit</Description>
            <Type>Body Weight</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Push Up - Military</Name>
            <Description>Push Up - Military</Description>
            <Type>Body Weight</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Abs - Crunch</Name>
            <Description>Abs - Crunch</Description>
            <Type>Body Weight</Type>
            <BodyPart>Abs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Step Up - Onto Chair</Name>
            <Description>Step Up - Onto Chair</Description>
            <Type>Body Weight</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Squat</Name>
            <Description>Squat</Description>
            <Type>Weights</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tricep Dips - Chair</Name>
            <Description>Tricep Dips - Chair</Description>
            <Type>Body Weight</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank</Name>
            <Description>Plank</Description>
            <Type>Yoga</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Run In Place, Knees Up</Name>
            <Description>Run In Place, Knees Up</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Lunge</Name>
            <Description>Lunge</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Push Up - Reach Up</Name>
            <Description>Push Up - Reach Up</Description>
            <Type>Body Weight</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank</Name>
            <Description>Plank</Description>
            <Type>Yoga</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
        </Exercise>
      </ExerciseArray>
    </WorkoutData>
    <WorkoutData>
      <Name>7 Minute - Advanced</Name>
      <Description>7 Minute - Advanced</Description>
      <Type>General</Type>
      <ExerciseArray>
        <Exercise>
          <ExerciseData>
            <Name>Lunge - Rotate 90, Reach Up</Name>
            <Description>Lunge - Rotate 90, Reach Up</Description>
            <Type>Body Weight</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Side Tri Rise - Reach Up</Name>
            <Description>Side Tri Rise - Reach Up</Description>
            <Type>Body Weight</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Push Up - Row - Burpee</Name>
            <Description>Push Up - Row - Burpee</Description>
            <Type>Body Weight</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>60</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Side Tri Rise - Reach Up</Name>
            <Description>Side Tri Rise - Reach Up</Description>
            <Type>Body Weight</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Single Leg Dead Lift To Curl Press</Name>
            <Description>Single Leg Dead Lift To Curl Press</Description>
            <Type>Weights</Type>
            <BodyPart>Body</BodyPart>
            <Weight>10</Weight>
            <Reps>15</Reps>
            <Time>60</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank - Arm Lift</Name>
            <Description>Plank - Arm Lift</Description>
            <Type>Yoga</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Lunge - Lateral To Tricep Extension</Name>
            <Description>Lunge - Lateral To Tricep Extension</Description>
            <Type>Weights</Type>
            <BodyPart>Body</BodyPart>
            <Weight>10</Weight>
            <Reps>15</Reps>
            <Time>60</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Row - Bent Over, One Arm</Name>
            <Description>Row - Bent Over, One Arm</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>10</Weight>
            <Reps>15</Reps>
            <Time>60</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
        </Exercise>
      </ExerciseArray>
    </WorkoutData>
    <WorkoutData>
      <Name>Arms and Shoulders</Name>
      <Description>Arms and Shoulders</Description>
      <Type>General</Type>
      <ExerciseArray>
        <Exercise>
          <ExerciseData>
            <Name>Alternating Shoulder Press</Name>
            <Description>Alternating Shoulder Press</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>20</Weight>
            <Reps>10</Reps>
            <Time>50</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Bicep Curls - In and Out</Name>
            <Description>Bicep Curls - In and Out</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>15</Weight>
            <Reps>8</Reps>
            <Time>40</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tricep Kick Backs - Two Arm</Name>
            <Description>Tricep Kick Backs - Two Arm</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>20</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Alternating Shoulder Press</Name>
            <Description>Alternating Shoulder Press</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>20</Weight>
            <Reps>10</Reps>
            <Time>50</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Bicep Curls - In and Out</Name>
            <Description>Bicep Curls - In and Out</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>15</Weight>
            <Reps>8</Reps>
            <Time>40</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tricep Kick Backs - Two Arm</Name>
            <Description>Tricep Kick Backs - Two Arm</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>20</Weight>
            <Reps>12</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Rest Time</Name>
            <Description>Rest Time</Description>
            <Type>Stretch</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Deep Swimmers Press</Name>
            <Description>Deep Swimmers Press</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>20</Weight>
            <Reps>10</Reps>
            <Time>50</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Bicep Curls - Concentration</Name>
            <Description>Bicep Curls - Concentration</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>15</Weight>
            <Reps>10</Reps>
            <Time>45</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tricep Extention - Standing</Name>
            <Description>Tricep Extention - Standing</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>15</Weight>
            <Reps>10</Reps>
            <Time>40</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Deep Swimmers Press</Name>
            <Description>Deep Swimmers Press</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>20</Weight>
            <Reps>10</Reps>
            <Time>50</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Bicep Curls - Concentration</Name>
            <Description>Bicep Curls - Concentration</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>15</Weight>
            <Reps>10</Reps>
            <Time>45</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tricep Extention - Standing</Name>
            <Description>Tricep Extention - Standing</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>15</Weight>
            <Reps>10</Reps>
            <Time>40</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Rest Time</Name>
            <Description>Rest Time</Description>
            <Type>Stretch</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Upright Rows</Name>
            <Description>Upright Rows</Description>
            <Type>General</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>20</Weight>
            <Reps>10</Reps>
            <Time>45</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Static Arm Curls</Name>
            <Description>Static Arm Curls</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>15</Weight>
            <Reps>4</Reps>
            <Time>8</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Static Arm Curls</Name>
            <Description>Static Arm Curls</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>15</Weight>
            <Reps>4</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Static Arm Curls</Name>
            <Description>Static Arm Curls</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>15</Weight>
            <Reps>4</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Static Arm Curls</Name>
            <Description>Static Arm Curls</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>15</Weight>
            <Reps>4</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Flip Grip Twist Tricep Kick Back</Name>
            <Description>Flip Grip Twist Tricep Kick Back</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>20</Weight>
            <Reps>10</Reps>
            <Time>40</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Upright Rows</Name>
            <Description>Upright Rows</Description>
            <Type>General</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>20</Weight>
            <Reps>10</Reps>
            <Time>45</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Static Arm Curls</Name>
            <Description>Static Arm Curls</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>15</Weight>
            <Reps>4</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Static Arm Curls</Name>
            <Description>Static Arm Curls</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>15</Weight>
            <Reps>4</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Static Arm Curls</Name>
            <Description>Static Arm Curls</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>15</Weight>
            <Reps>4</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Static Arm Curls</Name>
            <Description>Static Arm Curls</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>15</Weight>
            <Reps>4</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Flip Grip Twist Tricep Kick Back</Name>
            <Description>Flip Grip Twist Tricep Kick Back</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>20</Weight>
            <Reps>10</Reps>
            <Time>40</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Rest Time</Name>
            <Description>Rest Time</Description>
            <Type>Stretch</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Shoulder Fly</Name>
            <Description>Shoulder Fly</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>15</Weight>
            <Reps>16</Reps>
            <Time>45</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Bicep Curls - Crouching</Name>
            <Description>Bicep Curls - Crouching</Description>
            <Type>General</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>20</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tricep Extension - Laying Down</Name>
            <Description>Tricep Extension - Laying Down</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>20</Weight>
            <Reps>12</Reps>
            <Time>40</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Shoulder Fly</Name>
            <Description>Shoulder Fly</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>15</Weight>
            <Reps>16</Reps>
            <Time>45</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Bicep Curls - Crouching</Name>
            <Description>Bicep Curls - Crouching</Description>
            <Type>General</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>20</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tricep Extension - Laying Down</Name>
            <Description>Tricep Extension - Laying Down</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>20</Weight>
            <Reps>12</Reps>
            <Time>40</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Rest Time</Name>
            <Description>Rest Time</Description>
            <Type>Stretch</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Shoulder Fly</Name>
            <Description>Shoulder Fly</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>15</Weight>
            <Reps>16</Reps>
            <Time>40</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Condon Curls</Name>
            <Description>Condon Curls</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>20</Weight>
            <Reps>10</Reps>
            <Time>40</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tricep Extension - Laying Down</Name>
            <Description>Tricep Extension - Laying Down</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>20</Weight>
            <Reps>12</Reps>
            <Time>40</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Shoulder Fly</Name>
            <Description>Shoulder Fly</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>15</Weight>
            <Reps>16</Reps>
            <Time>40</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Condon Curls</Name>
            <Description>Condon Curls</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>20</Weight>
            <Reps>10</Reps>
            <Time>40</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tricep Extension - Laying Down</Name>
            <Description>Tricep Extension - Laying Down</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>20</Weight>
            <Reps>12</Reps>
            <Time>40</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
        </Exercise>
      </ExerciseArray>
    </WorkoutData>
    <WorkoutData>
      <Name>Cardio HIIT - Easy</Name>
      <Description>Cardio HIIT - Easy</Description>
      <Type>Cardio</Type>
      <ExerciseArray>
        <Exercise>
          <ExerciseData>
            <Name>Walk In Place Knees Up</Name>
            <Description>Walk In Place Knees Up</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Jump, Side To Side</Name>
            <Description>Jump, Side To Side</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Walk In Place Knees Up</Name>
            <Description>Walk In Place Knees Up</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Burpee</Name>
            <Description>Burpee</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Walk In Place Knees Up</Name>
            <Description>Walk In Place Knees Up</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Burpee - Push Up</Name>
            <Description>Burpee - Push Up</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Walk In Place Knees Up</Name>
            <Description>Walk In Place Knees Up</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Jumping Jacks</Name>
            <Description>Jumping Jacks</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Walk In Place Knees Up</Name>
            <Description>Walk In Place Knees Up</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Squat, Hop</Name>
            <Description>Squat, Hop</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Walk In Place Knees Up</Name>
            <Description>Walk In Place Knees Up</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Steam Engine</Name>
            <Description>Steam Engine</Description>
            <Type>Cardio-Intense</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Walk In Place Knees Up</Name>
            <Description>Walk In Place Knees Up</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tires</Name>
            <Description>Tires</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Walk In Place Knees Up</Name>
            <Description>Walk In Place Knees Up</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
        </Exercise>
      </ExerciseArray>
    </WorkoutData>
    <WorkoutData>
      <Name>Chest and Back</Name>
      <Description>Chest and Back</Description>
      <Type>General</Type>
      <ExerciseArray>
        <Exercise>
          <ExerciseData>
            <Name>Push Ups</Name>
            <Description>Push Up Description</Description>
            <Type>Body Weight</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Pull Up - Wide Front</Name>
            <Description>Pull Up - Wide Front</Description>
            <Type>Body Weight</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>8</Reps>
            <Time>40</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Push Up - Military</Name>
            <Description>Push Up - Military</Description>
            <Type>Body Weight</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Pull Up - Reverse Grip</Name>
            <Description>Pull Up - Reverse Grip</Description>
            <Type>Body Weight</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>8</Reps>
            <Time>40</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Rest Time</Name>
            <Description>Rest Time</Description>
            <Type>Stretch</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Push Up - Wide</Name>
            <Description>Push Up - Wide</Description>
            <Type>Body Weight</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Pull Up - Close Grip Over Hand</Name>
            <Description>Pull Up - Close Grip Over Hand</Description>
            <Type>Body Weight</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>8</Reps>
            <Time>40</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Push Up - Staggered Hands</Name>
            <Description>Push Up - Staggered Hands</Description>
            <Type>Body Weight</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Heavy Pants</Name>
            <Description>Heavy Pants</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>25</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Rest Time</Name>
            <Description>Rest Time</Description>
            <Type>Stretch</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Push Up - Triangle</Name>
            <Description>Push Up - Triangle</Description>
            <Type>Body Weight</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Lawnmower</Name>
            <Description>Lawnmower</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>25</Weight>
            <Reps>12</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Lawnmower</Name>
            <Description>Lawnmower</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>25</Weight>
            <Reps>12</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Push Up - Military</Name>
            <Description>Push Up - Military</Description>
            <Type>Body Weight</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Back Fly</Name>
            <Description>Back Fly</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>20</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Rest Time</Name>
            <Description>Rest Time</Description>
            <Type>Stretch</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Pull Up - Wide Front</Name>
            <Description>Pull Up - Wide Front</Description>
            <Type>Body Weight</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>8</Reps>
            <Time>40</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Push Ups</Name>
            <Description>Push Up Description</Description>
            <Type>Body Weight</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Pull Up - Reverse Grip</Name>
            <Description>Pull Up - Reverse Grip</Description>
            <Type>Body Weight</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>8</Reps>
            <Time>40</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Push Up - Military</Name>
            <Description>Push Up - Military</Description>
            <Type>Body Weight</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Rest Time</Name>
            <Description>Rest Time</Description>
            <Type>Stretch</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Pull Up - Close Grip Over Hand</Name>
            <Description>Pull Up - Close Grip Over Hand</Description>
            <Type>Body Weight</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>8</Reps>
            <Time>40</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Push Up - Wide</Name>
            <Description>Push Up - Wide</Description>
            <Type>Body Weight</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Heavy Pants</Name>
            <Description>Heavy Pants</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>25</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Push Up - Staggered Hands</Name>
            <Description>Push Up - Staggered Hands</Description>
            <Type>Body Weight</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Rest Time</Name>
            <Description>Rest Time</Description>
            <Type>Stretch</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Lawnmower</Name>
            <Description>Lawnmower</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>25</Weight>
            <Reps>12</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Lawnmower</Name>
            <Description>Lawnmower</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>25</Weight>
            <Reps>12</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Push Up - Triangle</Name>
            <Description>Push Up - Triangle</Description>
            <Type>Body Weight</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Back Fly</Name>
            <Description>Back Fly</Description>
            <Type>Weights</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>15</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Push Up - Military</Name>
            <Description>Push Up - Military</Description>
            <Type>Body Weight</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
        </Exercise>
      </ExerciseArray>
    </WorkoutData>
    <WorkoutData>
      <Name>Core</Name>
      <Description>core</Description>
      <Type>General</Type>
      <ExerciseArray>
        <Exercise>
          <ExerciseData>
            <Name>Push Up - Staggered Hands</Name>
            <Description>Push Up - Staggered Hands</Description>
            <Type>Body Weight</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Push Up - Staggered Hands</Name>
            <Description>Push Up - Staggered Hands</Description>
            <Type>Body Weight</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Superman</Name>
            <Description>Superman</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Banana</Name>
            <Description>Banana</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Superman</Name>
            <Description>Superman</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Banana</Name>
            <Description>Banana</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Superman</Name>
            <Description>Superman</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Banana</Name>
            <Description>Banana</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Superman</Name>
            <Description>Superman</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Banana</Name>
            <Description>Banana</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Squat Run</Name>
            <Description>Squat Run</Description>
            <Type>Cardio-Intense</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Squat Run</Name>
            <Description>Squat Run</Description>
            <Type>Cardio-Intense</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Push Up - Sphinx</Name>
            <Description>Push Up - Sphinx</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>8</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Bow</Name>
            <Description>Bow</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Boat</Name>
            <Description>Boat</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Bow</Name>
            <Description>Bow</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Boat</Name>
            <Description>Boat</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Bow</Name>
            <Description>Bow</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Boat</Name>
            <Description>Boat</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Lunge and Reach</Name>
            <Description>Lunge and Reach</Description>
            <Type>Weights</Type>
            <BodyPart>Body</BodyPart>
            <Weight>10</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Lunge and Reach</Name>
            <Description>Lunge and Reach</Description>
            <Type>Weights</Type>
            <BodyPart>Body</BodyPart>
            <Weight>10</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Rest Time</Name>
            <Description>Rest Time</Description>
            <Type>Stretch</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Push Up - Prison Cell</Name>
            <Description>Push Up - Prison Cell</Description>
            <Type>Body Weight</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>10</Reps>
            <Time>80</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Side Hip Rise</Name>
            <Description>Side Hip Rise</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>12</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Side Hip Rise</Name>
            <Description>Side Hip Rise</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>12</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Squat Cross Express</Name>
            <Description>Squat Cross Express</Description>
            <Type>Cardio-Intense</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>30</Reps>
            <Time>60</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank - Run</Name>
            <Description>Plank - Run</Description>
            <Type>Yoga</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Push Ups</Name>
            <Description>Push Up Description</Description>
            <Type>Body Weight</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Push Up - Wide</Name>
            <Description>Push Up - Wide</Description>
            <Type>Body Weight</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Superman</Name>
            <Description>Superman</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Banana</Name>
            <Description>Banana</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Superman</Name>
            <Description>Superman</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Banana</Name>
            <Description>Banana</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Superman</Name>
            <Description>Superman</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Banana</Name>
            <Description>Banana</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tires</Name>
            <Description>Tires</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Rest Time</Name>
            <Description>Rest Time</Description>
            <Type>Stretch</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Push Up - Reach Up</Name>
            <Description>Push Up - Reach Up</Description>
            <Type>Body Weight</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>10</Reps>
            <Time>60</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Steam Engine</Name>
            <Description>Steam Engine</Description>
            <Type>Cardio-Intense</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>50</Reps>
            <Time>90</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
        </Exercise>
      </ExerciseArray>
    </WorkoutData>
    <WorkoutData>
      <Name>Fighting, Plyo, Core</Name>
      <Description>Fighting, Plyo, Core</Description>
      <Type>General</Type>
      <ExerciseArray>
        <Exercise>
          <ExerciseData>
            <Name>Ball Kick</Name>
            <Description>Ball Kick</Description>
            <Type>Fighting</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>20</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Ball Kick</Name>
            <Description>Ball Kick</Description>
            <Type>Fighting</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>20</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Hook, Upper Cut, Side Kick</Name>
            <Description>Hook, Upper Cut, Side Kick</Description>
            <Type>Fighting</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>15</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Hook, Upper Cut, Side Kick</Name>
            <Description>Hook, Upper Cut, Side Kick</Description>
            <Type>Fighting</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>15</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Knuckles, Ball Kick, Back Kick</Name>
            <Description>Knuckles, Ball Kick, Back Kick</Description>
            <Type>Fighting</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>15</Reps>
            <Time>50</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Knuckles, Ball Kick, Back Kick</Name>
            <Description>Knuckles, Ball Kick, Back Kick</Description>
            <Type>Fighting</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>15</Reps>
            <Time>50</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Jab, Cross, Hook, Upper Cut</Name>
            <Description>Jab, Cross, Hook, Upper Cut</Description>
            <Type>Fighting</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>15</Reps>
            <Time>60</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Jab, Cross, Hook, Upper Cut</Name>
            <Description>Jab, Cross, Hook, Upper Cut</Description>
            <Type>Fighting</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>15</Reps>
            <Time>60</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Ball Kick, Side Kick, Back Kick</Name>
            <Description>Ball Kick, Side Kick, Back Kick</Description>
            <Type>Fighting</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>6</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Ball Kick, Side Kick, Back Kick</Name>
            <Description>Ball Kick, Side Kick, Back Kick</Description>
            <Type>Fighting</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>6</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Rest Time</Name>
            <Description>Rest Time</Description>
            <Type>Stretch</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Airborne Heisman</Name>
            <Description>Airborne Heisman</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>15</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Swing Kicks</Name>
            <Description>Swing Kicks</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Jump Shot</Name>
            <Description>Jump Shot</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>15</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tires</Name>
            <Description>Tires</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Jumping Jacks</Name>
            <Description>Jumping Jacks</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Airborne Heisman</Name>
            <Description>Airborne Heisman</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>15</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Swing Kicks</Name>
            <Description>Swing Kicks</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>10</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Jump Shot</Name>
            <Description>Jump Shot</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>15</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tires</Name>
            <Description>Tires</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Jumping Jacks</Name>
            <Description>Jumping Jacks</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Rest Time</Name>
            <Description>Rest Time</Description>
            <Type>Stretch</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Squat Cross Express</Name>
            <Description>Squat Cross Express</Description>
            <Type>Cardio-Intense</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>30</Reps>
            <Time>50</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Steam Engine</Name>
            <Description>Steam Engine</Description>
            <Type>Cardio-Intense</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>50</Reps>
            <Time>90</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Squat Run</Name>
            <Description>Squat Run</Description>
            <Type>Cardio-Intense</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Squat Run</Name>
            <Description>Squat Run</Description>
            <Type>Cardio-Intense</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Superman</Name>
            <Description>Superman</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Banana</Name>
            <Description>Banana</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Superman</Name>
            <Description>Superman</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Banana</Name>
            <Description>Banana</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Superman</Name>
            <Description>Superman</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Banana</Name>
            <Description>Banana</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Superman</Name>
            <Description>Superman</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Banana</Name>
            <Description>Banana</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Superman</Name>
            <Description>Superman</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Banana</Name>
            <Description>Banana</Description>
            <Type>Body Weight</Type>
            <BodyPart>Core</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
        </Exercise>
      </ExerciseArray>
    </WorkoutData>
    <WorkoutData>
      <Name>Warm Up Arms</Name>
      <Description>Warm Up Arms</Description>
      <Type>General</Type>
      <ExerciseArray>
        <Exercise>
          <ExerciseData>
            <Name>Walk In Place Knees Up</Name>
            <Description>Walk In Place Knees Up</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Run In Place</Name>
            <Description>Run In Place</Description>
            <Type>Cardio-Intense</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Run In Place Knees Down</Name>
            <Description>Run In Place Knees Down</Description>
            <Type>Cardio-Intense</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Run In Place Wide Legs</Name>
            <Description>Run In Place Wide Legs</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Jumping Jacks</Name>
            <Description>Jumping Jacks</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Lunge</Name>
            <Description>Lunge</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Head Rolls</Name>
            <Description>Head Rolls</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>6</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Shoulder Rolls</Name>
            <Description>Shoulder Rolls</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Shoulder Rolls</Name>
            <Description>Shoulder Rolls</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Chest Stretch</Name>
            <Description>Chest Stretch</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Chest</BodyPart>
            <Weight>0</Weight>
            <Reps>3</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Arm Circles Small Forward</Name>
            <Description>Arm Circles Small Forward</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Arm Circles Small Back</Name>
            <Description>Arm Circles Small Back</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Arm Circles Big Forward</Name>
            <Description>Arm Circles Big Forward</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Arm Circles Big Back</Name>
            <Description>Arm Circles Big Back</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Arm Shakers</Name>
            <Description>Arm Shakers</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>15</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Arm Hugs</Name>
            <Description>Arm Hugs</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>15</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>One Arm Back Stroke</Name>
            <Description>One Arm Back Stroke</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>One Arm Back Stroke</Name>
            <Description>One Arm Back Stroke</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Two Arm Reachers</Name>
            <Description>Two Arm Reachers</Description>
            <Type>Stretch</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>4</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tricep Stretch Under Chin</Name>
            <Description>Tricep Stretch Under Chin</Description>
            <Type>Stretch</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>15</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tricep Stretch Over Head</Name>
            <Description>Tricep Stretch Over Head</Description>
            <Type>Stretch</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>15</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tricep Stretch Under Chin</Name>
            <Description>Tricep Stretch Under Chin</Description>
            <Type>Stretch</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>15</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tricep Stretch Over Head</Name>
            <Description>Tricep Stretch Over Head</Description>
            <Type>Stretch</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>15</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
        </Exercise>
      </ExerciseArray>
    </WorkoutData>
    <WorkoutData>
      <Name>Warm Up Core</Name>
      <Description>Warm Up Core</Description>
      <Type>General</Type>
      <ExerciseArray>
        <Exercise>
          <ExerciseData>
            <Name>Head Rolls</Name>
            <Description>Head Rolls</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>6</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Chest Stretch</Name>
            <Description>Chest Stretch</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Chest</BodyPart>
            <Weight>0</Weight>
            <Reps>3</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tapas Stretch</Name>
            <Description>Tapas Stretch</Description>
            <Type>Stretch</Type>
            <BodyPart>Chest</BodyPart>
            <Weight>0</Weight>
            <Reps>3</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Arm Shakers</Name>
            <Description>Arm Shakers</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>15</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Arm Hugs</Name>
            <Description>Arm Hugs</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>15</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Two Arm Reachers</Name>
            <Description>Two Arm Reachers</Description>
            <Type>Stretch</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Walk In Place Knees Up</Name>
            <Description>Walk In Place Knees Up</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Run In Place</Name>
            <Description>Run In Place</Description>
            <Type>Cardio-Intense</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Run In Place, Knees Up</Name>
            <Description>Run In Place, Knees Up</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Run In Place Wide Legs</Name>
            <Description>Run In Place Wide Legs</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Run In Place Knees Down</Name>
            <Description>Run In Place Knees Down</Description>
            <Type>Cardio-Intense</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Jumping Jacks</Name>
            <Description>Jumping Jacks</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Hamstring Stretch Wide Legs</Name>
            <Description>Hamstring Stretch Wide Legs</Description>
            <Type>Stretch</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Hamstring Stretch One Foot Forward</Name>
            <Description>Hamstring Stretch One Foot Forward</Description>
            <Type>Stretch</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Hamstring Stretch One Foot Forward</Name>
            <Description>Hamstring Stretch One Foot Forward</Description>
            <Type>Stretch</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Standing Quad Stretch</Name>
            <Description>Standing Quad Stretch</Description>
            <Type>Stretch</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Standing Quad Stretch</Name>
            <Description>Standing Quad Stretch</Description>
            <Type>Stretch</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
        </Exercise>
      </ExerciseArray>
    </WorkoutData>
    <WorkoutData>
      <Name>Warm Up Yoga</Name>
      <Description>Warm Up Yoga</Description>
      <Type>General</Type>
      <ExerciseArray>
        <Exercise>
          <ExerciseData>
            <Name>Run In Place</Name>
            <Description>Run In Place</Description>
            <Type>Cardio-Intense</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Run In Place Knees Down</Name>
            <Description>Run In Place Knees Down</Description>
            <Type>Cardio-Intense</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Jump Rope</Name>
            <Description>Jump Rope</Description>
            <Type>Cardio-Light</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Jumping Jacks</Name>
            <Description>Jumping Jacks</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Hamstring Stretch Wide Legs</Name>
            <Description>Hamstring Stretch Wide Legs</Description>
            <Type>Stretch</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Hamstring Stretch One Foot Forward</Name>
            <Description>Hamstring Stretch One Foot Forward</Description>
            <Type>Stretch</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Hamstring Stretch One Foot Forward</Name>
            <Description>Hamstring Stretch One Foot Forward</Description>
            <Type>Stretch</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Standing Quad Stretch</Name>
            <Description>Standing Quad Stretch</Description>
            <Type>Stretch</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Standing Quad Stretch</Name>
            <Description>Standing Quad Stretch</Description>
            <Type>Stretch</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Sun Salutation</Name>
            <Description>Sun Salutation</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank</Name>
            <Description>Plank</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Upward Dog</Name>
            <Description>Upward Dog</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank</Name>
            <Description>Plank</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Downward Dog</Name>
            <Description>Downward Dog</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Sun Salutation</Name>
            <Description>Sun Salutation</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank</Name>
            <Description>Plank</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Upward Dog</Name>
            <Description>Upward Dog</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank</Name>
            <Description>Plank</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Downward Dog</Name>
            <Description>Downward Dog</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Runners Pose</Name>
            <Description>Runners Pose</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank</Name>
            <Description>Plank</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Upward Dog</Name>
            <Description>Upward Dog</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank</Name>
            <Description>Plank</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Downward Dog</Name>
            <Description>Downward Dog</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Runners Pose</Name>
            <Description>Runners Pose</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank</Name>
            <Description>Plank</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Upward Dog</Name>
            <Description>Upward Dog</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank</Name>
            <Description>Plank</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Downward Dog</Name>
            <Description>Downward Dog</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Runners Pose</Name>
            <Description>Runners Pose</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Warrior One</Name>
            <Description>Warrior One</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Runners Pose</Name>
            <Description>Runners Pose</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank</Name>
            <Description>Plank</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Upward Dog</Name>
            <Description>Upward Dog</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank</Name>
            <Description>Plank</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Downward Dog</Name>
            <Description>Downward Dog</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Runners Pose</Name>
            <Description>Runners Pose</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Warrior One</Name>
            <Description>Warrior One</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Runners Pose</Name>
            <Description>Runners Pose</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank</Name>
            <Description>Plank</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Upward Dog</Name>
            <Description>Upward Dog</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank</Name>
            <Description>Plank</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Downward Dog</Name>
            <Description>Downward Dog</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Runners Pose</Name>
            <Description>Runners Pose</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Warrior One</Name>
            <Description>Warrior One</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Warrior Two</Name>
            <Description>Warrior Two</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Warrior One</Name>
            <Description>Warrior One</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Runners Pose</Name>
            <Description>Runners Pose</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank</Name>
            <Description>Plank</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Upward Dog</Name>
            <Description>Upward Dog</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank</Name>
            <Description>Plank</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Downward Dog</Name>
            <Description>Downward Dog</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Runners Pose</Name>
            <Description>Runners Pose</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Warrior One</Name>
            <Description>Warrior One</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Warrior Two</Name>
            <Description>Warrior Two</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Warrior One</Name>
            <Description>Warrior One</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Runners Pose</Name>
            <Description>Runners Pose</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank</Name>
            <Description>Plank</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Upward Dog</Name>
            <Description>Upward Dog</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank</Name>
            <Description>Plank</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Downward Dog</Name>
            <Description>Downward Dog</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Runners Pose</Name>
            <Description>Runners Pose</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Warrior One</Name>
            <Description>Warrior One</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Warrior Two</Name>
            <Description>Warrior Two</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Reverse Warrior</Name>
            <Description>Reverse Warrior</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Warrior Two</Name>
            <Description>Warrior Two</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Warrior One</Name>
            <Description>Warrior One</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Runners Pose</Name>
            <Description>Runners Pose</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank</Name>
            <Description>Plank</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Upward Dog</Name>
            <Description>Upward Dog</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank</Name>
            <Description>Plank</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Downward Dog</Name>
            <Description>Downward Dog</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Runners Pose</Name>
            <Description>Runners Pose</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Warrior One</Name>
            <Description>Warrior One</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Warrior Two</Name>
            <Description>Warrior Two</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Reverse Warrior</Name>
            <Description>Reverse Warrior</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Warrior Two</Name>
            <Description>Warrior Two</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Warrior One</Name>
            <Description>Warrior One</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Runners Pose</Name>
            <Description>Runners Pose</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Plank</Name>
            <Description>Plank</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>5</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Downward Dog</Name>
            <Description>Downward Dog</Description>
            <Type>Yoga</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
        </Exercise>
      </ExerciseArray>
    </WorkoutData>
    <WorkoutData>
      <Name>Warm Up, Chest and Back</Name>
      <Description>Warm Up, Chest and Back</Description>
      <Type>General</Type>
      <ExerciseArray>
        <Exercise>
          <ExerciseData>
            <Name>Walk In Place Knees Up</Name>
            <Description>Walk In Place Knees Up</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>true</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Run In Place</Name>
            <Description>Run In Place</Description>
            <Type>Cardio-Intense</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Run In Place Wide Legs</Name>
            <Description>Run In Place Wide Legs</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Run In Place Knees Down</Name>
            <Description>Run In Place Knees Down</Description>
            <Type>Cardio-Intense</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Jumping Jacks</Name>
            <Description>Jumping Jacks</Description>
            <Type>Cardio-Moderate</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Lunge</Name>
            <Description>Lunge</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Legs</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Head Rolls</Name>
            <Description>Head Rolls</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Body</BodyPart>
            <Weight>0</Weight>
            <Reps>6</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Chest Stretch</Name>
            <Description>Chest Stretch</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Chest</BodyPart>
            <Weight>0</Weight>
            <Reps>3</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tapas Stretch</Name>
            <Description>Tapas Stretch</Description>
            <Type>Stretch</Type>
            <BodyPart>Chest</BodyPart>
            <Weight>0</Weight>
            <Reps>3</Reps>
            <Time>30</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Arm Circles Small Forward</Name>
            <Description>Arm Circles Small Forward</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Arm Circles Small Back</Name>
            <Description>Arm Circles Small Back</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Arm Circles Big Forward</Name>
            <Description>Arm Circles Big Forward</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Arm Circles Big Back</Name>
            <Description>Arm Circles Big Back</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Arm Shakers</Name>
            <Description>Arm Shakers</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>15</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Arm Hugs</Name>
            <Description>Arm Hugs</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>15</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>One Arm Back Stroke</Name>
            <Description>One Arm Back Stroke</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>One Arm Back Stroke</Name>
            <Description>One Arm Back Stroke</Description>
            <Type>Warm-Up</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>10</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Two Arm Reachers</Name>
            <Description>Two Arm Reachers</Description>
            <Type>Stretch</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>20</Time>
            <RestTime>0</RestTime>
            <Side>None</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tricep Stretch Under Chin</Name>
            <Description>Tricep Stretch Under Chin</Description>
            <Type>Stretch</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>15</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tricep Stretch Over Head</Name>
            <Description>Tricep Stretch Over Head</Description>
            <Type>Stretch</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>15</Time>
            <RestTime>0</RestTime>
            <Side>Left</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tricep Stretch Under Chin</Name>
            <Description>Tricep Stretch Under Chin</Description>
            <Type>Stretch</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>15</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
          <ExerciseData>
            <Name>Tricep Stretch Over Head</Name>
            <Description>Tricep Stretch Over Head</Description>
            <Type>Stretch</Type>
            <BodyPart>Arms</BodyPart>
            <Weight>0</Weight>
            <Reps>0</Reps>
            <Time>15</Time>
            <RestTime>0</RestTime>
            <Side>Right</Side>
            <CountDownAtStart>false</CountDownAtStart>
            <NumAnimationFrames>-1</NumAnimationFrames>
          </ExerciseData>
        </Exercise>
      </ExerciseArray>
    </WorkoutData>
  </Workout>
			</SaveWorkoutData>
";
}
