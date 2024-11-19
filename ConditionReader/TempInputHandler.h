#ifndef TEMPINPUTHANDLER_H
#define TEMPINPUTHANDLER_H

#include "Arduino.h"
#include <string>
#include "MinMax.h"
class TempInputHandler {
  private:
    MinMax inputValue;
    Stream& _inputStream;
    MinMax GetFloatInput();
    bool IsFloat(std::string input);
    MinMax ParseMinMax(std::string input);
    std::vector<std::string> Split(std::string input,char delimiter);
	public:
    TempInputHandler(Stream& inputStream);
		MinMax GetInput();
 };

#endif // !TEMPINPUTHANDLER_H
