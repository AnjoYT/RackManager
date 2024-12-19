#ifndef TEMPERATURECONTROLLER_H
#define TEMPERATURECONTROLLER_H
#include "DS18B20.h"

class TemperatureController{
  private:
	  DS18B20 thermometer;
  public:
    TemperatureController(uint8_t pin);
    void SetAlarm(uint8_t minTemp,uint8_t maxTemp);
    uint8_t IsAlarmActive();
    float GetCurrentTemperature();
    int8_t GetAlarmL();
    int8_t GetAlarmH();
};

#endif