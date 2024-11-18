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
  if(IsFloat(input) && !input.isEmpty()){
  return input.toFloat();
  }
  return NAN;
}

bool CommandHandler::IsFloat(String input){
  char* end;
  std::strtod(input.c_str(),&end);
  return (*end == '\0');
}

