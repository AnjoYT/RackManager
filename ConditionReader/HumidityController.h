#ifndef HUMIDITYCONTROLLER_H
#define HUMIDITYCONTROLLER_H
#include "DHT11.h"

class HumidityController{
  private:
  DHT11 dht11;
  public:
  HumidityController(uint8_t pin);
  int GetCurrentHumidity();
};
#endif
