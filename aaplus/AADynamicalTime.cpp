/*
Module : AADYNAMICALTIME.CPP
Purpose: Implementation for the algorithms which calculate the difference between Dynamical Time and Universal Time
Created: PJN / 29-12-2003
History: PJN / 01-02-2005 1. Fixed a problem with the declaration of the variable "Index" in the function 
                          CAADynamicalTime::DeltaT. Thanks to Mika Heiskanen for reporting this problem.
         PJN / 26-01-2007 1. Update to fit in with new layout of CAADate class
         PJN / 28-01-2007 1. Further updates to fit in with new layout of CAADate class
         PJN / 08-05-2011 1. Fixed a compilation issue on GCC where size_t was undefined in various methods. Thanks to 
                          Carsten A. Arnholm and Andrew Hammond for reporting this bug.

Copyright (c) 2003 - 2011 by PJ Naughter (Web: www.naughter.com, Email: pjna@naughter.com)

All rights reserved.

Copyright / Usage Details:

You are allowed to include the source code in any product (commercial, shareware, freeware or otherwise) 
when your product is released in binary form. You are allowed to modify the source code in any way you want 
except you cannot modify the copyright details at the top of each module. If you want to distribute source 
code with your application, then you are only allowed to distribute versions released by the author. This is 
to maintain a single distribution point for the source code. 

*/


////////////////////////////////// Includes ///////////////////////////////////

#include "stdafx.h"
#include "AADynamicalTime.h"
#include "AADate.h"
#include <cassert>
#include <cstddef>
using namespace std;


////////////////////////////////// Macros / Defines ///////////////////////////

double DeltaTTable[] =
{
  121, 112, 103, 95, 88,  //1620 - 1698
  82, 77, 72, 68, 63, 
  60, 56, 53, 51, 48, 
  46, 44, 42, 40, 38, 
  35, 33, 31, 29, 26, 
  24, 22, 20, 18, 16, 
  14, 12, 11, 10, 9, 
  8, 7, 7, 7, 7,

  7, 7, 8, 8, 9,   //1700 - 1778
  9, 9, 9, 9, 10,
  10, 10, 10, 10, 10,
  10, 10, 11, 11, 11,
  11, 11, 12, 12, 12,
  12, 13, 13, 13, 14, 
  14, 14, 14, 15, 15,
  15, 15, 15, 16, 16,
  
  16, 16, 16, 16, 16, //1780 - 1858
  16, 15, 15, 14, 13,
  13.1, 12.5, 12.2, 12.0, 12.0,
  12, 12, 12, 12, 11.9,
  11.6, 11, 10.2, 9.2, 8.2,
  7.1, 6.2, 5.6, 5.4, 5.3,
  5.4, 5.6, 5.9, 6.2, 6.5,
  6.8, 7.1, 7.3, 7.5, 7.6,
  
  7.7, 7.3, 6.2, 5.2, 2.7,  //1860 - 1938
  1.4, -1.2, -2.8, -3.8, -4.8,
  -5.5, -5.3,  -5.6, -5.7, -5.9,
  -6, -6.3, -6.5, -6.2, -4.7,
  -2.8, -0.1, 2.6, 5.3, 7.7,
  10.4, 13.3, 16, 18.2, 20.2,
  21.2, 22.4, 23.5, 23.8, 24.3, 
  24, 23.9, 23.9, 23.7, 24,

  24.3, 25.3, 26.2, 27.3, 28.2, //1940 - 1998
  29.1, 30, 30.7, 31.4, 32.2,
  33.1, 34.0, 35.0, 36.5, 38.3,
  40.18, 42.2, 44.5, 46.5, 48.5,
  50.54, 52.2, 53.8, 54.9, 55.8,
  56.86, 58.31, 59.99, 61.63, 62.97
};


////////////////////////////////// Implementation /////////////////////////////

double CAADynamicalTime::DeltaT(double JD)
{
  //Construct a CAADate from the julian day
  CAADate date(JD, CAADate::AfterPapalReform(JD));
  
  double y = date.FractionalYear();
  double T = (y - 2000) / 100;
  
  double Delta;
  if (y < 948)
    Delta = 2177 + (497*T) + (44.1*T*T);
  else if (y < 1620)
    Delta = 102 + (102*T) + (25.3*T*T);
  else if (y < 1998)
  {
    size_t Index = static_cast<size_t>((y - 1620) / 2);
    assert(Index < sizeof(DeltaTTable)/sizeof(double));

    y = y / 2 - Index - 810;
    Delta = (DeltaTTable[Index] + (DeltaTTable[Index + 1] - DeltaTTable[Index]) * y);
  }
  else if (y <= 2000)
  {
    int nLookupSize = sizeof(DeltaTTable)/sizeof(double);
    Delta = DeltaTTable[nLookupSize-1];
  }
  else if (y < 2100)
    Delta = 102 + (102*T) + (25.3*T*T) + 0.37*(y - 2100);
  else 
    Delta = 102 + (102*T) + (25.3*T*T);

  return Delta;
}
