#include "Arduino.h"
#include "CommandHandler.h"
CommandHandler::CommandHandler(Stream& inputStream):_inputStream(inputStream){}
float CommandHandler::GetInput()
{
  if(_inputStream.available()>0){
      inputValue = GetFloatInput(_inputStream);
      return inputValue;
  }
  return NAN;
}
float CommandHandler::GetFloatInput(Stream& _inputStream)
{
  String input = _inputStream.readStringUntil('\n');
  return input.toFloat();
}

