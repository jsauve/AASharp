/*
Module : AARISETRANSITSET.CPP
Purpose: Implementation for the algorithms which obtain the Rise, Transit and Set times
Created: PJN / 29-12-2003
History: PJN / 15-10-2004 1. bValid variable is now correctly set in CAARiseTransitSet::Rise if the objects does 
                          actually rise and sets
         PJN / 28-03-2009 1. Fixed a bug in CAARiseTransitSet::Rise where the cyclical nature of a RA value was
                          not taken into account during the interpolation. In fact Meeus in the book even refers to
                          this issue as "Important remarks, 2."  on page 30 of the second edition. Basically when 
                          interpolating RA, we need to be careful that the 3 values are consistent with respect to 
                          each other when any one of them wraps around from 23H 59M 59S around to 0H 0M 0S. In this 
                          case, the RA has increased by 0H 0M 1S of RA instead of decreasing by 23H 59M 59S. Thanks 
                          to Corky Corcoran and Danny Flippo for both reporting this issue. 
                          2. Fixed a bug in the calculation of the parameter "H" in CAARiseTransitSet::Rise when
                          calculating the local hour angle of the body for the time of transit.
         PJN / 30-04-2009 1. Fixed a bug where the M values were not being constrained to between 0 and 1 in 
                          CAARiseTransitSet::Rise. Thanks to Matthew Yager for reporting this issue.
         PJN / 08-05-2011 1. Updated Rise method to return information for circumpolar object rather than returning
                          bValid = false for this type of object. In the case of a circumpolar object, the object 
                          does not rise or set on the day in question but will of course transit at a specific time.
                          This change means that you do not need to recall the method with a declination value to
                          get the transit time. In addition if an object never rises or sets, the method will still
                          return the transit time even though it occurs below the horizon by setting the 
                          bTransitAboveHorizon value to false. Note that this means that the "Transit" value will now
                          always include a valid vaslue. Also the method has been renamed to Calculate. Thanks to 
                          Andrew Hood for prompting this update

Copyright (c) 2003 - 2011 by PJ Naughter (Web: www.naughter.com, Email: pjna@naughter.com)

All rights reserved.

Copyright / Usage Details:

You are allowed to include the source code in any product (commercial, shareware, freeware or otherwise) 
when your product is released in binary form. You are allowed to modify the source code in any way you want 
except you cannot modify the copyright details at the top of each module. If you want to distribute source 
code with your application, then you are only allowed to distribute versions released by the author. This is 
to maintain a single distribution point for the source code. 

*/


///////////////////////////// Includes ////////////////////////////////////////

#include "stdafx.h"
#include "AARiseTransitSet.h"
#include "AASidereal.h"
#include "AACoordinateTransformation.h"
#include "AADynamicalTime.h"
#include "AAInterpolate.h"
#include <cmath>
using namespace std;


///////////////////////////// Implementation //////////////////////////////////

