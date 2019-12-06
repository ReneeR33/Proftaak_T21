int fingerPrintScan = FINGERPRINT_INVALIDIMAGE;
int fingerPrintScanProgress = 1;

void addFingerprintK() {
  //fingerPrintScan = finger.getImage();
  char customKey = customKeypad.getKey();
  //int key = (int)customKey - 48;
  
  if (customKey && fingerPrintScanProgress < 3) {
    //fingerPrintScan = finger.image2Tz(fingerPrintScanProgress);
    
    fingerPrintScanProgress++;
    Serial.println("OK");
    Serial.println(fingerPrintScanProgress);
    delay(500);
  }
  if (fingerPrintScanProgress == 3) {
    Serial.println("2 Images taken");
    //fingerPrintScan = finger.createModel();

    Serial.println("Created a model");

    int id = GetFirstFreeSpace();

    if (id != -1) {
      EEPROM.put(id, 1);
      Serial.print("Stored, id value = ");
      Serial.println(id);
    }
    fingerPrintScanProgress = 1;
  }
}

/*void addFingerprint() {
  fingerPrintScan = finger.getImage();
  if (fingerPrintScan == FINGERPRINT_OK && fingerPrintScanProgress < 3) {
    fingerPrintScan = finger.image2Tz(fingerPrintScanProgress);
    if (fingerPrintScan == FINGERPRINT_OK) {
      fingerPrintScanProgress++;
      Serial.println("OK");
      Serial.println(fingerPrintScanProgress);
      delay(500);
    }
  }
  if (fingerPrintScanProgress == 3) {
    Serial.println("2 Images taken");
    fingerPrintScan = finger.createModel();
    if (fingerPrintScan == FINGERPRINT_OK) {
      Serial.println("Created a model");
      // HIER
      int id = GetFirstFreeSpace();
      //
      if (id != -1) {
        fingerPrintScan = finger.storeModel(id);
        if (fingerPrintScan == FINGERPRINT_OK) {
          Serial.print("Stored, id value = ");
          Serial.println(id);
        }
      }
      else {
        Serial.println("Scanner is full");
      }

    }
    fingerPrintScanProgress = 1;
  }
}
*/
