#include "TemperatureController.h"


	TemperatureController::TemperatureController(uint8_t pin): thermometer(pin){}

	void TemperatureController::SetAlarm(uint8_t minTemp,uint8_t maxTemp)
	{
		thermometer.setAlarms(minTemp,maxTemp);
	}
	uint8_t TemperatureController::IsAlarmActive()
	{
		return thermometer.hasAlarm();
	}
	float TemperatureController::GetCurrentTemperature()
	{
      return thermometer.getTempC();
	}
  int8_t TemperatureController::GetAlarmH(){
    return thermometer.getAlarmHigh();
  }
  int8_t TemperatureController::GetAlarmL(){
    return thermometer.getAlarmLow();
  }