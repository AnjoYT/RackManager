#include "TemperatureController.h"

	TemperatureController::TemperatureController(uint8_t pin): thermometer(pin){}

	void TemperatureController::SetAlarm(uint8_t minTemp,uint8_t maxTemp)
	{
		thermometer.setAlarms(minTemp,maxTemp);
	}
	uint8_t TemperatureController::HasAlarm()
	{
		return thermometer.hasAlarm();
	}
	float TemperatureController::ReadTemperature()
	{
      return thermometer.getTempC();
	}
  int8_t TemperatureController::getAlarmH(){
    return thermometer.getAlarmHigh();
  }
  int8_t TemperatureController::getAlarmL(){
    return thermometer.getAlarmLow();
  }