#include <Adafruit_Fingerprint.h>
#include <EEPROM.h>


void StartFingerprintscanner() {
  
  while (!Serial); 
  delay(100);
 
  finger.begin(57600);
}

int GetFirstFreeSpace(){
  byte value;
  for (int i = 1; i < 11; i++){
    EEPROM.get(i, value);
    if(value == 0){
      value = 1; EEPROM.put(i, value);
      return i;
    }
  }
  return -1;
}

int ReadFingerprint() {
  uint8_t p = finger.getImage();
    if (p != FINGERPRINT_OK)  return -1;

    p = finger.image2Tz();
    if (p != FINGERPRINT_OK)  return -1;

    p = finger.fingerFastSearch();
    if (p != FINGERPRINT_OK)  return -1;

    return finger.fingerID;
    
}
