
#include "DHT11.h"
#include "DS18B20.h"

#define DHT_PIN D5
#define DS18B20_PIN D4

DHT11 dht11(DHT_PIN);
DS18B20 ds18b20(DS18B20_PIN);

void setup() {
    Serial.begin(9600);
}

void loop() {

  int humidity = dht11.readHumidity();
      if (humidity != DHT11::ERROR_CHECKSUM && humidity != DHT11::ERROR_TIMEOUT) {
        Serial.print("Humidity");
        Serial.print(">>");
        Serial.print(humidity);
        Serial.print(";");
        Serial.print("Temperature");
        Serial.print(">>");
        Serial.print(ds18b20.getTempC());
        Serial.println(";");
      }
}
