int fingerPrintScan = FINGERPRINT_INVALIDIMAGE;
int fingerPrintScanProgress = 1;

void addFingerprint() {
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
