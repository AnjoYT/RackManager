#include "TempInputHandler.h"

TempInputHandler::TempInputHandler(Stream& inputStream) : _inputStream(inputStream) {}

MinMax TempInputHandler::GetInput() {
  if (_inputStream.available() > 0) {
    //jeśli stream jest ustanowiony metoda wczytuje do zmiennej input, wartości przesyłane przez port seryjny
    String input = _inputStream.readStringUntil('\n');
    //zwraca metode która zamienia wartość string na float
    return GetFloatInput(input);
  }
  return previousValue;
}

MinMax TempInputHandler::GetFloatInput(String input) {
  if (input.length()>0 && input.endsWith(";")) {
    return ParseMinMax(input);
  }
  return previousValue;
}

bool TempInputHandler::IsFloat(String input) {
  return input.toFloat() > 0;
}

MinMax TempInputHandler::ParseMinMax(String input) {
  MinMax minMaxTemp;
  String valueNotParsed[2];
  int index = 0;

  while (input.length() > 0) {
    int pos = input.indexOf(';');
    if (pos == -1) break;
    valueNotParsed[index++] = input.substring(0, pos);
    input = input.substring(pos + 1);
  }

  if (index != 2) return previousValue;

  if (IsFloat(valueNotParsed[0]) && IsFloat(valueNotParsed[1])) {
    minMaxTemp.minTemp = min(valueNotParsed[0].toFloat(), valueNotParsed[1].toFloat());
    minMaxTemp.maxTemp = max(valueNotParsed[0].toFloat(), valueNotParsed[1].toFloat());
    previousValue = minMaxTemp;
  } else {
    return previousValue;
  }

  return minMaxTemp;
}

String TempInputHandler::Split(String input, char delimiter) {
  String value;
  int pos = input.indexOf(delimiter);
  if (pos != -1) {
    value = input.substring(0, pos);
    input = input.substring(pos + 1);
  }
  return value;
}