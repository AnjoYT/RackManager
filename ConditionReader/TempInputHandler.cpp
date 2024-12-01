#include "Arduino.h"
#include <string>
#include "TempInputHandler.h"
TempInputHandler::TempInputHandler(Stream& inputStream):_inputStream(inputStream){}
MinMax TempInputHandler::GetInput()
{
  if(_inputStream.available()>0){
      inputValue = GetFloatInput();
      return inputValue;
  }
  return previousValue;
}
MinMax TempInputHandler::GetFloatInput()
{
  std::string input = _inputStream.readStringUntil('\n').c_str();
  if(!input.empty()&&input.back()==';')
  {
  return ParseMinMax(input);
  }
  return previousValue;
}

bool TempInputHandler::IsFloat(std::string input){
  char* end;
  std::strtod(input.c_str(),&end);
  return (*end == '\0');
}

MinMax TempInputHandler::ParseMinMax(std::string input){
  MinMax minMaxTemp;
  std::vector<std::string> valueNotParsed = Split(input,';');
  if(valueNotParsed.size()!=2)
  {
    return previousValue;
  }
  if(IsFloat(valueNotParsed[0])&&IsFloat(valueNotParsed[1]))
  {
    if(std::stof(valueNotParsed[0])<=std::stof(valueNotParsed[1]))
    {
      minMaxTemp.minTemp = std::stof(valueNotParsed[0]);
      minMaxTemp.maxTemp = std::stof(valueNotParsed[1]);
    }else
    {
      minMaxTemp.minTemp = std::stof(valueNotParsed[1]);
      minMaxTemp.maxTemp = std::stof(valueNotParsed[0]);
    }
    previousValue.minTemp = minMaxTemp.minTemp;
    previousValue.maxTemp = minMaxTemp.maxTemp;
  }
  else {
    return previousValue;
  }
  return minMaxTemp;
  
}

std::vector<std::string> TempInputHandler::Split(std::string input,char delimiter)
{
  std::vector<std::string> values;
  size_t pos = 0;
  while((pos = input.find(delimiter)) != std::string::npos)
  {
    std::string value;
    
    value = input.substr(0,pos);
    values.push_back(value);
    input.erase(0,pos+1);
  }
  return values;
}


