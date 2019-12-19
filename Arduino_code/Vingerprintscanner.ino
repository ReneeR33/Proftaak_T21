#include <Adafruit_Fingerprint.h>
#include <EEPROM.h>

void StartFingerprintscanner() {
  
  while (!Serial); 
  delay(100);
 
  //finger.begin(57600);
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

/*int ReadFingerprint() {
  uint8_t p = finger.getImage();
    if (p != FINGERPRINT_OK)  return -1;

    p = finger.image2Tz();
    if (p != FINGERPRINT_OK)  return -1;

    p = finger.fingerFastSearch();
    if (p != FINGERPRINT_OK)  return -1;

    return finger.fingerID;
    
}*/

int ReadFingerprintK(){
  char customKey = customKeypad.getKey();
  
  if (customKey) {
    //Serial.println((int)customKey);
    int key = (int)customKey - 48;
    byte value;
    
    for (int i = 1; i < 11; i++) {
      EEPROM.get(i, value);
      
      if(value == 2 && key == i) {
        Serial.println(i);
        return i;
      }
    }
  }
  return -1;
}

/*bool RemoveFingerprint(int id){
  if(id > 0 && id < 11){
    byte value = 0;
    finger.deleteModel(id);
    EEPROM.put(id, value);

    Serial.print("Deleted fingeprint with id = ");
    Serial.println(id);
    Serial.println("#DELETION_SUCCESS%");
    
    return true;
  }
  return false;
}*/

bool ChangeAccess(Accessibility access, int id){
  if(id > 0 && id < 11 && access != NOT_SPECIFIED){
    byte value;
    EEPROM.get(id, value);
    Serial.println(value);
    if(value != 0){
      if(access == ACCESS) value = 2;
    else value = 1;
    //finger.deleteModel(id);
    EEPROM.put(id, value);

    Serial.print("Changed access for id=");
    Serial.println(id);
    
    return true;
    }
  }
  return false;
}

bool RemoveFingerprintK(int id){
  if(id > 0 && id < 11){
    byte value = 0;
    //finger.deleteModel(id);
    EEPROM.put(id, value);

    Serial.print("Deleted fingeprint with id = ");
    Serial.println(id);
    Serial.println("#DELETION_SUCCESS%");
    
    return true;
  }
  return false;
}
