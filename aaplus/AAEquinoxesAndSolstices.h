/*
Module : AAEQUINOXESANDSOLTICES.H
Purpose: Implementation for the algorithms to calculate the dates of the Equinoxes and Solstices
Created: PJN / 29-12-2003

Copyright (c) 2003 - 2011 by PJ Naughter (Web: www.naughter.com, Email: pjna@naughter.com)

All rights reserved.

Copyright / Usage Details:

You are allowed to include the source code in any product (commercial, shareware, freeware or otherwise) 
when your product is released in binary form. You are allowed to modify the source code in any way you want 
except you cannot modify the copyright details at the top of each module. If you want to distribute source 
code with your application, then you are only allowed to distribute versions released by the author. This is 
to maintain a single distribution point for the source code. 

*/


/////////////////////// Macros / Defines //////////////////////////////////////

#if _MSC_VER > 1000
#pragma once
#endif

#ifndef __AAEQUINOXESANDSOLSTICES_H_
#define __AAEQUINOXESANDSOLSTICES_H_

#ifndef AAPLUS_EXT_CLASS
#define AAPLUS_EXT_CLASS
#endif


/////////////////////// Classes ///////////////////////////////////////////////

class AAPLUS_EXT_CLASS CAAEquinoxesAndSolstices
{
public:
//Static methods
  static double SpringEquinox(long Year);
  static double SummerSolstice(long Year);
  static double AutumnEquinox(long Year);
  static double WinterSolstice(long Year);

  static double LengthOfSpring(long Year);
  static double LengthOfSummer(long Year);
  static double LengthOfAutumn(long Year);
  static double LengthOfWinter(long Year);
};

#endif //__AAEQUINOXESANDSOLSTICES_H_
