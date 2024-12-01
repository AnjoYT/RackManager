#include "DHT11.h"
#include "TemperatureController.h"
#include "TempInputHandler.h"
#include "MinMax.h"

#define DHT11_PIN D5
#define DS18B20_PIN D4
#define POWER_RELAY D8

DHT11 dht11(DHT11_PIN);
TemperatureController temperatureController(DS18B20_PIN);
TempInputHandler tempInputHandler(Serial);
MinMax alarmValue;


void setup() {
    Serial.begin(9600);
    pinMode(POWER_RELAY, OUTPUT);
}

void loop() {
      alarmValue = tempInputHandler.GetInput();
      if(!std::isnan(alarmValue.maxTemp)&&!std::isnan(alarmValue.minTemp))
      {
        temperatureController.SetAlarm(alarmValue.minTemp, alarmValue.maxTemp);
        float midpoint = (float)(temperatureController.GetAlarmH() + temperatureController.GetAlarmL())/2;
        if(temperatureController.ReadTemperature()<=midpoint){
          digitalWrite(POWER_RELAY, HIGH);
        }else {
          digitalWrite(POWER_RELAY, LOW);
        }
      }
      int humidity = dht11.readHumidity();
      if (humidity != DHT11::ERROR_CHECKSUM && humidity != DHT11::ERROR_TIMEOUT) {
        Serial.print("Humidity");
        Serial.print(">>");
        Serial.print(humidity);
        Serial.print(";");
        Serial.print("Temperature");
        Serial.print(">>");
        Serial.print(temperatureController.ReadTemperature());
        Serial.println(";");
      }
      delay(5000);
}
