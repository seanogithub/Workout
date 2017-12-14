using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ExerciseDataInit {

	public string InitData = @"
<SaveExerciseData>
  <Exercise>
    <ExerciseData>
      <Name>Abs - Bicycles</Name>
      <Description>Abs - Bicycles</Description>
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
      <Name>Abs - In and Outs</Name>
      <Description>Abs - In and Outs</Description>
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
      <Name>Abs - Scissor Kicks</Name>
      <Description>Abs - Scissor Kicks</Description>
      <Type>Body Weight</Type>
      <BodyPart>Abs</BodyPart>
      <Weight>0</Weight>
      <Reps>10</Reps>
      <Time>30</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Abs - V Up</Name>
      <Description>Abs - V Up</Description>
      <Type>Body Weight</Type>
      <BodyPart>Abs</BodyPart>
      <Weight>0</Weight>
      <Reps>12</Reps>
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
      <Name>Alternating Shoulder Press</Name>
      <Description>Alternating Shoulder Press</Description>
      <Type>Weights</Type>
      <BodyPart>Arms</BodyPart>
      <Weight>20</Weight>
      <Reps>20</Reps>
      <Time>50</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
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
      <Name>Back Roll</Name>
      <Description>Back Roll</Description>
      <Type>Body Weight</Type>
      <BodyPart>Body</BodyPart>
      <Weight>0</Weight>
      <Reps>15</Reps>
      <Time>60</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Ball Kick</Name>
      <Description>Ball Kick</Description>
      <Type>Fighting</Type>
      <BodyPart>Legs</BodyPart>
      <Weight>0</Weight>
      <Reps>20</Reps>
      <Time>30</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Ball Kick, Side Kick, Back Kick</Name>
      <Description>Ball Kick, Side Kick, Back Kick</Description>
      <Type>Fighting</Type>
      <BodyPart>Legs</BodyPart>
      <Weight>0</Weight>
      <Reps>6</Reps>
      <Time>30</Time>
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
      <Name>Bench Press</Name>
      <Description>Bench Press</Description>
      <Type>Weights</Type>
      <BodyPart>Chest</BodyPart>
      <Weight>100</Weight>
      <Reps>8</Reps>
      <Time>30</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Bench Press - Decline</Name>
      <Description>Bench Press - Decline</Description>
      <Type>Weights</Type>
      <BodyPart>Chest</BodyPart>
      <Weight>100</Weight>
      <Reps>8</Reps>
      <Time>30</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Bench Press - Dumbell</Name>
      <Description>Bench Press - Dumbell</Description>
      <Type>Weights</Type>
      <BodyPart>Chest</BodyPart>
      <Weight>35</Weight>
      <Reps>8</Reps>
      <Time>30</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Bench Press - Incline</Name>
      <Description>Bench Press - Incline</Description>
      <Type>Weights</Type>
      <BodyPart>Chest</BodyPart>
      <Weight>100</Weight>
      <Reps>8</Reps>
      <Time>30</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Bench Press - Wide Grip</Name>
      <Description>Bench Press - Wide Grip</Description>
      <Type>Weights</Type>
      <BodyPart>Chest</BodyPart>
      <Weight>100</Weight>
      <Reps>8</Reps>
      <Time>30</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Bicep Curls</Name>
      <Description>Bicep Curls Description</Description>
      <Type>Weights</Type>
      <BodyPart>Arms</BodyPart>
      <Weight>20</Weight>
      <Reps>10</Reps>
      <Time>7</Time>
      <RestTime>3</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Bicep Curls - Concentration</Name>
      <Description>Bicep Curls - Concentration</Description>
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
      <Name>Bicep Curls - Hammer</Name>
      <Description>Bicep Curls - Hammer</Description>
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
      <Name>Bicep Curls - Preacher</Name>
      <Description>Bicep Curls - Preacher</Description>
      <Type>Weights</Type>
      <BodyPart>Arms</BodyPart>
      <Weight>50</Weight>
      <Reps>10</Reps>
      <Time>30</Time>
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
      <Name>Burpee</Name>
      <Description>Burpee</Description>
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
      <Name>Burpee - Jump</Name>
      <Description>Burpee - Jump</Description>
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
      <Name>Burpee - Push Up</Name>
      <Description>Burpee - Push Up</Description>
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
      <Name>Burpee - Push Up, Jump</Name>
      <Description>Burpee - Push Up, Jump</Description>
      <Type>Cardio-Intense</Type>
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
      <Name>Chair Dips</Name>
      <Description>Chair Dips</Description>
      <Type>Body Weight</Type>
      <BodyPart>Arms</BodyPart>
      <Weight>0</Weight>
      <Reps>20</Reps>
      <Time>45</Time>
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
      <Name>Clean and Jerk</Name>
      <Description>Clean and Jerk</Description>
      <Type>Weights</Type>
      <BodyPart>Arms</BodyPart>
      <Weight>80</Weight>
      <Reps>8</Reps>
      <Time>60</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Cobra</Name>
      <Description>Cobra</Description>
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
      <Name>Dead Lift</Name>
      <Description>Dead Lift</Description>
      <Type>Weights</Type>
      <BodyPart>Back</BodyPart>
      <Weight>100</Weight>
      <Reps>5</Reps>
      <Time>30</Time>
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
      <Reps>12</Reps>
      <Time>50</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
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
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Flip Grip Twist Tricep Kick Back</Name>
      <Description>Flip Grip Twist Tricep Kick Back</Description>
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
      <Name>Fly - Dumbell</Name>
      <Description>Fly - Dumbell</Description>
      <Type>Weights</Type>
      <BodyPart>Arms</BodyPart>
      <Weight>35</Weight>
      <Reps>8</Reps>
      <Time>30</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Fly - Dumbell Decline</Name>
      <Description>Fly - Dumbell Decline</Description>
      <Type>Weights</Type>
      <BodyPart>Arms</BodyPart>
      <Weight>35</Weight>
      <Reps>8</Reps>
      <Time>30</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Fly - Dumbell Incline</Name>
      <Description>Fly - Dumbell Incline</Description>
      <Type>Weights</Type>
      <BodyPart>Arms</BodyPart>
      <Weight>35</Weight>
      <Reps>8</Reps>
      <Time>30</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Hamstring Stretch One Foot Forward</Name>
      <Description>Hamstring Stretch One Foot Forward</Description>
      <Type>Stretch</Type>
      <BodyPart>Legs</BodyPart>
      <Weight>0</Weight>
      <Reps>0</Reps>
      <Time>60</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
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
      <CountDownAtStart>true</CountDownAtStart>
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
      <Name>Hook, Upper Cut, Side Kick</Name>
      <Description>Hook, Upper Cut, Side Kick</Description>
      <Type>Fighting</Type>
      <BodyPart>Body</BodyPart>
      <Weight>0</Weight>
      <Reps>15</Reps>
      <Time>30</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Jab</Name>
      <Description>Jab</Description>
      <Type>Fighting</Type>
      <BodyPart>Arms</BodyPart>
      <Weight>0</Weight>
      <Reps>25</Reps>
      <Time>30</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Jab, Cross, Hook, Upper Cut</Name>
      <Description>Jab, Cross, Hook, Upper Cut</Description>
      <Type>Fighting</Type>
      <BodyPart>Arms</BodyPart>
      <Weight>0</Weight>
      <Reps>15</Reps>
      <Time>60</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Jog In Place</Name>
      <Description>Jog In Place</Description>
      <Type>Cardio-Light</Type>
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
      <Name>Jump Rope</Name>
      <Description>Jump Rope</Description>
      <Type>Cardio-Light</Type>
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
      <Name>Jump Rope, Forward, Back</Name>
      <Description>Jump Rope, Forward, Back</Description>
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
      <Name>Jump Shot</Name>
      <Description>Jump Shot</Description>
      <Type>Cardio-Moderate</Type>
      <BodyPart>Body</BodyPart>
      <Weight>0</Weight>
      <Reps>15</Reps>
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
      <Name>Jump, Touch Thigh</Name>
      <Description>Jump, Tough Thigh</Description>
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
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Jumping Jacks - Double</Name>
      <Description>Jumping Jacks - Double</Description>
      <Type>Cardio-Intense</Type>
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
      <Name>Knuckles, Ball Kick, Back Kick</Name>
      <Description>Knuckles, Ball Kick, Back Kick</Description>
      <Type>Fighting</Type>
      <BodyPart>Body</BodyPart>
      <Weight>0</Weight>
      <Reps>15</Reps>
      <Time>50</Time>
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
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Laying Down Tricep Extensions</Name>
      <Description>Laying Down Tricep Extensions</Description>
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
      <Name>Lunge - Lateral To Tricep Extension</Name>
      <Description>Lunge - Lateral To Tricep Extension</Description>
      <Type>Weights</Type>
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
      <Name>Lunge - Rotate 90, Reach Up</Name>
      <Description>Lunge - Rotate 90, Reach Up</Description>
      <Type>Body Weight</Type>
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
      <Name>Lunge - Side to Side</Name>
      <Description>Lunge - Side to Side</Description>
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
      <Name>Lunge - Side to Side, Hop</Name>
      <Description>Lunge - Side to Side, Hop</Description>
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
      <Name>Lunge and Reach</Name>
      <Description>Lunge and Reach</Description>
      <Type>Weights</Type>
      <BodyPart>Body</BodyPart>
      <Weight>10</Weight>
      <Reps>10</Reps>
      <Time>30</Time>
      <RestTime>0</RestTime>
      <Side>Left</Side>
      <CountDownAtStart>false</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Mountain Climbers</Name>
      <Description>Mountain Climbers</Description>
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
      <Name>One Arm Back Stroke</Name>
      <Description>One Arm Back Stroke</Description>
      <Type>Warm-Up</Type>
      <BodyPart>Arms</BodyPart>
      <Weight>0</Weight>
      <Reps>0</Reps>
      <Time>10</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>false</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>One Arm Concentration Curl</Name>
      <Description>One Arm Concentration Curl</Description>
      <Type>Weights</Type>
      <BodyPart>Arms</BodyPart>
      <Weight>15</Weight>
      <Reps>20</Reps>
      <Time>45</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>One Arm Reachers</Name>
      <Description>One Arm Reachers</Description>
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
      <Name>Plank - Elbows</Name>
      <Description>Plank - Elbows</Description>
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
      <Name>Plank - Side</Name>
      <Description>Plank - Side</Description>
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
      <Name>Plank - Spider</Name>
      <Description>Plank - Spider</Description>
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
      <Name>Plank Push Up</Name>
      <Description>Plank Push Up</Description>
      <Type>Yoga</Type>
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
      <Name>Pull Up</Name>
      <Description>Pull Up</Description>
      <Type>Body Weight</Type>
      <BodyPart>Arms</BodyPart>
      <Weight>0</Weight>
      <Reps>10</Reps>
      <Time>50</Time>
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
      <Reps>10</Reps>
      <Time>50</Time>
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
      <Reps>10</Reps>
      <Time>50</Time>
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
      <Reps>10</Reps>
      <Time>50</Time>
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
      <Name>Push Up - Sphinx</Name>
      <Description>Push Up - Sphinx</Description>
      <Type>Body Weight</Type>
      <BodyPart>Core</BodyPart>
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
      <Reps>15</Reps>
      <Time>60</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
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
      <Name>Push Ups</Name>
      <Description>Push Up Description</Description>
      <Type>Body Weight</Type>
      <BodyPart>Body</BodyPart>
      <Weight>0</Weight>
      <Reps>15</Reps>
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
      <Name>Reverse Warrior</Name>
      <Description>Reverse Warrior</Description>
      <Type>Yoga</Type>
      <BodyPart>Body</BodyPart>
      <Weight>0</Weight>
      <Reps>0</Reps>
      <Time>15</Time>
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
      <Weight>0</Weight>
      <Reps>0</Reps>
      <Time>60</Time>
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
      <Name>Runners Pose</Name>
      <Description>Runners Pose</Description>
      <Type>Yoga</Type>
      <BodyPart>Body</BodyPart>
      <Weight>0</Weight>
      <Reps>0</Reps>
      <Time>5</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Runners Stretch</Name>
      <Description>Runners Stretch</Description>
      <Type>Stretch</Type>
      <BodyPart>Legs</BodyPart>
      <Weight>0</Weight>
      <Reps>0</Reps>
      <Time>20</Time>
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
      <Weight>20</Weight>
      <Reps>16</Reps>
      <Time>60</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Shoulder Fly - Front</Name>
      <Description>Shoulder Fly - Front</Description>
      <Type>Weights</Type>
      <BodyPart>Arms</BodyPart>
      <Weight>20</Weight>
      <Reps>16</Reps>
      <Time>60</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Shoulder Fly - In and Out</Name>
      <Description>Shoulder Fly - In and Out</Description>
      <Type>Weights</Type>
      <BodyPart>Arms</BodyPart>
      <Weight>20</Weight>
      <Reps>16</Reps>
      <Time>60</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Shoulder Fly - Seated</Name>
      <Description>Shoulder Fly - Seated</Description>
      <Type>Weights</Type>
      <BodyPart>Arms</BodyPart>
      <Weight>20</Weight>
      <Reps>16</Reps>
      <Time>60</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
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
      <Name>Side Hip Rise</Name>
      <Description>Side Hip Rise</Description>
      <Type>Body Weight</Type>
      <BodyPart>Core</BodyPart>
      <Weight>0</Weight>
      <Reps>12</Reps>
      <Time>30</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>false</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Side Tri Rise</Name>
      <Description>Side Tri Rise</Description>
      <Type>Body Weight</Type>
      <BodyPart>Arms</BodyPart>
      <Weight>0</Weight>
      <Reps>16</Reps>
      <Time>40</Time>
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
      <Side>None</Side>
      <CountDownAtStart>false</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Single Leg Dead Lift To Curl Press</Name>
      <Description>Single Leg Dead Lift To Curl Press</Description>
      <Type>Weights</Type>
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
      <Name>Sit Up - Alternating</Name>
      <Description>Sit Up - Alternating</Description>
      <Type>Body Weight</Type>
      <BodyPart>Abs</BodyPart>
      <Weight>0</Weight>
      <Reps>30</Reps>
      <Time>60</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Sit Ups</Name>
      <Description>Sit Up Description</Description>
      <Type>Body Weight</Type>
      <BodyPart>Abs</BodyPart>
      <Weight>0</Weight>
      <Reps>40</Reps>
      <Time>30</Time>
      <RestTime>15</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Sprint In Place</Name>
      <Description>Sprint In Place</Description>
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
      <Name>Squat Run</Name>
      <Description>Squat Run</Description>
      <Type>Cardio-Intense</Type>
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
      <Name>Squat, Curtsey </Name>
      <Description>Curtsey</Description>
      <Type>Body Weight</Type>
      <BodyPart>Legs</BodyPart>
      <Weight>0</Weight>
      <Reps>10</Reps>
      <Time>20</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
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
      <Name>Squat, Oblique</Name>
      <Description>Oblique</Description>
      <Type>Cardio-Moderate</Type>
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
      <Name>Squat, Stand</Name>
      <Description>Squat, Stand</Description>
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
      <Name>Standing Quad Stretch</Name>
      <Description>Standing Quad Stretch</Description>
      <Type>Stretch</Type>
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
      <Name>Static Arm Curls</Name>
      <Description>Static Arm Curls</Description>
      <Type>Weights</Type>
      <BodyPart>Arms</BodyPart>
      <Weight>15</Weight>
      <Reps>4</Reps>
      <Time>10</Time>
      <RestTime>0</RestTime>
      <Side>Left</Side>
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
      <Name>Swing Kicks</Name>
      <Description>Swing Kicks</Description>
      <Type>Cardio-Moderate</Type>
      <BodyPart>Legs</BodyPart>
      <Weight>0</Weight>
      <Reps>20</Reps>
      <Time>30</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
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
      <Name>Tricep Kick Backs</Name>
      <Description>Tricep Kick Backs</Description>
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
      <Name>Tricep Kick Backs - Two Arm</Name>
      <Description>Tricep Kick Backs - Two Arm</Description>
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
      <Name>Upright Rows</Name>
      <Description>Upright Rows</Description>
      <Type>Weights</Type>
      <BodyPart>Arms</BodyPart>
      <Weight>20</Weight>
      <Reps>12</Reps>
      <Time>45</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
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
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Walk In Place</Name>
      <Description>Walk In Place</Description>
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
      <Name>Warrior One</Name>
      <Description>Warrior One</Description>
      <Type>Yoga</Type>
      <BodyPart>Body</BodyPart>
      <Weight>0</Weight>
      <Reps>0</Reps>
      <Time>15</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
    <ExerciseData>
      <Name>Warrior Two</Name>
      <Description>Warrior Two</Description>
      <Type>Yoga</Type>
      <BodyPart>Body</BodyPart>
      <Weight>0</Weight>
      <Reps>0</Reps>
      <Time>15</Time>
      <RestTime>0</RestTime>
      <Side>None</Side>
      <CountDownAtStart>true</CountDownAtStart>
      <NumAnimationFrames>-1</NumAnimationFrames>
    </ExerciseData>
  </Exercise>
</SaveExerciseData>
			";
}
