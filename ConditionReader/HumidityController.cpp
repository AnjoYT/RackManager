#include "HumidityController.h"

HumidityController::HumidityController(uint8_t pin): dht11(pin){}

// odczytuje wartosc i jezeli nie pojawil sie jeden z predefiniowanych bledow zwraca poprawna wartosc
HumidityController::GetCurrentHumidity(){
  int humidity = dht11.readHumidity();
  if(humidity != DHT11::ERROR_CHECKSUM && humidity != DHT11::ERROR_TIMEOUT){
    return humidity;
  }
  return NAN;
}
