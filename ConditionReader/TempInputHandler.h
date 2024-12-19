#ifndef TEMPINPUTHANDLER_H
#define TEMPINPUTHANDLER_H

#include "Arduino.h"
#include "MinMax.h"
class TempInputHandler {
public:
  TempInputHandler(Stream& inputStream);
  MinMax GetInput();
  MinMax GetFloatInput(String input);

private:
  Stream& _inputStream;
  MinMax previousValue;

  bool IsFloat(String input);
  MinMax ParseMinMax(String input);
  String Split(String input, char delimiter);
};


#endif // !TEMPINPUTHANDLER_H
