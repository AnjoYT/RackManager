#include <EEPROM.h>
#include "HumidityController.h"
#include "TemperatureController.h"
#include "TempInputHandler.h"
#include "MinMax.h"
#include <PID_v1.h>


#define DHT11_PIN 5
#define DS18B20_PIN 4
#define POWER_RELAY 8

HumidityController humidityController(DHT11_PIN);
TemperatureController temperatureController(DS18B20_PIN);
TempInputHandler tempInputHandler(Serial);
double Input, Output,Setpoint;
double const Kp=1, Ki=3, Kd=3;
PID PID(&Input, &Output, &Setpoint, Kp, Ki, Kd, DIRECT);
MinMax alarmValue;

void setup() {
    Serial.begin(9600);
    pinMode(POWER_RELAY, OUTPUT);
    LoadFromEEPROM();
    PID.SetMode(AUTOMATIC);
          if(!isnan(alarmValue.maxTemp)&&!isnan(alarmValue.minTemp))
      {
        Setpoint =(alarmValue.maxTemp + alarmValue.minTemp) / 2;
      }
}

void loop() {
      alarmValue = tempInputHandler.GetInput();
      Input = temperatureController.GetCurrentTemperature();
      if(!isnan(alarmValue.maxTemp)&&!isnan(alarmValue.minTemp))
      {
        SaveToEEPROM(alarmValue);
        Setpoint =(alarmValue.maxTemp + alarmValue.minTemp) / 2;
      }
      PID.Compute();

        if(Output>0){
          digitalWrite(POWER_RELAY, HIGH);
        }else {
          digitalWrite(POWER_RELAY, LOW);
        }
      int humidity = humidityController.GetCurrentHumidity();
      GetData(humidity,Input);
      delay(10000);
}
void GetData(int humidity, double temperature)
{
      if (humidity != NAN && temperature != NAN) {
              Serial.print("Humidity");
              Serial.print(">>");
              Serial.print(humidity);
              Serial.print(";");
              Serial.print("Temperature");
              Serial.print(">>");
              Serial.print(temperature);
              Serial.println(";");
            }
}
// za pomocą metody put umieszczamy dane do pamięci eeprom 
void SaveToEEPROM(MinMax value)
{
    EEPROM.put(0, value.minTemp);
    EEPROM.put(sizeof(float), value.maxTemp);
}
void LoadFromEEPROM(){
    EEPROM.get(0, alarmValue.minTemp);
    EEPROM.get(sizeof(float), alarmValue.maxTemp);
    Serial.println();
    Serial.print("Loaded Min Temp from EEPROM: ");
    Serial.println(alarmValue.minTemp);
    Serial.print("Loaded Max Temp from EEPROM: ");
    Serial.println(alarmValue.maxTemp);
}
