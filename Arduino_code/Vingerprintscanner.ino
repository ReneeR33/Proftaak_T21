#include <Adafruit_Fingerprint.h>

void StartFingerprintscanner() {
  
  while (!Serial); 
  delay(100);
 
  finger.begin(57600);
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