CAARiseTransitSetDetails CAARiseTransitSet::Calculate(double JD, double Alpha1, double Delta1, double Alpha2, double Delta2, double Alpha3, double Delta3, double Longitude, double Latitude, double h0)
{
  //What will be the return value
  CAARiseTransitSetDetails details;
  details.bRiseValid = false;
  details.bSetValid = false;
  details.bTransitAboveHorizon = false;

  //Calculate the sidereal time
  double theta0 = CAASidereal::ApparentGreenwichSiderealTime(JD);
  theta0 *= 15; //Express it as degrees

  //Calculate deltat
  double deltaT = CAADynamicalTime::DeltaT(JD);

  //Convert values to radians
  double Delta2Rad = CAACoordinateTransformation::DegreesToRadians(Delta2);
  double LatitudeRad = CAACoordinateTransformation::DegreesToRadians(Latitude);

  //Convert the standard latitude to radians
  double h0Rad = CAACoordinateTransformation::DegreesToRadians(h0);

  double cosH0 = (sin(h0Rad) - sin(LatitudeRad)*sin(Delta2Rad)) / (cos(LatitudeRad) * cos(Delta2Rad));

  //Calculate and ensure the M0 is in the range 0 to +1
  double M0 = (Alpha2*15 + Longitude - theta0) / 360; 
  while (M0 > 1)
    M0 -= 1;
  while (M0 < 0)
    M0 += 1;

  //Check that the object actually rises
  double M1 = 0;
  double M2 = 0;
  if ((cosH0 > -1) && (cosH0 < 1))
  {
    details.bRiseValid = true;
    details.bSetValid = true;
    details.bTransitAboveHorizon = true;

    double H0 = acos(cosH0);
    H0 = CAACoordinateTransformation::RadiansToDegrees(H0);

    //Calculate and ensure the M1 and M2 is in the range 0 to +1
    M1 = M0 - H0/360;
    M2 = M0 + H0/360;

    while (M1 > 1)
      M1 -= 1;
    while (M1 < 0)
      M1 += 1;

    while (M2 > 1)
      M2 -= 1;
    while (M2 < 0)
      M2 += 1;
  }
  else if (cosH0 < 1)
    details.bTransitAboveHorizon = true;

  //Ensure the RA values are corrected for interpolation. Due to important Remark 2 by Meeus on Interopolation of RA values
  if ((Alpha2 - Alpha1) > 12.0)
    Alpha1 += 24;
  else if ((Alpha2 - Alpha1) < -12.0)
    Alpha2 += 24;  
  if ((Alpha3 - Alpha2) > 12.0)
    Alpha2 += 24;
  else if ((Alpha3 - Alpha2) < -12.0)
    Alpha3 += 24;  
    
  for (int i=0; i<2; i++)
  {
    //Calculate the details of rising
    if (details.bRiseValid)
    {
      double theta1 = theta0 + 360.985647*M1;
      theta1 = CAACoordinateTransformation::MapTo0To360Range(theta1);

      double n = M1 + deltaT/86400;

      double Alpha = CAAInterpolate::Interpolate(n, Alpha1, Alpha2, Alpha3);
      double Delta = CAAInterpolate::Interpolate(n, Delta1, Delta2, Delta3);

      double H = theta1 - Longitude - Alpha*15;
      CAA2DCoordinate Horizontal = CAACoordinateTransformation::Equatorial2Horizontal(H/15, Delta, Latitude);

      double DeltaM = (Horizontal.Y - h0) / (360*cos(CAACoordinateTransformation::DegreesToRadians(Delta))*cos(LatitudeRad)*sin(CAACoordinateTransformation::DegreesToRadians(H)));
      M1 += DeltaM;
    }

    //Calculate the details of setting
    if (details.bSetValid)
    {
      double theta1 = theta0 + 360.985647*M2;
      theta1 = CAACoordinateTransformation::MapTo0To360Range(theta1);

      double n = M2 + deltaT/86400;

      double Alpha = CAAInterpolate::Interpolate(n, Alpha1, Alpha2, Alpha3);
      double Delta = CAAInterpolate::Interpolate(n, Delta1, Delta2, Delta3);

      double H = theta1 - Longitude - Alpha*15;
      CAA2DCoordinate Horizontal = CAACoordinateTransformation::Equatorial2Horizontal(H/15, Delta, Latitude);

      double DeltaM = (Horizontal.Y - h0) / (360*cos(CAACoordinateTransformation::DegreesToRadians(Delta))*cos(LatitudeRad)*sin(CAACoordinateTransformation::DegreesToRadians(H)));
      M2 += DeltaM;
    }


    //Calculate the details of transit
    double theta1 = theta0 + 360.985647*M0;
    theta1 = CAACoordinateTransformation::MapTo0To360Range(theta1);

    double n = M0 + deltaT/86400;

    double Alpha = CAAInterpolate::Interpolate(n, Alpha1, Alpha2, Alpha3);

    double H = theta1 - Longitude - Alpha*15;
    H = CAACoordinateTransformation::MapTo0To360Range(H);
    if (H > 180)
      H -= 360;

    double DeltaM = -H / 360;
    M0 += DeltaM;
  }

  details.Rise = details.bRiseValid ? (M1 * 24) : 0.0;
  details.Set = details.bSetValid ? (M2 * 24) : 0.0;
  details.Transit = M0 * 24; //We always return the transit time even if it occurs below the horizon

  return details;
}
